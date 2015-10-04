namespace Labyrinth.Console
{
    using Labyrinth.Logic;
    using Labyrinth.Logic.Rules;

    public class GameStart
    {
        private static void Main(string[] args)
        {
            var renderer = new Renderer();
            //var inputHandler = new InputHandler();
            var gameRules = new StandartGameRule();
            //var commandExecutor = new CommandExecutor();

            var game = new Game(renderer,gameRules);
            game.Start();
        }
    }
}