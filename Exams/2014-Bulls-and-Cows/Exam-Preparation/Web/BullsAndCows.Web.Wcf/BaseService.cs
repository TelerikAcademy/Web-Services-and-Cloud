namespace BullsAndCows.Web.Wcf
{
    using Data.Models;
    using BullsAndCows.Data.Repositories;
    using Data;

    public abstract class BaseService
    {
        protected BaseService()
        {
            var db = new BullsAndCowsDbContext();
            this.Users = new GenericRepository<User>(db);
        }

        protected IRepository<User> Users { get; private set; }
    }
}
