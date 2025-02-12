using Microsoft.EntityFrameworkCore;
using ProductService.API.Models.Entities;

namespace ProductService.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Product> Product { get; set; }
    }
}
