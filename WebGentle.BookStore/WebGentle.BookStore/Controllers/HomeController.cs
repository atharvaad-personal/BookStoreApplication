using Microsoft.AspNetCore.Mvc;

namespace WebGentle.BookStore.Controllers
{
    public class HomeController:Controller
    {
        public readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger; 
        }
        public ViewResult Index()
        {
            _logger.LogInformation("Index Method Execution started");

            return View();
        }
    }
}
