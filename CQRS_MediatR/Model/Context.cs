using Microsoft.EntityFrameworkCore;

namespace CQRS_MediatR.Model
{
    public class Context :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;User Id=postgres;Port=5432;Password=123456;Database=CQRS;Pooling=true; Integrated Security =true;");

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
