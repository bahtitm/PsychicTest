using Microsoft.AspNetCore.Http;
using PsychicTest.Entities;
using System.Collections.Generic;

namespace PsychicTest.Servicies
{
    public class ApplicationService : IApplicationService
    {
        private readonly ISession session;
       
        const int PsychicCount = 2;
        public ApplicationService(ISession session)
        {

            this.session = session;
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

            List<Psychic> psychics = new List<Psychic>();
            for (int i = 0; i < PsychicCount; i++)
            {
                psychics.Add(PsyhicGenerator.GeneratePsychic());
            }
            session.SetObjectAsJson("psychics", psychics);
          
            return psychics;
        }

        public void CountConfidenceLevel(int guessedNumber)
        {

            AddIntoHistoryUserGuessedNumber(guessedNumber);
            var psychics = session.GetObjectFromJson<List<Psychic>>("psychics");
            foreach (var item in psychics)
            {

                item.CountConfidenceLevel(guessedNumber);

            }

            session.SetObjectAsJson("psychics", psychics);

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

    }
}
