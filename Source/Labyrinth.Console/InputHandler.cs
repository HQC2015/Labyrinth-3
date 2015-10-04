namespace Labyrinth.Console
{
    using System;
    using Labyrinth.Logic.Contracts;

    public class InputHandler : IInputHandler
    {
        private string command;

        public InputHandler()
        {
            this.Command = Console.ReadLine();
        }

        public string Command
        {
            get
            {
                return this.command;
            }
            private set 
            {
                //for (int i = 0; i < GlobalConstants.legalCommands.Length - 1; i++)
                //{
                //    if (GlobalConstants.legalCommands[i] == value)
                //    {
                //        this.command = value;
                //    }
                //    else
                //    {
                //        this.renderer.RenderMessage("Invalid command!");
                //
                //    }
                //}
                this.command = value;
            }
        }

        public string GetInput()
        {
            return Console.ReadLine();
        }
    }
}
