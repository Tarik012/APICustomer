using APICustomer.Models;
using Microsoft.EntityFrameworkCore;

namespace APICustomer.Data
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;
    }
}
