using BastosEcommercePlatform.Respository.Data;
using BastosEcommercePlatform.Respository.Interfaces;
using BastosEcommercePlatform.Respository.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BastosEcommercePlatform.Respository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {

        public ProductRepository(StoreContext context): base(context) 
        {

        }

        public async Task<IEnumerable<Product>> GetByCategory(ProductCategory category)
        {
            return await dbSet.Where(p => p.Category == category).ToListAsync();
        }
    }
}
