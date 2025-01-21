using Hospital.Models;

namespace Hospital.Repository
{
    public interface IAppointmentRepository<T> where T : class
    {
        Task<Appointment> GetAppointmentStatusAsync(int appointmentId);
    }
}
