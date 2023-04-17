using FoodPanda.DataAccess.Repository.IRepository;
using FoodPanda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodPanda.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;

        }


        public void Update(Product obj)
        {
            var objFromDb = _db.Products.FirstOrDefault(u => u.Id == obj.Id);
            {
                if (objFromDb != null)
                {
                    objFromDb.ProductName = obj.ProductName;
                    objFromDb.Price = obj.Price;
                    objFromDb.Description = obj.Description;
                    objFromDb.RestaurantId = obj.RestaurantId;
                    objFromDb.FoodCatagoryId = obj.FoodCatagoryId;
                    if (obj.ImageUrl != obj.ImageUrl)
                    {
                        objFromDb.ImageUrl = obj.ImageUrl;
                    }
                }
            }
        }
    }
}
