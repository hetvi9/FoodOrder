using FoodPanda.DataAccess.Repository.IRepository;
using FoodPanda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodPanda.DataAccess.Repository
{
    public class ComapnyRepository : Repository<Company>, ICompanyRepository
    {
        private ApplicationDbContext _db;
        public ComapnyRepository(ApplicationDbContext db):base(db)
        {
            _db=db  ;
            
        }
    

        public void Update(Company obj)
        {
            _db.Companies.Update(obj);
        }
    }
}
