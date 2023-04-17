using FoodPanda.DataAccess.Repository.IRepository;
using FoodPanda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodPanda.DataAccess.Repository
{
    public class FoodCatagoryRepository : Repository<FoodCatagory>, IFoodCatagoryRepository
    {
        private ApplicationDbContext _db;
        public FoodCatagoryRepository(ApplicationDbContext db):base(db)
        {
            _db=db  ;
            
        }
    

        public void Update(FoodCatagory obj)
        {
            _db.FoodCatagorys.Update(obj);
        }
    }
}
