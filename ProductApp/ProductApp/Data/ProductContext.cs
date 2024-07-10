using Microsoft.EntityFrameworkCore;
using ProductApp.Models;
using System.Collections.Generic;

namespace ProductApp.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
    }
}
