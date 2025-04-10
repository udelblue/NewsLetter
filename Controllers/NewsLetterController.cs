using Microsoft.AspNetCore.Mvc;
using NewsLetter.Models;
using System.Diagnostics;

namespace NewsLetter.Controllers
{
    public class NewsLetterController : Controller
    {
        private readonly ILogger<NewsLetterController> _logger;

        public NewsLetterController(ILogger<NewsLetterController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index([FromForm] string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                // Process the email (e.g., save to database, send confirmation, etc.)
                _logger.LogInformation($"Received email: {email}");
            }
            return RedirectToAction("Submitted");
        }

        public IActionResult Submitted()
        {
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
