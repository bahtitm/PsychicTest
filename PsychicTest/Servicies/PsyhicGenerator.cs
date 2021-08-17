using PsychicTest.Entities;

namespace PsychicTest.Servicies
{
    public static class PsyhicGenerator
    {

        private static int count = 1;


        public static Psychic GeneratePsychic()
        {
            var nameMag = $"Mag{count++ }";
            return new Psychic(nameMag);
        }
    }
}
