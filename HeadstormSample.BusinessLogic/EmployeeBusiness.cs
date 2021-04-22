using HeadstormSample.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HeadstormSample.DataAccess;

namespace HeadstormSample.BusinessLogic
{
    public class EmployeeBusiness : IEmployeeBusiness
    {
        private IRepository<Employee> _employeeRepository;

        public EmployeeBusiness(IRepository<Employee> employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }
        public async Task<Employee> AddEmployee(Employee entity)
        {
            return await this._employeeRepository.Add(entity);
        }

        public async Task<ICollection<Employee>> GetAllEmployee()
        {
            return await this._employeeRepository.GetAll();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await this._employeeRepository.GetById(id);
        }

        public async Task<Employee> RemoveEmployee(Employee entity)
        {
            return await this._employeeRepository.Remove(entity);
        }

        public async Task<Employee> UpdateEmployee(Employee entity)
        {
            return await this._employeeRepository.Update(entity);
        }
    }
}
