namespace TestBot.Model
{
    public class AppointmentStatus
    {
        public int AppointmentId { get; set; }
        public string PatientName { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentTime { get; set; }
        public string Status { get; set; }
    }
}
