using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    public class ChatbotController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
