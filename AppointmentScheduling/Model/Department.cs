using System.ComponentModel.DataAnnotations;

namespace AppointmentScheduling.Model
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string Specialities { get; set; }
        
    }
}
