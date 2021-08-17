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
        private readonly IStorageServise storageServise;
        private readonly IApplicationService applicationService;

        public HomeController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            this.storageServise = new StorageService(_httpContextAccessor.HttpContext.Session) ;
            this.applicationService = new ApplicationService(_httpContextAccessor.HttpContext.Session);
        }


        public IActionResult Index()
        {
            var statisticsModel = new StatisticsModel();
           
            var guessedNumnbers = storageServise.GetFromStorge<List<int>>("GuessedNumbers");
            if (guessedNumnbers != null)
            {

                statisticsModel.GuessedNumbers = guessedNumnbers;
            }

            var psychics = storageServise.GetFromStorge<List<Psychic>>("psychics");
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
        public IActionResult GenerateGuesswork()
        {
            var guessworModel = new GuessworkModel();
            guessworModel.Psychics = applicationService.Guesswork();
            storageServise.SetIntoStorge("GuessworkModel",guessworModel);
            return Redirect("Guesswork");
        }

      
        public IActionResult Guesswork()
        {
            var guessworkModel = storageServise.GetFromStorge<GuessworkModel>("GuessworkModel");
            return View(guessworkModel);
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