using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace PsychicTest.Entities
{
    /// <summary>
    /// Экстрасенс
    /// </summary>
    public class Psychic : PageModel
    {
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Догадка екстрасенса
        /// </summary>
        public int GuessedWork { get; set; } = 0;
        /// <summary>
        /// уровень достоверности
        /// </summary>
        public int ConfidenceLevel { get; set; } = 0;
        public List<int> GuessedWorkHistory { get; set; } = new List<int>();


    }
}
