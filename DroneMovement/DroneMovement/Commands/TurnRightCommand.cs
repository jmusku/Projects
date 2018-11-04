using System;

namespace DroneMovement.Commands
{
    public class TurnRightCommand : ICommandFactory
    {
        public char Command
        {
            get { return 'R'; }
        }

        public string Description
        {
            get { return "Turn Right"; }
        }

        public void Run(string request, Position position)
        {
            position.ChangeDirection(1);
        }
    }
}
