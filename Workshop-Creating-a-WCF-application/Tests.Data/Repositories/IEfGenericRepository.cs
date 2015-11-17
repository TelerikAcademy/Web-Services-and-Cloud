using System.Linq;

namespace Tests.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        IQueryable<T> All();
        T Attach(T entity);
        void Delete(T entity);
        void Delete(object id);
        void Detach(T entity);
        void Dispose();
        T GetById(object id);
        int SaveChanges();
        void Update(T entity);
    }
}