using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PsychicTest.Entities;

namespace PsychicTest.Models
{
    public class GameSessionModel
    {
        public List<Psychic> Psychics { get; set; } = new List<Psychic>();
        public List<int> GuessedNumbers { get; set; } = new List<int>();
    }
}
