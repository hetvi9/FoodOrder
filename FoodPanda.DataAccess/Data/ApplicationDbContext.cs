using FoodPanda.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodPanda.DataAccess
{
    public class ApplicationDbContext :IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }
        public DbSet<Restaurant> Restaurant { get; set; }   
       public DbSet<FoodCatagory> FoodCatagorys { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
