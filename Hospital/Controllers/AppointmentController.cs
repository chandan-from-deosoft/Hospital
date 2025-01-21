using Hospital.Models;
using Hospital.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    [Route("api/[controller]")]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentRepository<Appointment> _appointmentRepository;

        public AppointmentController(IAppointmentRepository<Appointment> appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        [HttpPost("status")]
        public async Task<IActionResult> GetAppointmentStatus([FromBody] int appointmentId)
        {
            if (appointmentId <= 0)
            {
                return BadRequest(new { error = "Invalid Appointment ID" });
            }

            var appointment = await _appointmentRepository.GetAppointmentStatusAsync(appointmentId);
            if (appointment == null)
            {
                return NotFound(new { error = "Appointment not found" });
            }

            return Ok(appointment);
        }
    }
}
