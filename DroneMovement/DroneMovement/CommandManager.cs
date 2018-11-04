using DroneMovement.Commands;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DroneMovement
{
    public class CommandManager
    {
        readonly IEnumerable<ICommandFactory> existingCommands;

        public CommandManager(IEnumerable<ICommandFactory> existingCommands)
        {
            this.existingCommands = existingCommands;
        }

        internal void RunCommand(string request, Position position)
        {
            var elements = request.Split(' ')?.ToList();
            position.MaxPositionX = int.Parse(elements[0]);
            position.MaxPositionY = int.Parse(elements[1]);
            position.PositionX = int.Parse(elements[2]);
            position.PositionY = int.Parse(elements[3]);
            position.Facing = char.Parse(elements[4]);

            var otherCommands = elements[5].ToCharArray();
            foreach (char cmd in otherCommands) {
                var command = IsValidCommand(cmd);
                command.Run(request, position);
            }

        }

        ICommandFactory IsValidCommand(char command)
        {
            return existingCommands.FirstOrDefault(cmd => cmd.Command == command);
        }

        bool checkForNavigateCommand(string command) {
            var elements = command.Split(' ')?.ToList();
            if (elements.Count == 5 && Regex.IsMatch(elements[0], @"\d") && Regex.IsMatch(elements[1], @"\d") && Regex.IsMatch(elements[2], @"\d") && Regex.IsMatch(elements[3], @"\d"))
                return true;
            else
                return false;
        }  
    }
}
