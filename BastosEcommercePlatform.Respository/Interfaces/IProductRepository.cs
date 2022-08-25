﻿using BastosEcommercePlatform.Respository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BastosEcommercePlatform.Respository.Interfaces
{
    public  interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetByCategory(ProductCategory category);
    }
}
