namespace Labyrinth.Console
{
    using Labyrinth.Models;

    public class AppStart
    {
        private static void Main(string[] args)
        {
            var game = new Game();
            Game.Start();
        }
    }
}