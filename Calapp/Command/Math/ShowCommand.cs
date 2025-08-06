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

        public override (string, bool) Run()
        {
            if (string.IsNullOrEmpty(_command.Trim()))
            {
                return ("No variable specified. Use 'show varname' to display a variable.", false);
            }

            if (VarCommand.IsValidVariableName(_command) == false)
            {
                return ($"Invalid variable name '{_command}'. Variable names must start with a letter or underscore and can only contain letters, numbers, and underscores.", false);
            }

            if (_app.Variables.TryGetValue(_command, out decimal value))
            {
                return ($"{_command} = {value}", true);
            }
            else
            {
                return ($"Variable '{_command}' does not exist.", false);
            }
        }
    }
}