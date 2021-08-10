using PsychicTest.Entities;
using System;

namespace PsychicTest.Helpers
{
    public class PsychicHelper
    {
        private readonly Psychic psyshic;

        public PsychicHelper(Psychic psyshic)
        {
            this.psyshic = psyshic;
        }

        /// <summary>
        /// получить догатку
        /// </summary>
        /// <returns></returns>
        public int GetGuesswork()
        {
            var random = new Random();
            random.Next();
            return random.Next();
        }
        public void SetGuesswork()
        {
            var random = new Random();
            psyshic.GuessedWork = random.Next(0, 10);
        }
        public void CountConfidenceLevel(int guessedNumber)
        {
            if (psyshic.GuessedWork != guessedNumber)
            {
                return;
            }
            else
            {
                psyshic.ConfidenceLevel++;

            }
        }
    }
}
