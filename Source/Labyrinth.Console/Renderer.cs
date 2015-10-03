namespace Labyrinth.Console
{
    using System;
    using System.Collections.Generic;
    using Labyrinth.Logic.Contracts;
    using Labyrinth.Models;
    using Labyrinth.Models.Contracts;
    using Labyrinth.Models.Players;
    using Labyrinth.Common;

    public class Renderer : IRenderer
    {
        public void RenderMessage()
        {
            Console.WriteLine();
        }

        public void RenderMessage(string msg)
        {
            Console.WriteLine(msg);
        }

        public void RenderBoard(Board board)
        {
            for (int i = 0; i < GlobalConstants.LabyrinthSizeRow; i++)
            {
                for (int j = 0; j < GlobalConstants.LabyrinthSizeCol; j++)
                {
                    Console.Write(board.Field[i, j].GetValue() + " ");
                }

                Console.WriteLine();
            }
        }

        public void RenderScoreboard(Scoreboard scoreboard)
        {
            List<Player> players = scoreboard.GetPlayers;

            this.RenderMessage();
            if (players.Count == 0)
            {
                this.RenderMessage(Messages.ScoreboardEmptyMessage);
            }
            else
            {
                this.RenderMessage("Top 5: \n");
                foreach (var player in players)
                {
                    int scoreNumber = players.IndexOf(player) + 1;
                    this.RenderMessage(string.Format("{0}. {1} - {2} moves.", scoreNumber, player.GetName(), player.GetScore()));
                }

                this.RenderMessage();
            }
        }
    }
}
