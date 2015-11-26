namespace Teleimot.Web.Wcf
{
    using Data.Models;
    using Teleimot.Data.Repositories;
    using Data;

    public abstract class BaseService
    {
        protected BaseService()
        {
            var db = new TeleimotDbContext();
            this.Users = new GenericRepository<User>(db);
        }

        protected IRepository<User> Users { get; private set; }
    }
}
