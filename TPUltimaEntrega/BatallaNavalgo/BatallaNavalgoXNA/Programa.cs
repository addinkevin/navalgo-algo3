using System;

namespace BatallaNavalgoXNA
{
    static class Programa
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (JuegoBatallaNavalgo game = new JuegoBatallaNavalgo())
            {
                game.Run();
            }
        }
    }
}