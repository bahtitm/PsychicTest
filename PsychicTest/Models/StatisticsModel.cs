﻿using PsychicTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychicTest.Models
{
    public class StatisticsModel
    {
        public List<Psychic> Psychics { get; set; }
        public List<int> GuessedNumbers { get; set; } = new List<int>();
        public ICollection<Dictionary<string, int>> PsychicGuesses { get; set; } = new List<Dictionary<string, int>>();
    }
}
