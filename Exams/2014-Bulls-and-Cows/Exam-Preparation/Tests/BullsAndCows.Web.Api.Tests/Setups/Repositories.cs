namespace BullsAndCows.Web.Api.Tests.Setups
{
    using Data.Models;
    using BullsAndCows.Data.Repositories;
    using Moq;
    using System.Collections.Generic;
    using System.Linq;

    public static class Repositories
    {
        public static IRepository<Game> GetGamesRepository()
        {
            var repository = new Mock<IRepository<Game>>();

            repository.Setup(r => r.All()).Returns(() =>
            {
                return new List<Game>
                {
                    new Game { GameState = GameState.WaitingForOpponent, Name = "B", RedUser = new User { Email = "Red" }, BlueUser = new User { UserName = "Blue" } },
                    new Game { GameState = GameState.Finished, Name = "A", RedUser = new User { Email = "Red" }, BlueUser = new User { UserName = "Blue" } },
                    new Game { GameState = GameState.WaitingForOpponent, Name = "C", RedUser = new User { Email = "Red" }, BlueUser = new User { UserName = "Blue" } },
                    new Game { GameState = GameState.Finished, Name = "A", RedUser = new User { Email = "Red" }, BlueUser = new User { UserName = "Blue" } },
                    new Game { GameState = GameState.WaitingForOpponent, Name = "A", RedUser = new User { Email = "Red" }, BlueUser = new User { UserName = "Blue" } },
                    new Game { GameState = GameState.Finished, Name = "A", RedUser = new User { Email = "Red" }, BlueUser = new User { UserName = "Blue" } },
                    new Game { GameState = GameState.WaitingForOpponent, Name = "A", RedUser = new User { Email = "Red" }, BlueUser = new User { UserName = "Blue" } },
                    new Game { GameState = GameState.Finished, Name = "A", RedUser = new User { Email = "Red" }, BlueUser = new User { UserName = "Blue" }},
                    new Game { GameState = GameState.WaitingForOpponent, Name = "A", RedUser = new User { Email = "Red" }, BlueUser = new User { UserName = "Blue" } },
                    new Game { GameState = GameState.Finished, Name = "A", RedUser = new User { Email = "Red" }, BlueUser = new User { UserName = "Blue" } },
                    new Game { GameState = GameState.WaitingForOpponent, Name = "A", RedUser = new User { Email = "Red" }, BlueUser = new User { UserName = "Blue" } },
                    new Game { GameState = GameState.Finished, Name = "A", RedUser = new User { Email = "Red" }, BlueUser = new User { UserName = "Blue" } },
                    new Game { GameState = GameState.WaitingForOpponent, Name = "A", RedUser = new User { Email = "Red" }, BlueUser = new User { UserName = "Blue" } },
                    new Game { GameState = GameState.Finished, Name = "A", RedUser = new User { Email = "Red" }, BlueUser = new User { UserName = "Blue" } },
                    new Game { GameState = GameState.WaitingForOpponent, Name = "A", RedUser = new User { Email = "Red" }, BlueUser = new User { UserName = "Blue" } },
                    new Game { GameState = GameState.Finished, Name = "A", RedUser = new User { Email = "Red" }, BlueUser = new User { UserName = "Blue" } },
                    new Game { GameState = GameState.WaitingForOpponent, Name = "A", RedUser = new User { Email = "Red" }, BlueUser = new User { UserName = "Blue" } },
                    new Game { GameState = GameState.Finished, Name = "A", RedUser = new User { Email = "Red" }, BlueUser = new User { UserName = "Blue" } },
                    new Game { GameState = GameState.WaitingForOpponent, Name = "A", RedUser = new User { Email = "Red" }, BlueUser = new User { UserName = "Blue" } },
                    new Game { GameState = GameState.Finished, Name = "A", RedUser = new User { Email = "Red" }, BlueUser = new User { UserName = "Blue" } },
                }.AsQueryable();
            });

            return repository.Object;
        }

        public static IRepository<User> GetUsersRepository()
        {
            var repository = new Mock<IRepository<User>>();

            repository.Setup(r => r.All()).Returns(() =>
            {
                return new List<User>
                {
                    new User { Email = "TestUser 1", Rank = 100 },
                    new User { Email = "TestUser 2", Rank = 50 },
                    new User { Email = "TestUser 4", Rank = 4500 },
                    new User { Email = "TestUser 3", Rank = 200 },
                    new User { Email = "TestUser 1", Rank = 100 },
                    new User { Email = "TestUser 2", Rank = 80 },
                    new User { Email = "TestUser 4", Rank = 3510 },
                    new User { Email = "TestUser 3", Rank = 200 },
                    new User { Email = "TestUser 1", Rank = 13450 },
                    new User { Email = "TestUser 2", Rank = 50 },
                    new User { Email = "TestUser 4", Rank = 3500 },
                    new User { Email = "TestUser 3", Rank = 500 },
                }.AsQueryable();
            });

            return repository.Object;
        }
    }
}
