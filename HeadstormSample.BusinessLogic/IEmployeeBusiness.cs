using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HeadstormSample.Model;

namespace HeadstormSample.BusinessLogic
{
    public interface IEmployeeBusiness
    {
        /// <summary>
        /// Get an employee entity by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns the found entity</returns>
        Task<Employee> GetEmployeeById(int id);
        /// <summary>
        /// Get all available entity in the database of type Employee
        /// </summary>
        /// <returns>Returns a list of Employee</returns>
        Task<ICollection<Employee>> GetAllEmployee();
        /// <summary>
        /// Add a new Employee into the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Returns the added Employee</returns>
        Task<Employee> AddEmployee(Employee entity);
        /// <summary>
        /// Update an employee with matching Id
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Returns the updated employee</returns>
        Task<Employee> UpdateEmployee(Employee entity);
        /// <summary>
        /// Remove an employee from the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Returns the removed employee</returns>
        Task<Employee> RemoveEmployee(Employee entity);
    }
}
