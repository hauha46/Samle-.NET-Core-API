using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HeadstormSample.Model;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HeadstormSample.DataAccess
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private HeadstormSampleContext _context;
        public EmployeeRepository(HeadstormSampleContext context)
        {
            this._context = context;
        }

        public async Task<Employee> Add(Employee entity)
        {
            this._context.Employees.Add(entity);
            await this._context.SaveChangesAsync();
            return entity; 
        }

        public async Task<ICollection<Employee>> GetAll()
        {     
            return await this._context.Employees.ToListAsync(); 
        }

        public async Task<Employee> GetById(int id) 
        {
            return await this._context.Employees.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Employee> Remove(Employee entity)
        {
            this._context.Employees.Remove(entity);
            await this._context.SaveChangesAsync();
            return entity;
        }

        public async Task<Employee> Update(Employee entity)
        {
            this._context.Update(entity);
            await this._context.SaveChangesAsync();
            return entity;
        }
    }
}
