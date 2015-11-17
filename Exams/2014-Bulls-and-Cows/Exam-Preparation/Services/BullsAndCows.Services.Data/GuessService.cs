namespace BullsAndCows.Services.Data
{
    using System.Linq;
    using BullsAndCows.Data.Models;
    using BullsAndCows.Data.Repositories;
    using BullsAndCows.Services.Data.Contracts;
    using System;
    using Common.Constants;

    public class GuessService : IGuessService
    {
        private readonly IGamesService games;
        private readonly IRepository<Guess> guesses;

        public GuessService(IGamesService games, IRepository<Guess> guesses)
        {
            this.games = games;
            this.guesses = guesses;
        }

        public IQueryable<Guess> GetGuessDetails(int id)
        {
            return this.guesses
                .All()
                .Where(g => g.Id == id);
        }

        public Guess MakeGuess(int gameId, string number, string userId)
        {
            var game = this.games
                .GetGameDetails(gameId)
                .Select(g => new
                {
                    g.GameState,
                    g.BlueUserNumber,
                    g.RedUserNumber
                })
                .FirstOrDefault();

            string correctNumber = null;
            if (game.GameState == GameState.BlueInTurn)
            {
                correctNumber = game.RedUserNumber;
            }
            else if (game.GameState == GameState.RedInTurn)
            {
                correctNumber = game.BlueUserNumber;
            }

            var cows = this.GetCows(number, correctNumber);
            var bulls = this.GetBulls(number, correctNumber);

            var newGuess = new Guess
            {
                GameId = gameId,
                Number = number,
                UserId = userId,
                DateMade = DateTime.UtcNow,
                BullsCount = bulls,
                CowsCount = cows
            };

            this.guesses.Add(newGuess);
            this.guesses.SaveChanges();

            this.games.ChangeGameState(gameId, bulls == GameConstants.GuessNumberLength);

            return newGuess;
        }

        private int GetCows(string guessNumber, string correctNumber)
        {
            var result = 0;
            for (int i = 0; i < correctNumber.Length; i++)
            {
                for (int j = 0; j < guessNumber.Length; j++)
                {
                    if (correctNumber[i] == guessNumber[j] && i != j)
                    {
                        result++;
                    }
                }
            }

            return result;
        }

        private int GetBulls(string guessNumber, string correctNumber)
        {
            var result = 0;
            for (int i = 0; i < correctNumber.Length; i++)
            {
                if (correctNumber[i] == guessNumber[i])
                {
                    result++;
                }
            }

            return result;
        }
    }
}
