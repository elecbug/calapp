namespace Calapp.Command.Math
{
    internal class ShowCommand : BaseCommand
    {
        private App _app;
        private string _command;

        public ShowCommand(App app, string command)
        {
            _app = app;
            _command = command;
        }

        public override (string, ConsoleColor) Run()
        {
            if (string.IsNullOrEmpty(_command.Trim()))
            {
                return ("No variable specified. Use 'show [NAME]' to display a variable.", ConsoleColor.Red);
            }

            if (IsValidVariableName(_command) == false)
            {
                return ($"Invalid variable name '{_command}'. Variable names must start with a " +
                    $"letter or underscore and can only contain letters, numbers, and underscores.", ConsoleColor.Red);
            }

            if (_app.Variables.TryGetValue(_command, out decimal value))
            {
                return ($"{_command} = {value}", ConsoleColor.Green);
            }
            else
            {
                return ($"Variable '{_command}' does not exist.", ConsoleColor.Red);
            }
        }
    }
}