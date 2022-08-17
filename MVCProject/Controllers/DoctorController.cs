using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult FeverCheck()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FeverCheck(string temperature)
        {
            ViewBag.Message = FeverCheckModel.CheckTemperature(temperature);
            return View();

        }
    }
}
