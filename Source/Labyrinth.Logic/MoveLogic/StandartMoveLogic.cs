namespace Labyrinth.Logic.Commands
{
    using Labyrinth.Models;
    using Labyrinth.Models.Symbols;
    using Labyrinth.Logic.Interfaces;
    using Labyrinth.Common.Enum;

    public class StandartMoveLogic : MoveLogic
    {
        public StandartMoveLogic()
        {
        }

        public override void MakeMove(string command)
        {
            switch (command.ToLower())
            {
                case "d":
                    if (Board.Instance.AreSymbolsEqual(this.playerX + 1, this.Observer.PlayerY, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace)))
                    {
                        Board.Instance.ReplaceSymbol(this.playerX, this.Observer.PlayerY, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace));
                        Board.Instance.ReplaceSymbol(this.playerX + 1, this.Observer.PlayerY, SymbolFactory.GetSymbol(SymbolsEnum.Player));
                        this.Observer.PlayerX = this.playerX + 1;
                        this.Observer.CurrentScore = this.Observer.CurrentScore + 1;
                    }
                    break;
                case "u":
                    if (Board.Instance.AreSymbolsEqual(this.playerX - 1, this.Observer.PlayerY, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace)))
                    {
                        Board.Instance.ReplaceSymbol(this.playerX, this.Observer.PlayerY, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace));
                        Board.Instance.ReplaceSymbol(this.playerX - 1, this.Observer.PlayerY, SymbolFactory.GetSymbol(SymbolsEnum.Player));
                        this.Observer.PlayerX = this.playerX - 1;
                        Observer.CurrentScore = this.Observer.CurrentScore + 1;
                    }
                    break;
                case "r":
                    if (Board.Instance.AreSymbolsEqual(this.playerX, this.Observer.PlayerY + 1, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace)))
                    {
                        Board.Instance.ReplaceSymbol(this.playerX, this.Observer.PlayerY, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace));
                        Board.Instance.ReplaceSymbol(this.playerX, this.Observer.PlayerY + 1, SymbolFactory.GetSymbol(SymbolsEnum.Player));
                        Observer.PlayerY = this.Observer.PlayerY + 1;
                        Observer.CurrentScore = this.Observer.CurrentScore + 1;
                    }
                    break;
                case "l":
                    if (Board.Instance.AreSymbolsEqual(this.playerX, this.Observer.PlayerY - 1, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace)))
                    {
                        Board.Instance.ReplaceSymbol(this.playerX, this.Observer.PlayerY, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace));
                        Board.Instance.ReplaceSymbol(this.playerX, this.Observer.PlayerY - 1, SymbolFactory.GetSymbol(SymbolsEnum.Player));
                        Observer.PlayerY = this.Observer.PlayerY - 1;
                        Observer.CurrentScore = this.Observer.CurrentScore + 1;
                    }
                    break;
            }
        }
    }
}
