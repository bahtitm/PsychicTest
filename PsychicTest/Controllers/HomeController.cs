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
            return psychics != null ? View(psychics) : View(CreatePsychics());
           
        }

        
        [HttpPost]
        public IActionResult Guesswork()
        {

            var psychics = HttpContext.Session.GetObjectFromJson<List<Psychic>>("psychics");
            
            foreach (var item in psychics)
            {
               item.SetGuesswork();

            }
            HttpContext.Session.SetObjectAsJson("psychics", psychics);
            return View(psychics);
        }
        [HttpPost]
        public IActionResult CountConfidenceLevel(int guessedNumber)
        {
            
            AddInHistoryUserGuessedNumber(guessedNumber);
            var psychics = HttpContext.Session.GetObjectFromJson<List<Psychic>>("psychics");
            foreach (var item in psychics)
            {
                
                item.CountConfidenceLevel(guessedNumber);

            }
           
            HttpContext.Session.SetObjectAsJson("psychics", psychics);
            return RedirectToAction("Index");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        private void AddInHistoryUserGuessedNumber(int guessedNumber)
        {
            var guessedNumbers = HttpContext.Session.GetObjectFromJson<List<int>>("GuessedNumbers");
            if (guessedNumbers != null)
            {
                guessedNumbers.Add(guessedNumber);
            }
            else
            {
                guessedNumbers = new List<int>();
                guessedNumbers.Add(guessedNumber);


            }
            HttpContext.Session.Remove("GuessedNumbers");
            HttpContext.Session.SetObjectAsJson("GuessedNumbers", guessedNumbers);
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
    }
}
