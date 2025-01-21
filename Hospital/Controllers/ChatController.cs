using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
