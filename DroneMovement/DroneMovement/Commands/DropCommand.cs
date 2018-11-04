using System;
using System.Linq;

namespace DroneMovement.Commands
{
    public class DropCommand: ICommandFactory
    {
        public char Command
        {
            get { return 'D'; }
        }

        public string Description
        {
            get { return "Drop"; }
        }

        public void Run(string request, Position position)
        {
            var elements = request.Split(' ')?.ToArray();
            position.MaxPositionX = int.Parse(elements[0]);
            position.MaxPositionY = int.Parse(elements[1]);
            position.PositionX = int.Parse(elements[2]);
            position.PositionY = int.Parse(elements[3]);
            position.Facing = char.Parse(elements[4].ToUpper());            
        }
    }
}
