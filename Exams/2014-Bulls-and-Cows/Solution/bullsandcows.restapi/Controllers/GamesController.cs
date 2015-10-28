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
    using System;
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using Microsoft.AspNet.Identity;
    using System.Collections.Generic;
    using BullsAndCows.Entities;
    using BullsAndCows.Data.UoWs;
    using BullsAndCows.RestApi.Models;

    [Authorize]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class GamesController : BaseApiController
    {
        private const int PageSize = 10;
        private static Random rand = new Random();
        private const string GameJoinedMessageFormat = "{0} joined your game \"{1}\"";
        private const string NextTurnNotificationFormat = "It is your turn in game \"{0}\"";

        public GamesController() : base()
        {
        }

        public GamesController(IBullsAndCowsData data) : base(data)
        {
        }

        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult GetGames(int page = 0)
        {
            if (page < 0)
            {
                BadRequest("Invalid page number");
            }
            var games = this.GetWaitingForOpponentOrUserGames()
                            .Skip(page * PageSize)
                            .Take(PageSize);

            return Ok(games);
        }

        [HttpGet]
        public IHttpActionResult GetGameDetails(int id)
        {
            var currentUserId = this.User.Identity.GetUserId();

            var game = this.Data.Games.Find(id);
            if (game == null ||
                (game.RedUser.Id != currentUserId && (game.BlueUser == null ||
                                                      game.BlueUser.Id != currentUserId)))
            {
                return BadRequest("Invalid game");
            }
            var user = (game.RedUser.Id == currentUserId) ? game.RedUser : game.BlueUser;
            var opponent = (game.RedUser.Id == currentUserId) ? game.BlueUser : game.RedUser;
            int? userNumber = (game.RedUser.Id == user.Id) ? game.RedUserNumber : game.BlueUserNumber;

            var userGuesses = this.ExtractUserGuesses(game, user);
            var opponentGuesses = this.ExtractUserGuesses(game, opponent);

            var gameModel = new GameDetailsModel()
            {
                Id = game.Id,
                Name = game.Name,
                Red = game.RedUser.UserName,
                Blue = (game.BlueUser != null) ? game.BlueUser.UserName : "Nobody has joined yet",
                YourColor = (game.RedUser.Id == user.Id)? "red": "blue",
                YourNumber = userNumber,
                YourGuesses = userGuesses,
                OpponentGuesses = opponentGuesses,
                DateCreated = game.DateCreated,
                GameState = game.State.ToString()
            };
            return Ok(gameModel);
        }

        [HttpPost]
        public IHttpActionResult CreateGame(CreateGameModel createGameModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentUserId = this.User.Identity.GetUserId();

            var game = new Game()
            {
                Name = createGameModel.Name,
                RedUser = this.Data.Users.Find(currentUserId),
                State = GameState.WaitingForOpponent,
                RedUserNumber = int.Parse(createGameModel.Number)
            };

            this.Data.Games.Add(game);
            this.Data.SaveChanges();

            var location = Url.Link("DefaultApi", new { id = game.Id });

            var gameModel = (new Game[] { game }).AsQueryable()
                                                 .Select(GameModel.FromGame)
                                                 .First();

            return Created<GameModel>(location, gameModel);
        }

        [HttpPut]
        public IHttpActionResult JoinGame(int id, [FromBody]
                                          NumberModel numberModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentUserId = this.User.Identity.GetUserId();
            var currentUser = this.Data.Users.Find(currentUserId);
            var game = this.Data.Games.Find(id);
            if (game == null || game.State != GameState.WaitingForOpponent)
            {
                return BadRequest("Invalid game");
            }

            if (game.RedUser.Id == currentUser.Id)
            {
                return BadRequest("User cannot join their own games");
            }

            var isRedInTurn = rand.Next() % 2 == 0;
            game.State = (isRedInTurn) ? GameState.RedInTurn : GameState.BlueInTurn;
          
            game.BlueUser = currentUser;
            game.BlueUserNumber = int.Parse(numberModel.Number);

            this.Data.Games.Update(game);
            this.Data.SaveChanges();

            var nextTurnnotification = new Notification()
            {
                Message = string.Format(NextTurnNotificationFormat, game.Name),
                DateCreated = DateTime.Now,
                NotificationState = NotificationState.Unread,
                NotificationType = NotificationType.YourTurn,
                User = isRedInTurn ? game.RedUser : game.BlueUser,
                Game = game
            };
            this.Data.Notifications.Add(nextTurnnotification);

            var notification = new Notification()
            {
                Message = string.Format(GameJoinedMessageFormat, currentUser.UserName, game.Name),
                DateCreated = DateTime.Now,
                Game = game,
                NotificationType = NotificationType.GameJoined,
                NotificationState = NotificationState.Unread,
                User = game.RedUser
            };
            this.Data.Notifications.Add(notification);
            this.Data.SaveChanges();

            return Ok("Game joined");
        }

        private IEnumerable<GuessModel> ExtractUserGuesses(Game game, User user)
        {
            var guessses = game.Guesses
                               .AsQueryable()
                               .Where(guess => guess.User.Id == user.Id)
                               .Select(GuessModel.FromGuess);
            return guessses;
        }

        private IQueryable<GameModel> GetWaitingForOpponentOrUserGames()
        {
            var currentUserId = this.User.Identity.GetUserId();

            if (string.IsNullOrEmpty(currentUserId))
            {
                return this.Data.Games.All()
                           .Where(game => game.State == GameState.WaitingForOpponent)
                           .OrderBy(game => game.State)
                           .OrderBy(game => game.Name)
                           .ThenBy(game => game.DateCreated)
                           .ThenBy(game => game.RedUser.UserName)
                           .Select(GameModel.FromGame);
            }
            else
            {
                return this.Data.Games.All()
                           .Where(game => game.State == GameState.WaitingForOpponent ||
                                          ((game.State == GameState.BlueInTurn || game.State == GameState.RedInTurn) &&
                                           (game.RedUser.Id == currentUserId || game.BlueUser.Id == currentUserId)))
                           .OrderBy(game => game.State)
                           .OrderBy(game => game.Name)
                           .ThenBy(game => game.DateCreated)
                           .ThenBy(game => game.RedUser.UserName)
                           .Select(GameModel.FromGame);
            }
        }
    }
}