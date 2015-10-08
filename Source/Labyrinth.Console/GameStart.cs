namespace Labyrinth.Console
{
    using Labyrinth.Logic;
    using Logic.Observer;
    using Labyrinth.Logic.Rules;

    public class GameStart
    {
        private static void Main(string[] args)
        {
            var renderer = new Renderer();
            var inputHandler = new InputHandler();
            var gameRules = new StandartGameRule();
            var coordinates = new PlayerCoordinates();

            var game = new Game(renderer, gameRules, inputHandler, coordinates);
            game.Start();
        }
    }
}