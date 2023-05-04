using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QRCode.Models;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace QRCode.Controllers
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

        [HttpGet("qrcode")]
        public IActionResult GetQrCode()
        {
            var image = QrGenerator.GenerateByteArray("app://toolbox.app.br/mao-de-obra/");
            var file = File(image, "image/png");
            return file;
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
