using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PsychicTest.Entities;
using PsychicTest.Models;
using PsychicTest.Servicies;
using System.Collections.Generic;
using System.Diagnostics;

namespace PsychicTest.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IApplicationService applicationService;

        public HomeController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            this.applicationService = new ApplicationService(_httpContextAccessor.HttpContext.Session);
        }


        public IActionResult Index()
        {           
            var guessedNumnbers = HttpContext.Session.GetObjectFromJson<List<int>>("GuessedNumbers");
            if (guessedNumnbers != null)
            {

                ViewData["GuessedNumbers"] = guessedNumnbers;
            }
            else
            {
                var zeroValuies = new List<int>();
                zeroValuies.Add(0);
                ViewData["GuessedNumbers"] = zeroValuies;
            }
            var psychics = HttpContext.Session.GetObjectFromJson<List<Psychic>>("psychics");
            return psychics != null ? View(psychics) : View(applicationService.CreatePsychics());

        }


        [HttpPost]
        public IActionResult Guesswork()
        {
            var psychics= applicationService.Guesswork();           
            return View(psychics);
        }
        [HttpPost]
        public IActionResult CountConfidenceLevel(int guessedNumber)
        {
            applicationService.CountConfidenceLevel(guessedNumber);
            return RedirectToAction("Index");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
