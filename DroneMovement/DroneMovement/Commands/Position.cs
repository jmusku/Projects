using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneMovement.Commands
{
    public class Position
    {
        public Position()
        {
            MaxPositionX = 0;
            MaxPositionY = 0;
            PositionX = 0;
            PositionY = 0;
            Facing = 'N';
        }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int MaxPositionX { get; set; }
        public int MaxPositionY { get; set; }
        public char Facing { get; set; }
        public char[] Directions { get => new char[] { 'N', 'E', 'W', 'S' }; }

        public void Navigate(int x, int y)
        {
            var prevX = PositionX;
            var prevY = PositionY;
            if (Facing == 'N' || Facing == 'S')
                PositionY = PositionY + y;
            else if (Facing == 'E' || Facing == 'W')
                PositionX = PositionX + x;
            else
                return;

            if (PositionX > MaxPositionX || PositionX < 0 || PositionY < 0 || PositionY > MaxPositionY) {
                PositionX = prevX;
                PositionY = prevY;
                Console.WriteLine("Out Of Limits");
            }
        }
        public void ChangeDirection(int dir)
        {
            int keyIndex = Array.FindIndex(Directions, f => f == Facing);
            keyIndex = keyIndex + dir;
            if (keyIndex == 4)
                keyIndex = 0;
            else if (keyIndex == -1)
                keyIndex = 3;
            Facing = Directions[keyIndex];
        }
    }
}
