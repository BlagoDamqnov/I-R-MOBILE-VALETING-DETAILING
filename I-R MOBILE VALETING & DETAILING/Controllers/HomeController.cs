using I_R_MOBILE_VALETING___DETAILING.Models;
using I_R_MOBILE_VALETING___DETAILING.Service.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;

namespace I_R_MOBILE_VALETING___DETAILING.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookService _bookService;

        public HomeController(ILogger<HomeController> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Booking()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Booking(Book bookVM)
        {
            if (!ModelState.IsValid)
            {
                return View(bookVM);
            }
            var phoneNumber = "+447395229063"; // Replace with the customer's phone number

            // Create a message for booking a mobile car wash
            var message = $"Hello! I would like to book a mobile car wash service.{Environment.NewLine}" +
                           $"Name: {bookVM.Name}{Environment.NewLine}" +
                           $"Email: {bookVM.Email}{Environment.NewLine}" +
                           $"Phone Number: {bookVM.Phone}{Environment.NewLine}" +
                           $"Service Type: {bookVM.WashType}{Environment.NewLine}" +
                           $"Please let me know the available dates and times.";

            var whatsappUrl = $"https://api.whatsapp.com/send?phone={phoneNumber}&text={System.Web.HttpUtility.UrlEncode(message)}";

            return Redirect(whatsappUrl);
        }


        public IActionResult Service()
        {
            return View();
        }
        public IActionResult Contact()
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