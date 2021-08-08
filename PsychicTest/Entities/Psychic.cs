using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychicTest.Entities
{
    /// <summary>
    /// Экстрасенс
    /// </summary>
    public class Psychic
    {
        public string Name { get; set; }
        /// <summary>
        /// Догадка его
        /// </summary>
        public int GuessedWork { get; set; } = 0;
        /// <summary>
        /// уровень достоверности
        /// </summary>
        public int ConfidenceLevel { get; set; } = 0;

    }
}
