namespace Labyrinth.Logic
{
    using Labyrinth.Logic.Contracts;
    using BoardSetupRules;
    using Common;

    public class Engine : IEngine
    {
        private readonly IRenderer renderer;
        private readonly IInputHandler inputHandler;
        private IBoardSetup boardSetupRules;

        public Engine(IRenderer renderer, IInputHandler inputHandler)
        {
            this.renderer = renderer;
            this.inputHandler = inputHandler;
        }

        public void Run()
        {
            this.renderer.RenderMessage(Messages.TypeOfGameMessage);
            string userGameType;
            do
            {
                userGameType = this.inputHandler.GetInput();
            }
            while (userGameType != "standart" && userGameType != "unique");
            switch (userGameType)
            {
                case "standart":
                    this.boardSetupRules = new StandartBoardSetup();
                    break;
                case "unique":
                    // different boardSetupRules
                    break;
                default:
                    break;
            }

            var game = new Game(this.renderer, this.inputHandler, this.boardSetupRules);
            game.Start();
        }
    }
}
