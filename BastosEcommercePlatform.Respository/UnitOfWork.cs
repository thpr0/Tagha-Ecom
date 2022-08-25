using BastosEcommercePlatform.Respository.Configuration;
using BastosEcommercePlatform.Respository.Data;
using BastosEcommercePlatform.Respository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BastosEcommercePlatform.Respository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly StoreContext _context;

        public UnitOfWork(StoreContext context)
        {
            _context = context;
        }

        IProductRepository IUnitOfWork.ProductRepository { get => new ProductRepository(_context); }

        public async Task<bool> CompleteAsync()
        {
            return await _context.SaveChangesAsync() > 1;

        }

        public void Dispose()
        {
            _context.DisposeAsync();
        }
    }
}
