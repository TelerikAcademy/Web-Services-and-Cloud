namespace BullsAndCows.Services.Data.Contracts
{
    using System.Linq;
    using BullsAndCows.Data.Models;

    public interface IHighScoreService
    {
        void UpdateRank(string userId, bool won);

        IQueryable<User> GetLatest();
    }
}
