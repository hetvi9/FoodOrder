using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FoodPanda.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        //Here T - Restaurent
        //return type of first or default here is object
        T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null);   
        IEnumerable<T> GetAll(string? includeProperties = null);
        //object of class should be passed
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}
