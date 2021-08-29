using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace PsychicTest.Entities
{
    public class Statics
    {
        public List<int> GuessedNumbers { get; set; } = new List<int>();
        public ICollection<Dictionary<string, int>> PsychicGuesses { get; set; } = new List<Dictionary<string, int>>();
        public Dictionary<string, int> PsychicConfidenceLevel { get; set; } = new Dictionary<string, int>();
    }
}
