namespace Teleimot.Services.Data.Contracts
{
    using System.Linq;
    using Teleimot.Data.Models;

    public interface IUsersService
    {
        IQueryable<User> GetByUserName(string username);

        void Rate(Rating rating);
    }
}
