namespace Labyrinth.Models.Visitors
{
    using Labyrinth.Models;
    using Labyrinth.Models.Symbols;
    using Labyrinth.Logic.Interfaces;
    using Labyrinth.Common.Enum;
    using Models.Interfaces;

    public class StandartMoveLogicVisitor : IVisitor
    {
        private string command;

        public void SetVisitCommand(string command)
        {
            this.command = command;
        }

        public void Visit(IPlayer player)
        {
            switch (command.ToLower())
            {
                case "d":
                    if (Board.Instance.AreSymbolsEqual(player.GetX() + 1, player.GetY(), SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace)))
                    {
                        Board.Instance.ReplaceSymbol(player.GetX(), player.GetY(), SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace));
                        Board.Instance.ReplaceSymbol(player.GetX() + 1, player.GetY(), SymbolFactory.GetSymbol(SymbolsEnum.Player));
                        player.SetX(player.GetX() + 1);
                        player.SetScore(player.GetScore() + 1);
                    }
                    break;
                case "u":
                    if (Board.Instance.AreSymbolsEqual(player.GetX() - 1, player.GetY(), SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace)))
                    {
                        Board.Instance.ReplaceSymbol(player.GetX(), player.GetY(), SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace));
                        Board.Instance.ReplaceSymbol(player.GetX() - 1, player.GetY(), SymbolFactory.GetSymbol(SymbolsEnum.Player));
                        player.SetX(player.GetX() - 1);
                        player.SetScore(player.GetScore() + 1);
                    }
                    break;
                case "r":
                    if (Board.Instance.AreSymbolsEqual(player.GetX(), player.GetY() + 1, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace)))
                    {
                        Board.Instance.ReplaceSymbol(player.GetX(), player.GetY(), SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace));
                        Board.Instance.ReplaceSymbol(player.GetX(), player.GetY() + 1, SymbolFactory.GetSymbol(SymbolsEnum.Player));
                        player.SetY(player.GetY() + 1);
                        player.SetScore(player.GetScore() + 1);
                    }
                    break;
                case "l":
                    if (Board.Instance.AreSymbolsEqual(player.GetX(), player.GetY() - 1, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace)))
                    {
                        Board.Instance.ReplaceSymbol(player.GetX(), player.GetY(), SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace));
                        Board.Instance.ReplaceSymbol(player.GetX(), player.GetY() - 1, SymbolFactory.GetSymbol(SymbolsEnum.Player));
                        player.SetY(player.GetY() - 1);
                        player.SetScore(player.GetScore() + 1);
                    }
                    break;
            }
        }
    }
}
