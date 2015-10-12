namespace Labyrinth.Models.Visitors
{
    using Labyrinth.Logic.Commands;
    using Labyrinth.Models.Interfaces;
    using Labyrinth.Models.Symbols;
    using Labyrinth.Common.Enum;

    public class DiagonalMoveVisitor : IVisitor
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
                case "ur":
                    if (Board.Instance.AreSymbolsEqual(player.GetX() - 1, player.GetY() + 1, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace)))
                    {
                        Board.Instance.ReplaceSymbol(player.GetX(), player.GetY(), SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace));
                        Board.Instance.ReplaceSymbol(player.GetX() - 1, player.GetY() + 1, SymbolFactory.GetSymbol(SymbolsEnum.Player));
                        player.SetX(player.GetX() - 1);
                        player.SetY(player.GetY() + 1);
                        player.SetScore(player.GetScore() + 1);
                    }

                    break;
                case "ul":
                    if (Board.Instance.AreSymbolsEqual(player.GetX() - 1, player.GetY() - 1, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace)))
                    {
                        Board.Instance.ReplaceSymbol(player.GetX(), player.GetY(), SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace));
                        Board.Instance.ReplaceSymbol(player.GetX() - 1, player.GetY() - 1, SymbolFactory.GetSymbol(SymbolsEnum.Player));
                        player.SetX(player.GetX() - 1);
                        player.SetY(player.GetY() - 1);
                        player.SetScore(player.GetScore() + 1);
                    }

                    break;
                case "dr":
                    if (Board.Instance.AreSymbolsEqual(player.GetX() + 1, player.GetY() + 1, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace)))
                    {
                        Board.Instance.ReplaceSymbol(player.GetX(), player.GetY(), SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace));
                        Board.Instance.ReplaceSymbol(player.GetX() + 1, player.GetY() + 1, SymbolFactory.GetSymbol(SymbolsEnum.Player));
                        player.SetX(player.GetX() + 1);
                        player.SetY(player.GetY() + 1);
                        player.SetScore(player.GetScore() + 1);
                    }
                       
                    break;
                case "dl":
                    if (Board.Instance.AreSymbolsEqual(player.GetX() + 1, player.GetY() - 1, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace)))
                    {
                        Board.Instance.ReplaceSymbol(player.GetX(), player.GetY(), SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace));
                        Board.Instance.ReplaceSymbol(player.GetX() + 1, player.GetY() - 1, SymbolFactory.GetSymbol(SymbolsEnum.Player));
                        player.SetX(player.GetX() + 1);
                        player.SetY(player.GetY() - 1);
                        player.SetScore(player.GetScore() + 1);
                    }

                    break;
            }
        }
    }
}
