namespace Calapp.Command.Math
{
    internal class ArrayCommand : BaseCommand
    {
        private App _app;
        private string _command;

        public ArrayCommand(App app, string command)
        {
            _app = app;
            _command = command;
        }

        public override (string, ConsoleColor) Run()
        {
            return ("Array commands are not implemented yet.", ConsoleColor.Yellow);
        }
    }
}
