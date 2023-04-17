using FoodPanda.DataAccess.Repository.IRepository;
using FoodPanda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodPanda.DataAccess.Repository
{
    public class RestaurantRepository : Repository<Restaurant>, IRestaurantRepository
    {
        private ApplicationDbContext _db;
        public RestaurantRepository(ApplicationDbContext db):base(db)
        {
            _db=db  ;
            
        }
    

        public void Update(Restaurant obj)
        {
            _db.Restaurant.Update(obj);
        }
    }
}
