namespace DroneMovement.Commands
{
    public interface ICommandFactory
    {
        char Command { get; }
        string Description { get; }

        void Run(string request, Position position);
    }
}
