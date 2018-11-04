using System;

namespace DroneMovement.Commands
{
    public class MoveForwardCommand: ICommandFactory
    {
        public char Command
        {
            get { return 'M'; }
        }

        public string Description
        {
            get { return "Move Forward"; }
        }

        public void Run(string request, Position position)
        {
            if (position.Facing == 'N')
                position.Navigate(0, 1);
            else if (position.Facing == 'S')
                position.Navigate(0, -1);
            else if (position.Facing == 'E')
                position.Navigate(1, 0);
            else if (position.Facing == 'W')
                position.Navigate(-1, 0);
            else
                return;
        }

    }
}
