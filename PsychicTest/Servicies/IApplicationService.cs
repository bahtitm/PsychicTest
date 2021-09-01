using PsychicTest.Entities;
using System.Collections.Generic;

namespace PsychicTest.Servicies
{
    public interface IApplicationService
    {       
        GameSession CountConfidenceLevel(int guessedNumber);
        List<Psychic> Guesswork();
         void GameInit();
        GameSession GetGameSession();
    }
}
