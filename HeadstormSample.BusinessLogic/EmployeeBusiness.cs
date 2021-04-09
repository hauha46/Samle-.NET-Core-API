using HeadstormSample.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HeadstormSample.DataAccess;

namespace HeadstormSample.BusinessLogic
{
    public class EmployeeBusiness : IEmployeeBusiness
    {
        IRepository<Employee> employeeRepository;
        public EmployeeBusiness()
        {
            this.employeeRepository = new EmployeeRepository();
        }
        public async Task<Employee> AddEmployee(Employee entity)
        {
            return await this.employeeRepository.Add(entity);
        }

        public async Task<List<Employee>> GetAllEmployee()
        {
            return await this.employeeRepository.GetAll();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await this.employeeRepository.GetById(id);
        }

        public async Task<Employee> RemoveEmployee(Employee entity)
        {
            return await this.employeeRepository.Remove(entity);
        }

        public async Task<Employee> UpdateEmployee(Employee entity)
        {
            return await this.employeeRepository.Update(entity);
        }
    }
}
