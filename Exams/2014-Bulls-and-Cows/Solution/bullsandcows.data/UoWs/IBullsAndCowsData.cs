namespace BullsAndCows.Data.UoWs
{
    using BullsAndCows.Data.Repositories;
    using BullsAndCows.Entities;

    public interface IBullsAndCowsData
    {
        IRepository<User> Users { get; }

        IRepository<Game> Games { get; }

        IRepository<Guess> Guesses { get; }

        IRepository<UserScore> UserScores { get; }

        IRepository<Notification> Notifications { get; }
        
        int SaveChanges();
    }
}
