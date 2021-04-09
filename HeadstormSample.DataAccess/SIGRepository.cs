using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HeadstormSample.Model;
using Microsoft.EntityFrameworkCore;

namespace HeadstormSample.DataAccess
{
    public class SIGRepository : IRepository<SIG>
    {
        private HeadstormSampleContext _context;
        public SIGRepository()
        {
            this._context = new HeadstormSampleContext();
        }

        public async Task<SIG> Add(SIG entity)
        {
            this._context.SIGs.Add(entity);
            await this._context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<SIG>> GetAll()
        {
            return await this._context.SIGs.ToListAsync();
        }

        public async Task<SIG> GetById(int id)
        {
            return await this._context.SIGs.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<SIG> Remove(SIG entity)
        {
            this._context.SIGs.Remove(entity);
            await this._context.SaveChangesAsync();
            return entity;
        }

        public async Task<SIG> Update(SIG entity)
        {
            this._context.Update(entity);
            await this._context.SaveChangesAsync();
            return entity;
        }
    }
}
