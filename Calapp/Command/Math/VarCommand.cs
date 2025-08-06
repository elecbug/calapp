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

        public override (string, bool) Run()
        {
            string[] parts = _command.Split('=').Select(x => x.Trim()).ToArray();

            if (parts.Length != 2)
            {
                return ("Invalid variable assignment. Use 'varname = value' format.", false);
            }

            try
            {
                decimal result = CalcCommand.EvaluateExpression(_app, parts[1]);

                _app.Variables[parts[0]] = result;

                if (IsValidVariableName(parts[0]))
                {
                    return ($"Variable '{parts[0]}' set to {result}.", true);
                }
                else
                {
                    return ($"Invalid variable name '{parts[0]}'. Variable names must start with a letter or underscore and can only contain letters, numbers, and underscores.", false);
                }
            }
            catch (Exception ex)
            {
                return ($"Error setting variable '{parts[0]}': {ex.Message}", false);
            }
        }

        private static readonly string[] Keywords = 
        [
            "exit", "quit", "help", "clear", 
            "var", "v", "show", "s", "calc", "c",
        ];

        public static bool IsValidVariableName(string input, bool excludeKeywords = true)
        {
            var regex = new Regex(@"^[a-zA-Z_][a-zA-Z0-9_]*$");

            if (!regex.IsMatch(input))
                return false;

            if (excludeKeywords && Array.Exists(Keywords, kw => kw == input))
                return false;

            return true;
        }
    }
}
