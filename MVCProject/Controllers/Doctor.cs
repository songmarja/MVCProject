using Microsoft.AspNetCore.Mvc;

namespace MVCProject.Controllers
{
    public class Doctor : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult FeverCheck()
        {
            return View();
        }
    }
}
