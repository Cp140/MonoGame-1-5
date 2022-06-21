using System;

namespace MonoGame_1_5
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Game1())
                game.Run();

        }
    }
}
