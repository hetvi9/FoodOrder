using FoodPanda.DataAccess.Repository.IRepository;
using FoodPanda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodPanda.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db) 
        {
            _db = db;
            Restaurant = new RestaurantRepository(_db);
            FoodCatagory = new FoodCatagoryRepository(_db);
            Product = new ProductRepository(_db);
            Company = new ComapnyRepository(_db);
        }
        public IRestaurantRepository Restaurant { get; private set; }
         public IFoodCatagoryRepository FoodCatagory { get; private set; }
        public IProductRepository Product { get; private set; }
        public ICompanyRepository Company { get; private set; } 

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
