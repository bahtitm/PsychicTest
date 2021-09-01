using PsychicTest.Entities;
using System.Collections.Generic;

namespace PsychicTest.Dtos
{
    public class Statistics
    {
        public List<Psychic> Psychics { get; set; } = new List<Psychic>();
        public List<int> GuessedNumbers { get; set; } = new List<int>();
    }
}
