using Microsoft.AspNetCore.Mvc;
using AppointmentScheduling.Data;
using AppointmentScheduling.Model;
using AppointmentScheduling.ViewModel;
using System.Net;
using AppointmentScheduling.Repository;

namespace AppointmentScheduling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IRepository _db;
        private readonly object? ObjAppointmentList;


        public AppointmentController(IRepository db)
        {
            _db = db;
        }

        //Edited 1 line mmm
        [HttpGet]
        public List<AppointmentResultViewModel> Get()
        {
            try
            {
                var ObjAppointmentList = _db.Get();
                var DepartmentList = _db.DepartmentA();
                var DoctorList = _db.DoctorA();

                var result = from a in ObjAppointmentList
                             join d in DepartmentList
                             on a.Department_Id equals d.Id
                             join d1 in DoctorList
                             on a.Doctor_Id equals d1.Id

                             select new AppointmentResultViewModel
                             {
                                 Appointment_Id = a.Appointment_Id,
                                 AppointmentDate = a.AppointmentDate,
                                 PatientName = a.PatientName,
                                 Gender = a.Gender,
                                 Address = a.Address,
                                 MobileNumber = a.MobileNumber,
                                 BloodGroup = a.BloodGroup,
                                 MaritalStatus = a.MaritalStatus,
                                 Department_Id = d.Specialities,
                                 Doctor_Id = d1.Name
                             };
                return (result.ToList());
            }
            catch (Exception)
            {
                return null;
            }
        }


        [HttpPost]
        public IActionResult Create(Appointment obj)
        {
            try
            {
                var result = _db.Create(obj);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error while creating new Appointment");
            }
        }


        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                _db.Delete(Id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in deleting data");
            }
        }


        [HttpGet("{Id:int}")]
        public async Task<ActionResult<Appointment>> GetById(int Id)
        {
            try
            {
                var AppointmentsDb = _db.GetById(Id);
                var AppointmentList = _db.Get();
                var DepartmentList = _db.DepartmentA();
                var DoctorList = _db.DoctorA();

                var result = from a in AppointmentList
                             join d in DepartmentList
                             on a.Department_Id equals d.Id
                             join d1 in DoctorList
                             on a.Doctor_Id equals d1.Id

                             select new AppointmentResultViewModel
                             {
                                 Appointment_Id = a.Appointment_Id,
                                 AppointmentDate = a.AppointmentDate,
                                 PatientName = a.PatientName,
                                 Gender = a.Gender,
                                 Address = a.Address,
                                 MobileNumber = a.MobileNumber,
                                 BloodGroup = a.BloodGroup,
                                 MaritalStatus = a.MaritalStatus,
                                 Department_Id = d.Specialities,
                                 Doctor_Id = d1.Name
                             };
                var result1 = result.First(i => i.Appointment_Id == Id);
                return Ok(result1);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in deleting data");
            }

        }


        [HttpGet("{PatientName}")]
        public async Task<ActionResult<Appointment>> Get(string PatientName)
        {
            var AppointmentsDb = _db.Get();
            var AppointmentList = _db.Get();
            var DepartmentList = _db.DepartmentA();
            var DoctorList = _db.DoctorA();

            var result = from a in AppointmentList
                         join d in DepartmentList
                         on a.Department_Id equals d.Id
                         join d1 in DoctorList
                         on a.Doctor_Id equals d1.Id

                         select new AppointmentResultViewModel
                         {
                             Appointment_Id = a.Appointment_Id,
                             AppointmentDate = a.AppointmentDate,
                             PatientName = a.PatientName,
                             Gender = a.Gender,
                             Address = a.Address,
                             MobileNumber = a.MobileNumber,
                             BloodGroup = a.BloodGroup,
                             MaritalStatus = a.MaritalStatus,
                             Department_Id = d.Specialities,
                             Doctor_Id = d1.Name
                         };
            return Ok(result.FirstOrDefault(a => a.PatientName == PatientName));  //PatientName error


        }

        [HttpPost]
        [Route("edit")]
        public async Task<ActionResult<Appointment>> Update(AppointmentEditDetails request)
        {
            try
            {
                _db.Update(request);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error in updating data");
            }
        }



        [HttpGet]
        [Route("Department/[controller]")]
        public IActionResult GetDepartment()
        {
            var DepartmentList = _db.GetDepartment();
            return Ok(DepartmentList);
        }

        [HttpGet]
        [Route("Doctors/[controller]")]
        public IActionResult GetDoctor()
        {
            var DoctorList = _db.GetDoctor();
            return Ok(DoctorList);
        }


    }
}
