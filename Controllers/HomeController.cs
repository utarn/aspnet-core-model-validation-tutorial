using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using model_validation_tutorial.Models;
using model_validation_tutorial.Services;

namespace model_validation_tutorial.Controllers
{
   public class HomeController : Controller
   {
      private readonly ILogger<HomeController> _logger;
      private readonly IDateTimeService _dateTimeService;
      public HomeController(ILogger<HomeController> logger, IDateTimeService dateTimeService)
      {
         _dateTimeService = dateTimeService;
         _logger = logger;
      }

      public IActionResult Index()
      {
         ViewData["CurrentTime"] = _dateTimeService.CurrentTime();
         return View();
      }

      [HttpPost]
      public IActionResult Index(Member model)
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
