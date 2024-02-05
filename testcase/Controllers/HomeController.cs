using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Drawing;
using testcase.Models;
using testcase.Services;

namespace testcase.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NumberService _numberService;

        public HomeController(ILogger<HomeController> logger, NumberService numberService)
        {
            _logger = logger;
            _numberService = numberService;
        }

        public IActionResult Index()
        {
            TempData["LargestPrimeNumber"] = _numberService.FindLargestPrimeNumber();

            var lastFivePrimeNumbers = _numberService.GetLastFivePrimeNumbers();
            return View(lastFivePrimeNumbers);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> StorePrimeNumber(PrimeNumber formData)
        {
            try
            {
                int number = formData.number;

                if (await _numberService.StorePrimeNumber(number))
                {
                    TempData["SuccessMessage"] = "Number successfully added.";
                    TempData["LargestPrimeNumber"] = _numberService.FindLargestPrimeNumber();
                }
                else
                {
                    TempData["ErrorMessage"] = "The number is not prime.";
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in StorePrimeNumber action.");
                TempData["ErrorMessage"] = "An error occurred.";
                return RedirectToAction("Index");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
