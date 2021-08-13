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
            var statisticsModel = new StatisticsModel();
            var guessedNumnbers = HttpContext.Session.GetObjectFromJson<List<int>>("GuessedNumbers");
            if (guessedNumnbers != null)
            {

                statisticsModel.GuessedNumbers = guessedNumnbers;
            }
            else
            {
                var zeroValuies = new List<int>();
                zeroValuies.Add(0);
                statisticsModel.GuessedNumbers = zeroValuies;
            }
            
            var psychics = HttpContext.Session.GetObjectFromJson<List<Psychic>>("psychics");
            if (psychics != null)
            {
                
                statisticsModel.Psychics = psychics;
                
            }
            else
            {
                statisticsModel.Psychics = applicationService.CreatePsychics();
               
                
            }
            
            return View(statisticsModel);

        }
        [HttpPost]
        public IActionResult Guesswork()
        {
            var guessworModel = new GuessworkModel();
            guessworModel.Psychics= applicationService.Guesswork();
            return View(guessworModel);
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
