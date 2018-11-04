using System;

namespace DroneMovement.Commands
{
    public class CheckPositionCommand : ICommandFactory
    {
        public char Command
        {
            get { return 'Q'; }
        }

        public string Description
        {
            get { return "Check Position"; }
        }

        public void Run(string request, Position position)
        {
            Console.WriteLine("Drone position is PostionX: {0} PostionY: {1} Direction: {2}", position.PositionX, position.PositionY, position.Facing);
        }
    }
}
