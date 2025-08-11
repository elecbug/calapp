namespace Calapp.Command.Util
{
    internal class UnknownCommand : BaseCommand
    {
        private string _command;

        public UnknownCommand(string command)
        {
            _command = command;
        }

        public override (string, ConsoleColor) Run()
        {
            return ($"Unknown command: {_command}. Type 'help' for a list of commands.", ConsoleColor.Red);
        }
    }
}