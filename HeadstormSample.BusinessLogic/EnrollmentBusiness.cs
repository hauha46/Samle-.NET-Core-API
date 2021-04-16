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
        private IRepository<Enrollment> _enrollmentRepository;
        public EnrollmentBusiness(IRepository<Enrollment> enrollmentRepository)
        {
            this._enrollmentRepository = enrollmentRepository;
        }

        public async Task<Boolean> CheckDuplicate(Enrollment enrollment)
        {
            ICollection<Enrollment> enrollments = await _enrollmentRepository.GetAll();
            return enrollments.Where(i => i.EmployeeId == enrollment.EmployeeId && i.SIGId == enrollment.SIGId).FirstOrDefault() != null ? true : false;
        }
        public async Task<Enrollment> AddEnrollment(Enrollment entity)
        {
            return await this._enrollmentRepository.Add(entity);
        }

        public async Task<ICollection<Employee>> GetAllEmployeeInSIG(int SIGId)
        {
            ICollection<Enrollment> enrollments = await _enrollmentRepository.GetAll();
            List<Employee> employees = enrollments.Where(i => i.SIGId == SIGId).Select(i => i.Employee).ToList();
            //List<Employee> employees = (from enrollment in enrollments where enrollment.SIGId == SIGId select enrollment.Employee).ToList();
            return employees;
        }

        public async Task<ICollection<SIG>> GetAllSIGFromEmployee(int EmployeeId)
        {
            ICollection<Enrollment> enrollments = await _enrollmentRepository.GetAll();
            List<SIG> SIGs = enrollments.Where(i => i.EmployeeId == EmployeeId).Select(i => i.SIG).ToList();
            //List<SIG> SIGs = (from enrollment in enrollments where enrollment.EmployeeId == EmployeeId select enrollment.SIG).ToList();
            return SIGs;
        }

        public async Task<Enrollment> GetEnrollment(int EmployeeId, int SIGId)
        {
            ICollection<Enrollment> enrollments = await _enrollmentRepository.GetAll();
            return enrollments.FirstOrDefault(i => i.EmployeeId == EmployeeId && i.SIGId == SIGId);
        }

        public async Task<Enrollment> RemoveEnrollment(Enrollment entity)
        {
            return await this._enrollmentRepository.Remove(entity);
        }
    }
}
