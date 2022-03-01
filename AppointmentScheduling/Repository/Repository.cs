using AppointmentScheduling.Data;
using AppointmentScheduling.Model;
using AppointmentScheduling.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentScheduling.Repository
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _db;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
        }


        //GET
        public List<Appointment> Get()
        {
            var AppointmentList = _db.Appointments.ToList();
            return AppointmentList;
        }
        public List<Department> DepartmentA()
        {
            var DepartmentList = _db.Departments.ToList();
            return DepartmentList;
        }
        public List<Doctor> DoctorA()
        {
            var DoctorList = _db.Doctors.ToList();
            return DoctorList;
        }




        public async Task<Appointment> Create(Appointment obj)
        {
            var result = _db.Appointments.Add(obj);
            _db.SaveChanges();
            return result.Entity;
        }

        public void Delete(int Id)
        {
            var AppointmentDb = _db.Appointments.Find(Id);
            _db.Appointments.Remove(AppointmentDb);
            _db.SaveChanges();
        }

        public async Task<Appointment> Update(AppointmentEditDetails request)
        {
            var HospitalDb = _db.Appointments.Find(request.Appointment_Id);
            HospitalDb.PatientName = request.PatientName;
            HospitalDb.Gender = request.Gender;
            HospitalDb.Address = request.Address;
            HospitalDb.MobileNumber = request.MobileNumber;
            HospitalDb.Department_Id = request.Department_Id;
            HospitalDb.Doctor_Id = request.Doctor_Id;
            _db.Appointments.Update(HospitalDb);
            _db.SaveChanges();
            return HospitalDb;
        }



        public async Task<Appointment> GetById(int Id)
        {
            var AppointmentsDb = _db.Appointments.Find(Id);
            return AppointmentsDb;
        }
        public async Task<Appointment> Get(string PatientName)
        {
            var result1 = _db.Appointments.FirstOrDefault(m => m.PatientName == PatientName);
            return result1;
        }


        public List<Department> GetDepartment()
        {
            var DepartmentList = _db.Departments.ToList();
            return DepartmentList;
        }
        public List<Doctor> GetDoctor()
        {
            var DoctorList = _db.Doctors.ToList();
            return DoctorList;
        }
    }
}
