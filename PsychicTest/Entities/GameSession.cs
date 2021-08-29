using System.Collections.Generic;

namespace PsychicTest.Entities
{
    public static class GameSession
    {
        public static List<Psychic> Psychics { get; set; } = new List<Psychic>();

        public static Statics Statics { get; set; } = new Statics();

      
        public static  void GameSessionInit(List<string> psychicNames)
        {
            
            foreach (var item in psychicNames)
            {
                var psychic = new Psychic(item);
                Psychics.Add(psychic);
            }
        }

        public static  void UpdateStatics(int guessedNumber, Dictionary<string, int> psychicGuess, Dictionary<string, int> psychicConfidenceLevel)
        {
            Statics.GuessedNumbers.Add(guessedNumber);
            Statics.PsychicGuesses.Add(psychicGuess);
            Statics.PsychicConfidenceLevel = psychicConfidenceLevel;
        }
    }
}
