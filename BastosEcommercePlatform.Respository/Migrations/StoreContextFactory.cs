using BastosEcommercePlatform.Respository.Data;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BastosEcommercePlatform.Respository.Migrations
{
    public class StoreContextFactory : IDesignTimeDbContextFactory<StoreContext>
    {
        public StoreContext CreateDbContext(string[] args)
        {
            return new StoreContext(args[0]);
        }
    }
}
