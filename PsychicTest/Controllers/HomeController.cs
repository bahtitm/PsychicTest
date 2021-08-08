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
            //HttpContext.Session.SetInt32("age", 20);

            //HttpContext.Session.SetString("username", "abc");

            
            

            List<Psychic> products = new List<Psychic>() {
                new Psychic {
                    
                    Name = "Name 1",
                    GuessedNumber=0
                },
                new Psychic {
                    
                    Name = "Name 2",
                    GuessedNumber=0
                },
                
            };
            SessionHelper.SetObjectAsJson(HttpContext.Session, "products", products);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Guesswork()
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
