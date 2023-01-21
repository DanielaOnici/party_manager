using Assignment2_DanielaOnici.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Assignment2_DanielaOnici.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // Check if the cookie already exists.If so, read it.
            if (Request.Cookies.ContainsKey("timeVisit"))
            {
                string time = Request.Cookies["timeVisit"];
                ViewBag.TimeVisit = $"Welcome Back! Your first visit was at {time}";
            }
            // if not, create one with the date time
            else
            {
                DateTime timeVisit = DateTime.Now;
                string time = timeVisit.ToString("g");

                Response.Cookies.Append("timeVisit", time);
                ViewBag.TimeVisit = "Welcome to the Party Guest Manager App!";
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}