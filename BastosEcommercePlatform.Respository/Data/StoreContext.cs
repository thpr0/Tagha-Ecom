using BastosEcommercePlatform.Respository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BastosEcommercePlatform.Respository.Data
{
    public class StoreContext : DbContext
    {

        public string  _connectionString { get; set; }

        public StoreContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        public StoreContext(DbContextOptions<StoreContext> options): base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder
            //  .UseSqlServer(
            //  _connectionString,
            //  sqlServerOptionsAction: sqlOptions =>
            //  {
            //      sqlOptions.EnableRetryOnFailure(
            //      maxRetryCount: 5,
            //      maxRetryDelay: TimeSpan.FromSeconds(30),
            //      errorNumbersToAdd: null);
            //  });

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());
        }
      
        public DbSet<Product> Products { get; set; }
    }
}
