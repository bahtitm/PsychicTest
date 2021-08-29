using System;
using System.Collections.Generic;

namespace PsychicTest.Entities
{
    /// <summary>
    /// Экстрасенс
    /// </summary>
    public class Psychic
    {
        
       public string Name { get; private set; }
        /// <summary>
        /// Догадка екстрасенса
        /// </summary>
        public int Guess { get;  set; }
        /// <summary>
        /// уровень достоверности
        /// </summary>
        public int ConfidenceLevel { get;  set; }
        public List<int> GuessedHistory { get; set; } = new List<int>();

        public Psychic(string name)
        {
            Name = name;
        }
        public void SetGuessworkAndWriteIntoHistory()
        {
            var random = new Random();
            Guess = random.Next(10, 99);
            GuessedHistory.Add(Guess);
        }
        public void CountConfidenceLevel(int guessedNumber)
        {
            if (Guess == guessedNumber)
            {
                ConfidenceLevel++;
            } else
            { 
             ConfidenceLevel--;
            }

        }
        public void SetGuess()
        {
            var random = new Random();
            Guess = random.Next(10, 99);
            
        }
    }
}
