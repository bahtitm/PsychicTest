using PsychicTest.Entities;
using System.Collections.Generic;

namespace PsychicTest.Servicies
{
    public interface IApplicationService
    {
        void AddIntoHistoryUserGuessedNumber(int guessedNumber);
        List<Psychic> CreatePsychics();
        void CountConfidenceLevel(int guessedNumber);
        List<Psychic> Guesswork();


    }
}
