using Microsoft.AspNetCore.Mvc;
using TestBot.Repository;

namespace TestBot.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly IChatMessageRepository _chatMessageRepository;
        private readonly IChatButtonRepository _chatButtonRepository;
        private readonly IAppointmentRepository _appointmentRepository;

        public ChatController(IChatMessageRepository chatMessageRepository, IChatButtonRepository chatButtonRepository, IAppointmentRepository appointmentRepository)
        {
            _chatMessageRepository = chatMessageRepository;
            _chatButtonRepository = chatButtonRepository;
            _appointmentRepository = appointmentRepository;
        }


        [HttpGet("Greet")]
        public async Task<IActionResult> GetGreetingMessage()
        {
            var message = await _chatMessageRepository.GetGreetingMessageAsync();

            return Ok(new { Message = message });
        }

        [HttpGet("{type}")]
        public async Task<IActionResult> GetChatData(string type)
        {
            try
            {
                // Map types to their corresponding ChatIds
                int chatId = type.ToLower() switch
                {
                    "welcome" => 1,
                    "mainmenu" => 4,
                    _ => -1 // Assign -1 or some invalid value for unsupported types
                };

                if (chatId == -1)
                {
                    return BadRequest(new { Message = $"Invalid type: {type}" });
                }

                var chatMessage = await _chatMessageRepository.GetChatData(chatId);

                if (chatMessage == null)
                {
                    return NotFound(new { Message = $"No data found for ChatId {chatId}" });
                }

                return Ok(chatMessage); // Return the data directly as JSON
            }
            catch (Exception ex)
            {
                // Log the error and return a server error response
                Console.Error.WriteLine(ex.Message);
                return StatusCode(500, new { Message = "Server Error" });
            }
        }


        [HttpGet("buttons/{chatDataId}")]
        public async Task<IActionResult> GetOptionsData(int chatDataId)
        {
            var chatButton = await _chatButtonRepository.GetOptionsData(chatDataId);
            if (chatButton == null)
            {
                return NotFound(new { Message = $"No data found for ChatId {chatDataId}" });
            }
            return Ok(chatButton);
        }

        [HttpGet("appointmentStatus/{appointmentStatusId}")]
        public async Task<IActionResult> GetAppointmentStatus(int appointmentStatusId)
        {
            var appointmentStatus = await _appointmentRepository.GetAppointmentsAsync(appointmentStatusId);
            if (appointmentStatus == null)
            {
                return NotFound(new { Message = $"No data found for AppointmentId {appointmentStatusId}" });
            }
            return Ok(appointmentStatus);
        }

    }
}
