namespace Labyrinth.Models.Visitors
{
    using Labyrinth.Common.Enum;
    using Labyrinth.Logic.Commands;
    using Labyrinth.Models;
    using Labyrinth.Models.Interfaces;
    using Labyrinth.Models.Symbols;

    public class StandartMoveVisitor : IVisitor
    {
        private string command;

        public void SetVisitCommand(string command)
        {
            this.command = command;
        }

        public void Visit(IPlayer player)
        {
            switch (this.command.ToLower())
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
