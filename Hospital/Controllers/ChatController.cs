using Microsoft.AspNetCore.Mvc;
using TestBot.Repository;

namespace TestBot.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public async Task<IActionResult> GetChatDataByType(string type)
        {
            int chatId;

            // Map types to their corresponding ChatIds
            switch (type.ToLower())
            {
                case "welcome":
                    chatId = 1; // ChatId for "welcome"
                    break;
                case "mainmenu":
                    chatId = 4; // ChatId for "mainMenu"
                    break;
                default:
                    return BadRequest(new { Message = $"Invalid type: {type}" });
            }

            var chatMessage = await _chatMessageRepository.GetChatMessageAsync(chatId);

            if (chatMessage == null)
            {
                return NotFound(new { Message = $"No data found for ChatId {chatId}" });
            }

            return Ok(new { Message = chatMessage });
        }

        [HttpGet("buttons/{chatDataId}")]
        public async Task<IActionResult> GetChatButtonById(int chatDataId)
        {
            var chatButton = await _chatButtonRepository.GetChatButtonAsync(chatDataId);
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
