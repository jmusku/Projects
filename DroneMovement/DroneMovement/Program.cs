using DroneMovement.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DroneMovement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Command or E for Exit");
            var request = Console.ReadLine();
            var existingPosition = new Position();
            var existingCommands = GetExistingCommands();
            if (!CheckForValidCommand(request))
            {
                PrintCommands(existingCommands);
            }
            else
            {
                var parser = new CommandManager(existingCommands);
                parser.RunCommand(request, existingPosition);
            }
            Console.WriteLine("Thank You");
            Console.Read();
        }

        static bool CheckForValidCommand(string command)
        {
            var elements = command.Split(' ')?.ToList();
            if (elements.Count == 6 && Regex.IsMatch(command, @"\d\s\d\s\d\s\d\s+[NEWS]\s[QMRL]"))
                return true;
            else
                return false;
        }

        static IEnumerable<ICommandFactory> GetExistingCommands()
        {
            return new ICommandFactory[]
                {
                    new DropCommand(),
                    new MoveForwardCommand(),
                    new TurnLeftCommand(),
                    new TurnRightCommand(),
                    new CheckPositionCommand()
                };
        }

        private static void PrintCommands(IEnumerable<ICommandFactory> availableCommands)
        {
            Console.WriteLine("Please use the existing commands:");
            foreach (var command in availableCommands)
                Console.WriteLine("{0} for {1}", command.Command, command.Description);
        }
    }
}
