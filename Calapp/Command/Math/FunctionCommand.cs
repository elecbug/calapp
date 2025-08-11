namespace Calapp.Command.Math
{
    internal class FunctionCommand : BaseCommand
    {
        private App _app;
        private string _command;

        public FunctionCommand(App app, string command)
        {
            _app = app;
            _command = command;
        }

        public override (string, ConsoleColor) Run()
        {
            if (string.IsNullOrEmpty(_command.Trim()))
            {
                return ("No function specified. Use 'function [NAME]([PARAMS])=[EXPRESSION]' to define a function.", ConsoleColor.Red);
            }

            if (!IsValidFunctionName(_command))
            {
                return ($"Invalid function definition '{_command}'. " +
                        "Function names must start with a letter or underscore and can only contain letters, numbers, and underscores.", ConsoleColor.Red);
            }

            string[] parts = _command.Trim().Split('=').Select(x => x.Trim()).ToArray();

            if (parts.Length != 2 || !parts[0].Contains('(') || !parts[0].EndsWith(')'))
            {
                return ("Invalid function definition. Use 'function [NAME]([PARAMS])=[EXPRESSION]' format.", ConsoleColor.Red);
            }

            string functionName = parts[0].Substring(0, parts[0].IndexOf('(')).Trim();
            string[] parameters = parts[0].Substring(parts[0].IndexOf('(') + 1, parts[0].LastIndexOf(')') - parts[0].IndexOf('(') - 1).Split(',').Select(x => x.Trim()).ToArray();
            string expression = parts[1].Trim();

            _app.Functions[functionName] = (parameters, expression);

            return ($"Function '{_command}' defined successfully.", ConsoleColor.Green);
        }
    }
}
