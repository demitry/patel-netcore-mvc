using DIServiceLifetime.Models;
using DIServiceLifetime.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;

namespace DIServiceLifetime.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ISingletonGuidService _singletonService1;
        private readonly ISingletonGuidService _singletonService2;

        private readonly IScopedGuidService _scopedService1;
        private readonly IScopedGuidService _scopedService2;

        private readonly ITransientGuidService _transientService1;
        private readonly ITransientGuidService _transientService2;

        public HomeController(ILogger<HomeController> logger,
            ISingletonGuidService singleton1,
            ISingletonGuidService singleton2,
            IScopedGuidService scoped1,
            IScopedGuidService scoped2,
            ITransientGuidService transient1,
            ITransientGuidService transient2)
        {
            _singletonService1 = singleton1;
            _singletonService2 = singleton2;
            _scopedService1 = scoped1;
            _scopedService2 = scoped2;
            _transientService1 = transient1;
            _transientService2 = transient2;

            _logger = logger;
        }

        public IActionResult Index()
        {
            StringBuilder messages = new StringBuilder();

            messages.Append($"Transient 1: {_transientService1.GetGuid()} \n");
            messages.Append($"Transient 2: {_transientService2.GetGuid()} \n\n\n");

            messages.Append($"Singleton 1: {_singletonService1.GetGuid()} \n");
            messages.Append($"Singleton 2: {_singletonService2.GetGuid()} \n\n\n");

            messages.Append($"Scoped 1: {_scopedService1.GetGuid()} \n");
            messages.Append($"Scoped 2: {_scopedService2.GetGuid()} \n\n\n");

            return Ok(messages.ToString());
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