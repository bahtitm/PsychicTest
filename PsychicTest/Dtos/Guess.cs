using PsychicTest.Entities;
using System.Collections.Generic;

namespace PsychicTest.Dtos
{
    public class Guess
    {
        public List<Psychic> Psychics { get; set; } = new List<Psychic>();
    }
}
