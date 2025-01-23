using System.Data;
using Dapper;
using TestBot.Model;

namespace TestBot.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly IDbConnection _dbConnection;

        public AppointmentRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<AppointmentStatus> GetAppointmentsAsync(int appointmentId)
        {
            // var query = "SELECT [appointment_id],[patient_name],[doctor_id],[appointment_time],[status] FROM [Hospital].[dbo].[appointment] WHERE appointment_id = @Id";
            var query = "SELECT [appointment_id] AS AppointmentId, [patient_name] AS PatientName, [doctor_id] AS DoctorId, [appointment_time] AS AppointmentTime, [status] AS Status FROM [Hospital].[dbo].[appointment] WHERE appointment_id = @Id\r\n";
            return await _dbConnection.QueryFirstOrDefaultAsync<AppointmentStatus>(query, new { Id = appointmentId });
        }
    }
}


