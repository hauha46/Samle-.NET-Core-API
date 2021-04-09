using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HeadstormSample.Model;

namespace HeadstormSample.BusinessLogic
{
    public interface IEnrollmentBusiness
    {
        /// <summary>
        /// Check whether the given enrollment exists or not
        /// </summary>
        /// <param name="enrollment"></param>
        /// <returns>Returns true if the enrollment exist, false if the enrollment doesn't</returns>
        Task<Boolean> CheckDuplicate(Enrollment enrollment);
        /// <summary>
        /// Find the enrollment with given EmployeeId and SIGId
        /// </summary>
        /// <param name="EmployeeId"></param>
        /// <param name="SIGId"></param>
        /// <returns>Returns the found enrollment</returns>
        Task<Enrollment> GetEnrollment(int EmployeeId, int SIGId);
        /// <summary>
        /// Add a new enrollment into the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Returns the added enrollment</returns>
        Task<Enrollment> AddEnrollment(Enrollment entity);
        /// <summary>
        /// Get all employee belong to a given SIGId
        /// </summary>
        /// <param name="SIGId"></param>
        /// <returns>Returns a list of employee participate in the given SIG</returns>
        Task<List<Employee>> GetAllEmployeeInSIG(int SIGId);
        /// <summary>
        /// Get all SIG that an employee participates in with given EmployeeId
        /// </summary>
        /// <param name="EmployeeId"></param>
        /// <returns>Returns a list of SIG participated by the given employee</returns>
        Task<List<SIG>> GetAllSIGFromEmployee(int EmployeeId);
        /// <summary>
        /// Remove an enrollment from the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Returns removed enrollment</returns>
        Task<Enrollment> RemoveEnrollment(Enrollment entity);

    }
}
