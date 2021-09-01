using System.Collections.Generic;

namespace PsychicTest.Entities
{
    public  class GameSession
    {
        public  List<Psychic> Psychics { get; private set; } = new List<Psychic>();

      
        public  List<int> GuessedNumbers { get; private set; } = new List<int>();


        public   void GameSessionInit(List<string> psychicNames)
        {
            
            foreach (var item in psychicNames)
            {
                var psychic = new Psychic(item);
                Psychics.Add(psychic);
            }
        }

        public   void GuessedNumbersAdd(int guessedNumber)
        {
            GuessedNumbers.Add(guessedNumber);         
           

        }
    }
}
