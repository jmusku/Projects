using System;

namespace DroneMovement.Commands
{
    public class InvalidCommand: ICommandFactory
    {
        public char Command
        {
            get { return 'I'; }
        }

        public string Description
        {
            get { return "Invalid Command"; }
        }

        public void Run(string request, Position position)
        {
            Console.WriteLine("Its a invalid command");
        }
    }
}
