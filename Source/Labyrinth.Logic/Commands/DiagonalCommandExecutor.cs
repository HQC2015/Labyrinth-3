namespace Labyrinth.Logic.Commands
{
    using System;
    using Labyrinth.Logic.Interfaces;
    using Models.Interfaces;

    public class DiagonalCommandExecutor : CommandReceiver, ICommandExecutor
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
