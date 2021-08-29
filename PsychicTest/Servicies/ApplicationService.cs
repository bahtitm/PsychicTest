using Microsoft.AspNetCore.Http;
using PsychicTest.Entities;
using System.Collections.Generic;

namespace PsychicTest.Servicies
{
    public class ApplicationService : IApplicationService
    {
        private readonly ISession session;
        private readonly IHttpContextAccessor _httpContextAccessor;
      
       
        const int PsychicCount = 2;
        public ApplicationService(IHttpContextAccessor httpContextAccessor)
        {

            this.session = httpContextAccessor.HttpContext.Session;

            



        }
        public void AddIntoHistoryUserGuessedNumber(int guessedNumber)
        {
            var guessedNumbers = session.GetObjectFromJson<List<int>>("GuessedNumbers");
            if (guessedNumbers != null)
            {
                guessedNumbers.Add(guessedNumber);
            }
            else
            {
                guessedNumbers = new List<int>();
                guessedNumbers.Add(guessedNumber);


            }
            session.Remove("GuessedNumbers");
            session.SetObjectAsJson("GuessedNumbers", guessedNumbers);
        }
        public List<Psychic> CreatePsychics()
        {

            session.SetObjectAsJson("psychics", GameSession.Psychics);
          
            return GameSession.Psychics;
        }

        public void CountConfidenceLevel(int guessedNumber)
        {

            AddIntoHistoryUserGuessedNumber(guessedNumber);
            var psychics = session.GetObjectFromJson<List<Psychic>>("psychics");
            var psychicGuess = new Dictionary<string, int>();
            var psychicConfidenceLevel = new Dictionary<string, int>();
            foreach (var item in psychics)
            {

                item.CountConfidenceLevel(guessedNumber);
                psychicGuess.Add(item.Name,item.Guess);
                psychicConfidenceLevel.Add(item.Name,item.ConfidenceLevel);

            }

            session.SetObjectAsJson("psychics", psychics);
            GameSession.UpdateStatics(guessedNumber, psychicGuess, psychicConfidenceLevel);
            session.SetObjectAsJson("Statics",GameSession.Statics);

        }

        public List<Psychic> Guesswork()
        {

            var psychics = session.GetObjectFromJson<List<Psychic>>("psychics");

            foreach (var item in psychics)
            {
                item.SetGuessworkAndWriteIntoHistory();

            }
            session.SetObjectAsJson("psychics", psychics);
            return psychics;
        }

        public Statics GetStatitics()
        {
            return GameSession.Statics;
        }


    }
}
