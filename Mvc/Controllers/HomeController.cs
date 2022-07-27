using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mvc.Models;
using Mvc.ViewModels;
using System.Diagnostics;
using System.Threading.Tasks;


namespace Mvc.Controllers
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
            return View();
        }

        public IActionResult CustomValidators()
        {
            var model = new SoftwareLicenseAgreement() { SoftwareProductName = "Some software product name" };
            return View("CustomValidators", model);
        }

        [HttpPost]
        public IActionResult CustomValidators(SoftwareLicenseAgreement model)
        {
            return ModelState.IsValid ? RedirectToAction("Download") : View("CustomValidators", model);
        }

        public IActionResult Download()
        {
            return View();
        }

        public IActionResult ValidatableObject()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ValidatableObject(HotelReservation model)
        {
            return ModelState.IsValid ? RedirectToAction("ReservationSuccess") : View("ValidatableObject", model);
        }

        public IActionResult ReservationSuccess()
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

        public IActionResult RemoteValidation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RemoteValidation(BandViewModel model)
        {
            return ModelState.IsValid ? RedirectToAction("BandNameAdded") : View("RemoteValidation", model);
        }

        public IActionResult BandNameAdded()
        {
            return View();
        }

        public IActionResult FluentValidation()
        {
            return View("FluentValidation", new GuitarBuilderViewModel { Guitar = new Guitar { Name = "New Guitar" } });
        }

        [HttpPost]
        public async Task<IActionResult> FluentValidation(GuitarBuilderViewModel model)
        {
            GuitarBuilderToGuitarAdapter adapter = new();
            model.Guitar = adapter.BuildGuitar(model);
            await TryUpdateModelAsync(model.Guitar); // invokes GuitarValidator

            return ModelState.IsValid ? RedirectToAction("OrderReceived") : View("FluentValidation", model);
        }

        public IActionResult OrderReceived()
        {
            return View();
        }
    }
}
