using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PsychicTest.Entities;
using PsychicTest.Helpers;
using PsychicTest.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace PsychicTest.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            var psychics = HttpContext.Session.GetObjectFromJson<List<Psychic>>("psychics");
            return psychics != null ? View(psychics) : View(CreatePsychics());
           
        }

        private List<Psychic> CreatePsychics()
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
            HttpContext.Session.SetObjectAsJson("psychics", psychics);
            return psychics;
        }
        [HttpPost]
        public IActionResult Guesswork()
        {

            var psychics = HttpContext.Session.GetObjectFromJson<List<Psychic>>("psychics");
            HttpContext.Session.Clear();
            foreach (var item in psychics)
            {
                var psychicHelper = new PsychicHelper(item);
                psychicHelper.SetGuesswork();

            }
            HttpContext.Session.SetObjectAsJson("psychics", psychics);
            return View(psychics);
        }
        [HttpPost]
        public IActionResult CountConfidenceLevel(int guessedNumber)
        {

            var psychics = HttpContext.Session.GetObjectFromJson<List<Psychic>>("psychics");
            foreach (var item in psychics)
            {
                var psychicHelper = new PsychicHelper(item);
                psychicHelper.CountConfidenceLevel(guessedNumber);

            }
            HttpContext.Session.Clear();
            HttpContext.Session.SetObjectAsJson("psychics", psychics);
            return RedirectToAction("Index");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
