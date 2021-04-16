using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HeadstormSample.Model;
using Microsoft.EntityFrameworkCore;

namespace HeadstormSample.DataAccess
{
    public class EnrollmentRepository : IRepository<Enrollment>
    {
        private HeadstormSampleContext _context;
        public EnrollmentRepository(HeadstormSampleContext context)
        {
            this._context = context;
        }

        public async Task<Enrollment> Add(Enrollment entity)
        {
            this._context.Enrollments.Add(entity);
            await this._context.SaveChangesAsync();
            return entity;
        }

        public async Task<ICollection<Enrollment>> GetAll()
        {
            return await this._context.Enrollments.Include(i => i.Employee).Include(i => i.SIG).ToListAsync();
        }

        public async Task<Enrollment> GetById(int id)
        {
            return await this._context.Enrollments.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Enrollment> Remove(Enrollment entity)
        {
            this._context.Enrollments.Remove(entity);
            await this._context.SaveChangesAsync();
            return entity;
        }

        public async Task<Enrollment> Update(Enrollment entity)
        {
            this._context.Update(entity);
            await this._context.SaveChangesAsync();
            return entity;
        }
    }
}
