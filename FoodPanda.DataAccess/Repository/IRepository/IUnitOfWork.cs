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
        ICompanyRepository Company { get; }
        IShoppingCartRepository ShoppingCart { get; }
        IApplicationUserRepository ApplicationUser { get; }
        IOrderHeaderRepository OrderHeader { get; }
        IOrderDetailRepository OrderDetail { get; }


        void Save();
    }
}
