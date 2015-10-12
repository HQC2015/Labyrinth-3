namespace Labyrinth.Console
{
    using System;
    using Logic.Contracts;

    public class InputHandler : IInputHandler
    {
        public string GetInput()
        {
            return Console.ReadLine();
        }
    }
}
