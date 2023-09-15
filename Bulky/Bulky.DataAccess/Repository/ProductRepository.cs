using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models.Models;

namespace BulkyBook.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private AppDbContext _db;

        public ProductRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product obj)
        {
            //_db.Products.Update(obj);

            // We can be explicit
            var objFromDb = _db.Products.FirstOrDefault(u => u.Id == obj.Id);

            if(objFromDb != null)
            {
                objFromDb.Title = obj.Title;
                objFromDb.ISBN = obj.ISBN;
                objFromDb.Price = obj.Price;
                objFromDb.Price50 = obj.Price50;
                objFromDb.ListPrice = obj.ListPrice;
                objFromDb.Price100 = obj.Price100;
                objFromDb.Description = obj.Description;
                objFromDb.CategoryId = obj.CategoryId;
                objFromDb.Author = obj.Author;
                objFromDb.ProductImages = obj.ProductImages;
            }
        }
    }
}
