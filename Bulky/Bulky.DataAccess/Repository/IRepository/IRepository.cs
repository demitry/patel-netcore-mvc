using System.Linq.Expressions;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        // T = Category
        IEnumerable<T> GetAll(string? includeProperties = null);
        T Get(Expression<Func<T, bool>> filter, string? includeProperties = null);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

        //void Update(T entity);
        //NB!
        //in Edit(), we also call _db.SaveChanges();
        //In generic repository we don't like to have Update() and Add()
        //The reason is simple: Updating a Category could differ from updating a Product or something else 
        //So keep Update and SaveChanges **OUT of REPO**

    }
}
