using PsychicTest.Entities;
using System.Collections.Generic;

namespace PsychicTest.Servicies
{
    public interface IApplicationService
    {
        //void AddIntoHistoryUserGuessedNumber(int guessedNumber);
        //List<Psychic> CreatePsychics();
        GameSession CountConfidenceLevel(int guessedNumber);
        List<Psychic> Guesswork();
        //Statics GetStatitics();
        void GameInit();
        GameSession GetGameSession();


    }
}
