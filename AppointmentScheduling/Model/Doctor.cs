using System.ComponentModel.DataAnnotations;

namespace AppointmentScheduling.Model
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
