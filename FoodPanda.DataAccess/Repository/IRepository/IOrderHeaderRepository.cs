using FoodPanda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodPanda.DataAccess.Repository.IRepository
{
    public interface IOrderHeaderRepository : IRepository<OrderHeader>   //Restaurant is class
    {
        void Update(OrderHeader obj);
        void UpdateStatus(int id, string orderStatus, string? paymentStatus = null);
    
    }
}
