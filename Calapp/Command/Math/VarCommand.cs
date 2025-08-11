using System.Text.RegularExpressions;

namespace Calapp.Command.Math
{
    internal class VarCommand : BaseCommand
    {
        private App _app;
        private string _command;

        public VarCommand(App app, string command)
        {
            _app = app;
            _command = command;
        }

        public override (string, ConsoleColor) Run()
        {
            string[] parts = _command.Split('=').Select(x => x.Trim()).ToArray();

            if (parts.Length != 2)
            {
                return ("Invalid variable assignment. Use 'var [VAR NAME] = [VALUE]' format.", ConsoleColor.Red);
            }

            try
            {
                decimal result = CalcCommand.EvaluateExpression(_app, parts[1]);

                _app.Variables[parts[0]] = result;

                if (IsValidVariableName(parts[0]))
                {
                    return ($"Variable '{parts[0]}' set to {result}.", ConsoleColor.Green);
                }
                else
                {
                    return ($"Invalid variable name '{parts[0]}'. " +
                        $"Variable names must start with a letter or underscore and can only " +
                        $"contain letters, numbers, and underscores.", ConsoleColor.Red);
                }
            }
            catch (Exception ex)
            {
                return ($"Error setting variable '{parts[0]}': {ex.Message}", ConsoleColor.Red);
            }
        }
    }
}
