namespace AppointmentScheduling.ViewModel
{
    public class AppointmentResultViewModel
    {
        public int Appointment_Id { get; set; }
        public DateTime AppointmentDate { get; set; } = DateTime.Now;
        public string PatientName { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public double MobileNumber { get; set; }
        public string BloodGroup { get; set; }
        public string Department_Id { get; set; }
        public string Doctor_Id { get; set; }
        public string MaritalStatus { get; set; }

    }
}
