using System;
using System.Collections.Generic;

namespace PsychicTest.Entities
{
    /// <summary>
    /// Экстрасенс
    /// </summary>
    public class Psychic
    {
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Догадка екстрасенса
        /// </summary>
        public int GuessedWork { get; set; } = 0;
        /// <summary>
        /// уровень достоверности
        /// </summary>
        public int ConfidenceLevel { get; set; } = 0;
        public List<int> GuessedWorkHistory { get; set; } = new List<int>();


        public int GetGuesswork()
        {
            var random = new Random();
            random.Next();
            return random.Next();
        }
        public void SetGuessworkAndWriteIntoHistory()
        {
            var random = new Random();
            GuessedWork = random.Next(0, 99);
            GuessedWorkHistory.Add(GuessedWork);
        }
        public void CountConfidenceLevel(int guessedNumber)
        {
            var result = GuessedWork == guessedNumber ? ConfidenceLevel++ : ConfidenceLevel--;

        }


    }
}
