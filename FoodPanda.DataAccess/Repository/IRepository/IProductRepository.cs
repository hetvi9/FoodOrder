using FoodPanda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodPanda.DataAccess.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>   //Restaurant is class
    {
        void Update(Product obj);
    
    }
}
