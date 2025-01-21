namespace Hospital.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public string AppointmentDate { get; set; }
        public string AppointmentTime { get; set; }
        public string Status { get; set; }
    }
}
