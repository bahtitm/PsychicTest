using PsychicTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychicTest.Dtos
{
    public class Statistics
    {
        public List<Psychic> Psychics { get; set; } = new List<Psychic>();
        public List<int> GuessedNumbers { get; set; } = new List<int>();
    }
}
