using Microsoft.AspNetCore.Mvc;
using TestBot.Repository;

namespace TestBot.Controllers
{
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


        [HttpGet]
        public async Task<IActionResult> GetChatData(int chatId)
        {
            var chatMsg = await _chatMessageRepository.GetChatData(chatId);
            if (chatMsg == null)
            {
                return NotFound(new { Message = $"No data found for ChatId {chatId}" });
            }
            return Ok(chatMsg);
        }


        [HttpGet]
        public async Task<IActionResult> GetOptionsData(int chatId)
        {
            var chatButton = await _chatButtonRepository.GetOptionsData(chatId);
            if (chatButton == null)
            {
                return NotFound(new { Message = $"No data found for ChatId {chatId}" });
            }
            return Ok(chatButton);
        }

        [HttpGet]
        public async Task<IActionResult> GetAppointmentStatus(int appointmentId)
        {
            var appointmentStatus = await _appointmentRepository.GetAppointmentsAsync(appointmentId);
            if (appointmentStatus == null)
            {
                return NotFound(new { Message = $"No data found for AppointmentId {appointmentId}" });
            }
            return Ok(appointmentStatus);
        }


    }
}
