using Microsoft.AspNetCore.Http;
using PsychicTest.Entities;
using System.Collections.Generic;

namespace PsychicTest.Servicies
{
    public class ApplicationService : IApplicationService
    {
        private readonly ISession session;
        private readonly IStorageService storageServise;
        const int PsychicCount = 2;
        public ApplicationService(IHttpContextAccessor httpContextAccessor, IStorageService storageServise)
        {
            this.session = httpContextAccessor.HttpContext.Session;
            this.storageServise = storageServise;
        }
        public void GameInit()
        {
            List<string> psychicsNames = new List<string>();
            for (int i = 0; i < PsychicCount; i++)
            {
                var name = $"mag{i}";
                psychicsNames.Add(name);
            }
            var gamesession = new GameSession();
            gamesession.GameSessionInit(psychicsNames);
            storageServise.SetIntoStorge("GameSession", gamesession);
           
            
        }
        public GameSession CountConfidenceLevel(int guessedNumber)
        {            
            var gamesession = storageServise.GetFromStorge<GameSession>("GameSession");
            foreach (var item in gamesession.Psychics)
            {              
                item.CountConfidenceLevel(guessedNumber);              
            }            
            gamesession.GuessedNumbersAdd(guessedNumber);            
            storageServise.SetIntoStorge("GameSession", gamesession);                      
            return gamesession;
        }
        public GameSession GetGameSession()
        {
            var gamesession = storageServise.GetFromStorge<GameSession>("GameSession");
            return gamesession;
        }

        public List<Psychic> Guesswork()
        {                   
            var gamesession = storageServise.GetFromStorge<GameSession>("GameSession");
            foreach (var item in gamesession.Psychics)
            {
                item.SetGuessworkAndWriteIntoHistory();
            }               
            storageServise.SetIntoStorge("GameSession", gamesession);

            return gamesession.Psychics;
        }  
    }
}
