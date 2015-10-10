namespace Labyrinth.Logic.Commands
{
    using System;
    using Models.Interfaces;

    public class DiagonalCommandExecutor : CommandExecutor, ICommandExecutor
    {
        public void Execute(string command, IPlayer player)
        {
            throw new NotImplementedException();
        }

        public override void ProcessCommand(string command, IPlayer player)
        {
            throw new NotImplementedException();
        }

        public string Undo(string command)
        {
            throw new NotImplementedException();
        }

        public override void UnProcessCommand(string command, IPlayer player)
        {
            throw new NotImplementedException();
        }
    }
}
