namespace Labyrinth.Console
{
    using Labyrinth.Logic;
    using Labyrinth.Logic.BoardSetupRules;

    public class Program
    {
        private static void Main(string[] args)
        {
            var renderer = new Renderer();
            var inputHandler = new InputHandler();

            var engine = new Engine(renderer, inputHandler);
            engine.Run();
        }
    }
}