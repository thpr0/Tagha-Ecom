using BastosEcommercePlatform.Respository.Data;
using BastosEcommercePlatform.Respository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BastosEcommercePlatform.Respository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        protected StoreContext context;

        protected DbSet<T> dbSet;

        public Repository(StoreContext cont)
        {
            context = cont ?? throw new ArgumentNullException(nameof(cont));
            dbSet = context.Set<T>();
        }

        public async Task<bool> Add(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public async Task<IEnumerable<T>> All()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<bool> Delete(int Id)
        {
            var entity = await dbSet.FindAsync(Id);

            if (entity != null)
            {
                dbSet.Remove(entity);
                return true;
            }
            return false;
        }

        public async Task<T> GetByeId(int Id)
        {
            return await dbSet.FindAsync(Id);
        }
    }
}
