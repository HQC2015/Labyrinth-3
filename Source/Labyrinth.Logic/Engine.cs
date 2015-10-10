namespace Labyrinth.Logic
{
    using Commands;
    using Contracts;
    using Interfaces;
    using Rules;

    public class Engine : IEngine
    {
        private readonly IRenderer renderer;
        private readonly IInputHandler inputHandler;
        private IBoardSetup gameRules;
        private MoveLogic moveLogic;

        public Engine(IRenderer renderer, IInputHandler inputHandler)
        {
            this.renderer = renderer;
            this.inputHandler = inputHandler;
            this.gameRules = new StandartBoardSetup();
            this.moveLogic = new StandartMoveLogic();
        }

        public void Run()
        {
            ////TODO make it  right
            ////this.renderer.RenderMessage(Messages.TypeOfGameMessage);
            ////string userGameType;
            ////do
            ////{
            ////    userGameType = this.inputHandler.GetInput();
            ////}
            ////while (userGameType != "standart" && userGameType != "unique");
            ////switch (userGameType)
            ////{
            ////    case "standart":
            ////        this.gameRules = new StandartBoardSetup();
            ////        this.moveLogic = new StandartMoveLogic();
            ////        break;
            ////    case "extra":
            ////        // different gameRules
            ////        // different moveLogic
            ////        break;
            ////    default:
            ////        break;
            ////}
            while (true)
            {
                var game = new Game(this.renderer, this.inputHandler, this.gameRules, this.moveLogic);
                game.Start();
            }
        }
    }
}
