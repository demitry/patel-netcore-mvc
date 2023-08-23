using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BulkyBook.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _db;
        internal DbSet<T> dbSet;
        public Repository(AppDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
            //We need DbSet:
            // _db.Categories ==is== dbSet and _db.Categories.Add() becomes=> dbSet.Add()

            // _db.Products.Include(u => u.Category); 
            // Category will automatically been populated based on foreign key relation
            // It is included in ProductController by passing include property to the GetAll()
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        void IncludePropertiesForDbSet(ref IQueryable<T> query, string? includeProperties = null)
        {
            if (!string.IsNullOrEmpty(includeProperties))
            {
                var properties = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var includeProperty in properties)
                {
                    query = query.Include(includeProperty); // The property will automatically been populated based on foreign key relation
                }
            }
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);

            IncludePropertiesForDbSet (ref query, includeProperties);

            return query.FirstOrDefault();
        }

        // Category, or Cover 
        public IEnumerable<T> GetAll(string? includeProperties = null) // Case sensitive!
        {
            IQueryable<T> query = dbSet;

            IncludePropertiesForDbSet(ref query, includeProperties);

            return query.ToList();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }
}
