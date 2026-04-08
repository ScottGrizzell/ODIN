using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    public class CaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
