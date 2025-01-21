using System.Data;
using Dapper;
using Hospital.Models;
using Microsoft.Data.SqlClient; // Use Microsoft.Data.SqlClient for SQL Server


namespace Hospital.Repository
{
    public class AppointmentRepository : IAppointmentRepository<Appointment>
    {
        private readonly IDbConnection _dbConnection;

        public AppointmentRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Appointment> GetAppointmentStatusAsync(int appointmentId)
        {
            const string query = @"SELECT
                                a.appointment_id AS AppointmentId,
                                a.patient_name AS PatientName,
                                d.name AS DoctorName,
                                FORMAT(a.appointment_time, 'yyyy-MM-dd') AS AppointmentDate,
                                FORMAT(a.appointment_time, 'hh:mm tt') AS AppointmentTime,
                                a.status AS Status
                              FROM Appointments a
                              JOIN Doctors d ON a.doctor_id = d.doctor_id
                              WHERE a.appointment_id = @AppointmentId";

            return await _dbConnection.QuerySingleOrDefaultAsync<Appointment>(query, new { AppointmentId = appointmentId });
        }
    }
}
