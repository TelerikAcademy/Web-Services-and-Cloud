using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using BullsAndCows.Data.UoWs;
using BullsAndCows.Entities;
using BullsAndCows.RestApi.Models;
using Microsoft.AspNet.Identity;

namespace BullsAndCows.RestApi.Controllers
{
    [Authorize]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class GuessController : BaseApiController
    {
        private const string GameWonMessageFormat = "You beat {0} in game \"{1}\"";
        private const string GameLostMessageFormat = "{0} beat you in game \"{1}\"";
        private const string NextTurnNotificationFormat = "It is your turn in game \"{0}\"";

        public GuessController()
            : base()
        {
        }

        public GuessController(IBullsAndCowsData data)
            : base(data)
        {
        }

        [HttpPost]
        [Route("api/games/{gameId}/guess")]
        public IHttpActionResult MakeGuess(int gameId, [FromBody]
                                           NumberModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentUserId = this.User.Identity.GetUserId();
            var game = this.Data.Games.Find(gameId);
            if (game == null || (game.State != GameState.RedInTurn && game.State != GameState.BlueInTurn))
            {
                return BadRequest("Invalid game");
            }
            var isUserRed = game.RedUser.Id == currentUserId;
            if ((isUserRed && game.State != GameState.RedInTurn) ||
                (!isUserRed && game.State != GameState.BlueInTurn))
            {
                return BadRequest("It is not your turn");
            }
            var guessNumber = model.Number;
            var opponentNumber = ((isUserRed) ? game.BlueUserNumber : game.RedUserNumber).ToString();

            var cows = this.CountCows(guessNumber, opponentNumber);
            var bulls = this.CountBulls(guessNumber, opponentNumber);

            if (bulls == 4)
            {
                FinishGame(game);
                return Ok(string.Format("Game won! Opponent number {0}", opponentNumber));
            }

            var guess = new Guess()
            {
                User = this.Data.Users.Find(currentUserId),
                BullsCount = bulls,
                CowsCount = cows,
                DateCreated = DateTime.Now,
                Value = int.Parse(guessNumber)
            };

            game.Guesses.Add(guess);
            game.State = (game.State == GameState.RedInTurn) ? GameState.BlueInTurn : GameState.RedInTurn;

            this.Data.Games.Update(game);
            this.Data.SaveChanges();

            var opponent = isUserRed ? game.BlueUser : game.RedUser;

            var nextTurnNotification = new Notification()
            {
                Message = string.Format(NextTurnNotificationFormat, game.Name),
                DateCreated = DateTime.Now,
                NotificationState = NotificationState.Unread,
                NotificationType = NotificationType.YourTurn,
                User = opponent
            };
            game.Notifications.Add(nextTurnNotification);            
            this.Data.SaveChanges();

            var guessModel = (new Guess[] { guess }).AsQueryable()
                                                    .Select(GuessModel.FromGuess)
                                                    .First();

            return Created("", guessModel);
        }

        private void FinishGame(Game game)
        {
            var currentUserId = this.User.Identity.GetUserId();
            var user = this.Data.Users.Find(currentUserId);
            var userScore = new UserScore()
            {
                ScoreType = ScoreType.Won,
                Game = game,
                User = user
            };
            this.Data.UserScores.Add(userScore);

            var opponent = (game.RedUser.Id == currentUserId) ? game.BlueUser : game.RedUser;

            var opponentScore = new UserScore()
            {
                ScoreType = ScoreType.Lost,
                Game = game,
                User = opponent
            };
            this.Data.UserScores.Add(opponentScore);

            game.State = GameState.Finished;
            this.Data.Games.Update(game);
            this.Data.SaveChanges();

            var winnerNotification = new Notification()
            {
                Message = string.Format(GameWonMessageFormat, opponent.UserName, game.Name),
                DateCreated = DateTime.Now,
                NotificationState = NotificationState.Unread,
                NotificationType = NotificationType.GameWon,
                User = user,
                Game = game,
            };

            var loserNotification = new Notification()
            {
                Message = string.Format(GameLostMessageFormat, user.UserName, game.Name),
                DateCreated = DateTime.Now,
                NotificationState = NotificationState.Unread,
                NotificationType = NotificationType.GameLost,
                User = opponent,
                Game = game,
            };
            this.Data.Notifications.Add(loserNotification);
            this.Data.Notifications.Add(winnerNotification);
            this.Data.SaveChanges();
        }

        private int CountCows(string guess, string number)
        {
            var cows = 0;
            for (var i = 0; i < guess.Length; i++)
            {
                for (var j = 0; j < number.Length; j++)
                {
                    if (i != j && number[i] == guess[j])
                    {
                        cows++;
                    }
                }
            }
            return cows;
        }

        private int CountBulls(string guess, string number)
        {
            var bulls = 0;
            for (var i = 0; i < guess.Length; i++)
            {
                if (number[i] == guess[i])
                {
                    bulls++;
                }
            }
            return bulls;
        }
    }
}