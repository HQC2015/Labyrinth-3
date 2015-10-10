namespace Labyrinth.Console
{
    using System;
    using Labyrinth.Logic.Contracts;

    public class InputHandler : IInputHandler
    {
        private string command;

        public string Command
        {
            get
            {
                return this.command;
            }

            private set 
            {
                this.command = value;
            }
        }

        public string GetInput()
        {
            return Console.ReadLine();
        }
    }
}
