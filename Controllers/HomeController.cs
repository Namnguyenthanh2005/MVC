using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_Group3.Models;


namespace MVC_Group3.Controllers
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
            var carouselItems = new List<CarouselItem>
    {
        new CarouselItem
        {
            ImageUrl = "/images/KV - Nike - Rodolfo Augusto.jpg",
            Title = "Air Jordan 4",
            Subtitle = "'Military Blue'",
            ButtonText = "Buy & Sell Now",
            Link = "#"
        },
        new CarouselItem
        {
            ImageUrl = "/images/Shoes Banner.jpg",
            Title = "Nike Air Max",
            Subtitle = "'Comfort Red'",
            ButtonText = "Explore Now",
            Link = "#"
        }
    };

            // Truyền danh sách vào View
            return View(carouselItems);
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
