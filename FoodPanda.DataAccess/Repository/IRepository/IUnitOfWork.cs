using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodPanda.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IRestaurantRepository Restaurant { get; }
        IFoodCatagoryRepository FoodCatagory { get; }

        IProductRepository Product { get; }

        void Save();
    }
}
