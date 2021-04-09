using HeadstormSample.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HeadstormSample.DataAccess;
using System.Linq;

namespace HeadstormSample.BusinessLogic
{
    public class EnrollmentBusiness : IEnrollmentBusiness
    {
        IRepository<Enrollment> enrollmentRepository;
        public EnrollmentBusiness()
        {
            this.enrollmentRepository = new EnrollmentRepository();
        }

        public async Task<Boolean> CheckDuplicate(Enrollment enrollment)
        {
            List<Enrollment> enrollments = await enrollmentRepository.GetAll();
            return enrollments.Where(i => i.EmployeeId == enrollment.EmployeeId && i.SIGId == enrollment.SIGId).FirstOrDefault() != null ? true : false;
        }
        public async Task<Enrollment> AddEnrollment(Enrollment entity)
        {
            return await this.enrollmentRepository.Add(entity);
        }

        public async Task<List<Employee>> GetAllEmployeeInSIG(int SIGId)
        {
            List<Enrollment> enrollments = await enrollmentRepository.GetAll();
            List<Employee> employees = (from enrollment in enrollments where enrollment.SIGId == SIGId select enrollment.Employee).ToList();
            return employees;
        }

        public async Task<List<SIG>> GetAllSIGFromEmployee(int EmployeeId)
        {
            List<Enrollment> enrollments = await enrollmentRepository.GetAll();
            List<SIG> SIGs = (from enrollment in enrollments where enrollment.EmployeeId == EmployeeId select enrollment.SIG).ToList();
            return SIGs;
        }

        public async Task<Enrollment> GetEnrollment(int EmployeeId, int SIGId)
        {
            List<Enrollment> enrollments = await enrollmentRepository.GetAll();
            return enrollments.FirstOrDefault(i => i.EmployeeId == EmployeeId && i.SIGId == SIGId);
        }

        public async Task<Enrollment> RemoveEnrollment(Enrollment entity)
        {
            return await this.enrollmentRepository.Remove(entity);
        }
    }
}
