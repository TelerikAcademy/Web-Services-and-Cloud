namespace BullsAndCows.Services.Data
{
    using System.Linq;
    using BullsAndCows.Data.Repositories;
    using BullsAndCows.Data.Models;
    using BullsAndCows.Services.Data.Contracts;
    using Common.Constants;
    using System;
    using Common.Providers;

    public class GamesService : IGamesService
    {
        private readonly IHighScoreService highScore;
        private readonly IRepository<Game> games;
        private readonly IRandomProvider random;

        public GamesService(IHighScoreService highScore, IRepository<Game> games, IRandomProvider random)
        {
            this.highScore = highScore;
            this.games = games;
            this.random = random;
        }

        public IQueryable<Game> GetPublicGames(int page = 1, string userId = null)
        {
            return this.games
                .All()
                .Where(g => g.GameState == GameState.WaitingForOpponent
                    || (g.GameState != GameState.WaitingForOpponent
                    && (g.RedUserId == userId || g.BlueUserId == userId)))
                .OrderBy(g => g.GameState)
                .ThenBy(g => g.Name)
                .ThenBy(g => g.DateCreated)
                .ThenBy(g => g.RedUser.Email)
                .Skip((page - 1) * GameConstants.GamesPerPage)
                .Take(GameConstants.GamesPerPage);
        }

        public Game CreateGame(string name, string number, string userId)
        {
            var newGame = new Game
            {
                Name = name,
                GameState = GameState.WaitingForOpponent,
                RedUserId = userId,
                RedUserNumber = number,
                DateCreated = DateTime.UtcNow
            };

            this.games.Add(newGame);
            this.games.SaveChanges();

            return newGame;
        }

        public IQueryable<Game> GetGameDetails(int id)
        {
            return this.games
                .All()
                .Where(g => g.Id == id);
        }

        public bool GameCanBeJoinedByUser(int id, string userId)
        {
            return !this.games
                .All()
                .Any(g => g.Id == id
                    && (g.RedUserId == userId 
                    || g.GameState != GameState.WaitingForOpponent));
        }

        public string JoinGame(int id, string number, string userId)
        {
            var gameToJoin = this.games.GetById(id);

            gameToJoin.BlueUserId = userId;
            gameToJoin.GameState = (GameState)this.random.GetRandomNumber(1, 2);
            gameToJoin.BlueUserNumber = number;

            this.games.SaveChanges();

            return gameToJoin.Name;
        }

        public bool CanMakeGuess(int id, string userId)
        {
            return this.games
                .All()
                .Any(g => g.Id == id
                    && ((g.GameState == GameState.BlueInTurn && g.BlueUserId == userId) 
                        || (g.GameState == GameState.RedInTurn && g.RedUserId == userId)));
        }

        public bool UserIsPartOfGame(int id, string userId)
        {
            return this.games
                .All()
                .Any(g => g.Id == id && (g.BlueUserId == userId || g.RedUserId == userId));
        }

        public void ChangeGameState(int id, bool finished)
        {
            var game = this.GetGameDetails(id).FirstOrDefault();

            if (finished)
            {
                if (game.GameState == GameState.BlueInTurn)
                {
                    game.GameResult = GameResultType.WonByBlue;
                    this.highScore.UpdateRank(game.BlueUserId, won: true);
                    this.highScore.UpdateRank(game.RedUserId, won: false);
                }
                else if (game.GameState == GameState.RedInTurn)
                {
                    game.GameResult = GameResultType.WonByRed;
                    this.highScore.UpdateRank(game.RedUserId, won: true);
                    this.highScore.UpdateRank(game.BlueUserId, won: false);
                }

                game.GameState = GameState.Finished;
            }
            else
            {
                if (game.GameState == GameState.BlueInTurn)
                {
                    game.GameState = GameState.RedInTurn;
                }
                else if (game.GameState == GameState.RedInTurn)
                {
                    game.GameState = GameState.BlueInTurn;
                }
            }

            games.SaveChanges();
        }
    }
}
