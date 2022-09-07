using Microsoft.EntityFrameworkCore;
using GlobalExceptionHandling.Models;


namespace GlobalExceptionHandling.Data {
    public class DbContextClass: DbContext{
        protected readonly IConfiguration _Configuration;
        public DbContextClass(IConfiguration configuration)
        {
            this._Configuration=configuration;
        }
        protected override void OnConfiguring( DbContextOptionsBuilder options){
            options.UseSqlServer(_Configuration.GetConnectionString("DefaultConnection"));
        }
        public DbSet<Product> Products { get; set; }
    }
}