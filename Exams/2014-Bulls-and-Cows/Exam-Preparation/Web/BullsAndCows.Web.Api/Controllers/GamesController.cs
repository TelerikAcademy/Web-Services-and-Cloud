namespace BullsAndCows.Web.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using AutoMapper.QueryableExtensions;
    using Services.Data.Contracts;
    using Models.Games;
    using Microsoft.AspNet.Identity;
    using AutoMapper;
    using System.Net.Http;
    using Infrastructure.Validation;
    using Models.Guesses;

    public class GamesController : ApiController
    {
        private readonly IGamesService games;
        private readonly IGuessService guesses;

        public GamesController(IGamesService games, IGuessService guesses)
        {
            this.games = games;
            this.guesses = guesses;
        }

        public IHttpActionResult Get(string page = "1")
        {
            int pageAsNumber;
            if (!int.TryParse(page, out pageAsNumber))
            {
                pageAsNumber = 1;
            }

            var userId = this.User.Identity.GetUserId();
            var games = this.games
                .GetPublicGames(pageAsNumber, userId)
                .ProjectTo<ListedGameResponseModel>()
                .ToList();

            return this.Ok(games);
        }

        [Authorize]
        public IHttpActionResult Get(int id)
        {
            var userId = this.User.Identity.GetUserId();
            if (!this.games.UserIsPartOfGame(id, userId))
            {
                return this.BadRequest("You are not part of this game!");
            }

            var gameResult = this.games
                .GetGameDetails(id)
                .ProjectTo<GameDetailsResponseModel>(new { userId })
                .FirstOrDefault();

            return this.Ok(gameResult);
        }

        [Authorize]
        [ValidateModel]
        public IHttpActionResult Post(CreateGameRequestModel model)
        {
            var newGame = this.games.CreateGame(
                model.Name,
                model.Number,
                this.User.Identity.GetUserId());

            var gameResult = games
                .GetGameDetails(newGame.Id)
                .ProjectTo<ListedGameResponseModel>()
                .FirstOrDefault();
            
            return this.Created(
                string.Format("/api/Games/{0}", newGame.Id),
                gameResult);
        }

        [Authorize]
        [ValidateModel]
        public IHttpActionResult Put(int id, BaseGameRequestModel model)
        {
            var userId = this.User.Identity.GetUserId();
            if (!this.games.GameCanBeJoinedByUser(id, userId))
            {
                return this.BadRequest("This game is yours! Do you have two personalities?");
            }

            // TODO: add notification

            var joinedGame = this.games.JoinGame(id, model.Number, userId);

            return this.Ok(new { result = string.Format("You joined game \"{0}\"", joinedGame) });
        }

        [HttpPost]
        [Route("api/games/{id}/guess")]
        [ValidateModel]
        public IHttpActionResult Guess(int id, BaseGameRequestModel model)
        {
            var userId = this.User.Identity.GetUserId();
            if (!this.games.CanMakeGuess(id, userId))
            {
                return this.BadRequest("Either you are not part of the game or it is not your turn!");
            }

            var newGuess = this.guesses.MakeGuess(id, model.Number, userId);

            var guessResult = this.guesses
                .GetGuessDetails(newGuess.Id)
                .ProjectTo<GuessDetailsResponseModel>()
                .FirstOrDefault();

            return this.Ok(guessResult);
        }
    }
}
