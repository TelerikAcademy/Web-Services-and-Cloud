namespace BullsAndCows.Services.Data
{
    using System.Linq;
    using BullsAndCows.Data.Models;
    using BullsAndCows.Services.Data.Contracts;
    using BullsAndCows.Data.Repositories;
    using Common.Constants;

    public class HighScoreService : IHighScoreService
    {
        private readonly IRepository<User> users;

        public HighScoreService(IRepository<User> users)
        {
            this.users = users;
        }

        public void UpdateRank(string userId, bool won)
        {
            var user = this.users.GetById(userId);

            if (won)
            {
                user.Rank += GameConstants.ScorePerWin;
            }
            else
            {
                user.Rank += GameConstants.ScorePerLose;
            }

            this.users.SaveChanges();
        }

        public IQueryable<User> GetLatest()
        {
            return this.users
                .All()
                .OrderByDescending(u => u.Rank)
                .Take(GameConstants.HighScoreUsersCount);
        }
    }
}
