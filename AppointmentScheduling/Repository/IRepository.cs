using AppointmentScheduling.Model;
using AppointmentScheduling.ViewModel;

namespace AppointmentScheduling.Repository
{
    public interface IRepository
    {
       
        List<Appointment> Get();
            Task<Appointment> Create(Appointment obj);
            void Delete(int Id);
            Task<Appointment> Update(AppointmentEditDetails request);
            Task<Appointment> GetById(int Id);
            Task<Appointment> Get(string PatientName);
        List<Department> DepartmentA();
        List<Doctor> DoctorA();
            List<Department> GetDepartment();
            List<Doctor> GetDoctor();
    }
}
