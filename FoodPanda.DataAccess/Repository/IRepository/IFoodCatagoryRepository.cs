using FoodPanda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodPanda.DataAccess.Repository.IRepository
{
    public interface IFoodCatagoryRepository : IRepository<FoodCatagory>   //Restaurant is class
    {
        void Update(FoodCatagory obj);
    
    }
}
