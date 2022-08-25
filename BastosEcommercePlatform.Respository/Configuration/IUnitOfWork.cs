using BastosEcommercePlatform.Respository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BastosEcommercePlatform.Respository.Configuration
{
    public interface IUnitOfWork
    {

       public IProductRepository ProductRepository { get;  }

        Task<bool> CompleteAsync();
    }
}
