using System;

namespace DroneMovement.Commands
{
    public class TurnLeftCommand: ICommandFactory
    {
        public char Command
        {
            get { return 'L'; }
        }

        public string Description
        {
            get { return "Turn Left"; }
        }

        public void Run(string request, Position position)
        {
            position.ChangeDirection(-1);
        }
    }
}
