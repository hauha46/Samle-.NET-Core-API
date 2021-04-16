using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HeadstormSample.BusinessLogic;
using HeadstormSample.Model;

namespace HeadstormSample.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeBusiness _employeeBusiness;
        public EmployeeController(EmployeeBusiness employeeBusiness)
        {
            this._employeeBusiness = employeeBusiness;
        }

        /// <summary>
        /// Add en employee into the database
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("add")]
        public async Task<ActionResult> AddEmployee(Employee employee)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid Input");
            Employee response = await this._employeeBusiness.AddEmployee(employee);
            return new ObjectResult(response) { StatusCode = StatusCodes.Status201Created };
        }

        /// <summary>
        /// Get the employee with the given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            Employee response =  await this._employeeBusiness.GetEmployeeById(id);
            return Ok(response);
        }

        /// <summary>
        /// Get all available Employee
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetAllEmployee()
        {
            var response = await this._employeeBusiness.GetAllEmployee();
            return Ok(response);
        }
        /// <summary>
        /// Update an employee with matching Id
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("update")]
        public async Task<ActionResult> UpdateEmployee(Employee employee)
        {
            Employee check = await this._employeeBusiness.GetEmployeeById(employee.Id);
            if (check == null) return BadRequest("Invalid Input");
            Employee response = await this._employeeBusiness.UpdateEmployee(employee);
            return Ok(response);
        }

        /// <summary>
        /// Remove an employee from the database
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete")]
        public async Task<ActionResult> RemoveEmployee(Employee employee)
        {
            Employee check = await this._employeeBusiness.GetEmployeeById(employee.Id);
            if (check == null) return BadRequest("Invalid Input");
            Employee reponse = await this._employeeBusiness.RemoveEmployee(employee);
            return Ok(reponse);
        }

    }
}
