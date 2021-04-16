using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HeadstormSample.Model;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HeadstormSample.DataAccess
{
    public class Repository<T> : IRepository<T> where T: class
    {
        private HeadstormSampleContext _context;
        public Repository(HeadstormSampleContext context)
        {
            this._context = context;
        }

        public async Task<T> Add(T entity)
        {
            this._context.Set<T>().Add(entity);
            await this._context.SaveChangesAsync();
            return entity; 
        }

        public async Task<ICollection<T>> GetAll()
        {     
            return await this._context.Set<T>().ToListAsync(); 
        }

        public async Task<T> GetById(int id) 
        {
            return await this._context.Set<T>().FindAsync(id);
        }

        public async Task<T> Remove(T entity)
        {
            this._context.Set<T>().Remove(entity);
            await this._context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            this._context.Set<T>().Update(entity);
            await this._context.SaveChangesAsync();
            return entity;
        }
    }
}
