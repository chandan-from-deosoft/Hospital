using TestBot.Model;

namespace TestBot.Repository
{
    public interface IAppointmentRepository
    {
        Task<AppointmentStatus> GetAppointmentsAsync(int appointmentId);
    }
}
