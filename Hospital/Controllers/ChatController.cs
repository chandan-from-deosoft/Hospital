using Hospital.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    // Controller
    [Route("api/[controller]")]
    public class ChatController : Controller
    {
        private readonly IRepository<ChatMessage> _chatMessageRepository;
        private readonly IRepository<ChatButton> _chatButtonRepository;

        public ChatController(IRepository<ChatMessage> chatMessageRepository, IRepository<ChatButton> chatButtonRepository)
        {
            _chatMessageRepository = chatMessageRepository;
            _chatButtonRepository = chatButtonRepository;
        }

        [HttpGet("welcome")]
        public async Task<IActionResult> GetWelcomeData()
        {
            var message = await _chatMessageRepository.GetByIdAsync(1);
            return Ok(message);
        }

        [HttpGet("message/{chatId}")]
        public async Task<IActionResult> GetChatData(int chatId)
        {
            var message = await _chatMessageRepository.GetByIdAsync(chatId);
            return Ok(message);
        }

        [HttpGet("options/{chatId}")]
        public async Task<IActionResult> GetOptionsData(int chatId)
        {
            var options = await ((ChatRepository)_chatButtonRepository).GetOptionsByChatIdAsync(chatId);
            return Ok(options);
        }
    }

   
}
