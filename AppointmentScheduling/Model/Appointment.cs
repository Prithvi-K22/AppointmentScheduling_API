using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppointmentScheduling.Model
{
    public class Appointment
    {
        [Key]
        [DisplayName("Id")]
        public int Appointment_Id { get; set; }
        public DateTime AppointmentDate { get; set; } = DateTime.Now;
        public string PatientName { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public double MobileNumber { get; set; }
        public string BloodGroup { get; set; }
        [DisplayName("Department")]
        public int Department_Id { get; set; }
        [DisplayName("Doctor")]
        public int Doctor_Id { get; set; }
        public string MaritalStatus { get; set; }
        
    }
}
