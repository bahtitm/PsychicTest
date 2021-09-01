using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PsychicTest.Dtos;
using PsychicTest.Models;
using PsychicTest.Servicies;
using System.Diagnostics;

namespace PsychicTest.Controllers
{
    public class HomeController : Controller
    {


        private readonly IApplicationService applicationService;


        public HomeController(IApplicationService applicationService)
        {

            this.applicationService = applicationService;

        }


        public IActionResult Index()
        {

            var statisticsModel = new Statistics();

            var gameSession = applicationService.GetGameSession();


            if (gameSession != null)
            {
                statisticsModel.Psychics = gameSession.Psychics;
                statisticsModel.GuessedNumbers = gameSession.GuessedNumbers;
            }
            else
            {
                applicationService.GameInit();
            }
            return View(statisticsModel);

        }
        [HttpPost]
        public IActionResult GenerateGuesswork()
        {
            var guessModel = new Guess();
            guessModel.Psychics = applicationService.Guesswork();
            return Redirect("Guesswork");
        }

        public IActionResult Guesswork()
        {
            var gameSession = applicationService.GetGameSession();
            var guessModel = new Guess();
            guessModel.Psychics = gameSession.Psychics;
            return View(guessModel);
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