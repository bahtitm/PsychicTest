using System;
using System.Collections.Generic;

namespace PsychicTest.Entities
{
    /// <summary>
    /// Экстрасенс
    /// </summary>
    public class Psychic
    {
       public string Name { get; private set; } = string.Empty;
        /// <summary>
        /// Догадка екстрасенса
        /// </summary>
        public int GuessedWork { get;  set; }
        /// <summary>
        /// уровень достоверности
        /// </summary>
        public int ConfidenceLevel { get;  set; }
        public List<int> GuessedWorkHistory { get; set; } = new List<int>();

        public Psychic(string name)
        {
            Name = name;
        }
        public void SetGuessworkAndWriteIntoHistory()
        {
            var random = new Random();
            GuessedWork = random.Next(10, 99);
            GuessedWorkHistory.Add(GuessedWork);
        }
        public void CountConfidenceLevel(int guessedNumber)
        {
            if (GuessedWork == guessedNumber)
            {
                ConfidenceLevel++;
            } else
            { 
             ConfidenceLevel--;
            }

        }
    }
}
