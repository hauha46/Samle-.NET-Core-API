using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HeadstormSample.Model;
using HeadstormSample.BusinessLogic;

namespace HeadstormSample.Controllers
{
    [Route("api/enrollment")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private IEnrollmentBusiness enrollmentBusiness;
        private IEmployeeBusiness employeeBusiness;
        private ISIGBusiness sIGBusiness;
        public EnrollmentController()
        {
            this.enrollmentBusiness = new EnrollmentBusiness();
            this.employeeBusiness = new EmployeeBusiness();
            this.sIGBusiness = new SIGBusiness();
        }

        /// <summary>
        /// Add a new enrollment into the database
        /// </summary>
        /// <param name="enrollment"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("add")]
        public async Task<ActionResult> AddEnrollment(Enrollment enrollment)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid Input");
            if (this.enrollmentBusiness.CheckDuplicate(enrollment).Result) return BadRequest("Enrollment existed");
            Enrollment response = await this.enrollmentBusiness.AddEnrollment(enrollment);
            return new ObjectResult(response){ StatusCode = StatusCodes.Status201Created};
        }

        /// <summary>
        /// Get all employee belong to a given SIGId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getEmployee/{id}")]
        public async Task<ActionResult<List<Employee>>> GetAllEmployeeInSIG(int id)
        {
            SIG check = await this.sIGBusiness.GetSIGById(id);
            if (check == null) return BadRequest("Invalid Input");
            var response = await this.enrollmentBusiness.GetAllEmployeeInSIG(id);
            return Ok(response);
        }

        /// <summary>
        /// Get all SIG participated by the given EmployeeId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getSIG/{id}")]
        public async Task<ActionResult<List<SIG>>> GetAllSIGFromEmployee(int id)
        {
            Employee check = await this.employeeBusiness.GetEmployeeById(id);
            if (check == null) return BadRequest("Invalid Input");
            var response = await this.enrollmentBusiness.GetAllSIGFromEmployee(id);
            return Ok(response);
        }

        /// <summary>
        /// Remove an enrollment from the database
        /// </summary>
        /// <param name="enrollment"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult> RemoveEnrollment(Enrollment enrollment)
        {
            Enrollment response = await this.enrollmentBusiness.RemoveEnrollment(enrollment);
            return Ok(response);
        }
    }
}
