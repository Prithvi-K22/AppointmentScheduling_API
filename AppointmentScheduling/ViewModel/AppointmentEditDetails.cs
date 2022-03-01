namespace AppointmentScheduling.ViewModel
{
    public class AppointmentEditDetails
    {
        public int Appointment_Id { get; set; }
        public string? PatientName { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public double MobileNumber { get; set; }
        public int Department_Id { get; set; }
        public int Doctor_Id { get; set; }
    }
}
