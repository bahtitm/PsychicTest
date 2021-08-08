using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PsychicTest.Entities;
using PsychicTest.Helpers;
using PsychicTest.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PsychicTest.Controllers
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
            CreatePsychic();
            return View();
            // RedirectToAction("Guesswork") ;
        }

        private void CreatePsychic()
        {


            List<Psychic> psychics = new List<Psychic>() {
                new Psychic {

                    Name = "Черный маг",
                    GuessedWork=0
                },
                new Psychic {

                    Name = "Белый Маг",
                    GuessedWork=0
                },

            };
            SessionHelper.SetObjectAsJson(HttpContext.Session, "psychics", psychics);
        }

        public IActionResult Privacy()
        {

            return View();
        }
        public IActionResult Guesswork()
        {

            var psychics = SessionHelper.GetObjectFromJson<List<Psychic>>(HttpContext.Session, "psychics");
            foreach (var item in psychics)
            {
                var psychicHelper = new PsychicHelper(item);
                psychicHelper.SetGuesswork();

            }
            HttpContext.Session.Clear();
            SessionHelper.SetObjectAsJson(HttpContext.Session, "psychics", psychics);
            return View();
        }
        [HttpPost]
        public IActionResult CountConfidenceLevel(int guessedNumber)
        {

            var psychics = SessionHelper.GetObjectFromJson<List<Psychic>>(HttpContext.Session, "psychics");
            foreach (var item in psychics)
            {
                var psychicHelper = new PsychicHelper(item);
                psychicHelper.CountConfidenceLevel(guessedNumber);

            }
            HttpContext.Session.Clear();
            SessionHelper.SetObjectAsJson(HttpContext.Session, "psychics", psychics);
            return RedirectToAction("Index");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
