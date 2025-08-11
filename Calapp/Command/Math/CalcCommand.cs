using System.Data;
using System.Text.RegularExpressions;

namespace Calapp.Command.Math
{
    internal class CalcCommand : BaseCommand
    {
        private App _app;
        private string _command;

        private const string FUNC_PATTERN = @"^[a-zA-Z_][a-zA-Z0-9_]*\s*\(.*\).*$";
        private const string VAR_PATTERN = @"\b[a-zA-Z_][a-zA-Z0-9_]*\b";

        public CalcCommand(App app, string command)
        {
            _app = app;
            _command = command;
        }

        public override (string, ConsoleColor) Run()
        {
            if (string.IsNullOrEmpty(_command.Trim()))
            {
                return ("No expression provided. Use 'calc [EXPRESSION]' to evaluate an expression.", ConsoleColor.Red);
            }
            try
            {
                decimal result = EvaluateExpression(_app, _command);
                return ($"Result: {result}", ConsoleColor.Green);
            }
            catch (Exception ex)
            {
                return ($"Error evaluating expression: {ex.Message}", ConsoleColor.Red);
            }
        }

        internal static decimal EvaluateExpression(App app, string expression)
        {
            string replaced = expression.Trim();
            replaced = ValueReplace(app, replaced);
            replaced = FuncReplace(app, expression);

            var table = new DataTable();

            return Convert.ToDecimal(table.Compute(replaced, string.Empty));
        }

        private static string FuncReplace(App app, string expression)
        {
            return Regex.Replace(expression, FUNC_PATTERN, match =>
            {
                string[] parts = match.Value.Trim().Split('(');
                string funcName = parts[0].Trim();
                string argsPart = parts.Length > 1 ? parts[1].TrimEnd(')') : string.Empty;

                decimal[] rawArgs = argsPart.Split(',').Select(x => x.Trim()).Select(x => decimal.TryParse(x, out var val)
                    ? val : throw new ArgumentException($"Invalid argument: {x}")).ToArray();

                if (app.Functions.TryGetValue(funcName, out var function))
                {
                    Dictionary<string, decimal> args = new Dictionary<string, decimal>();
                    string[] parameters = function.Item1;

                    for (int i = 0; i < parameters.Length; i++)
                    {
                        args[parameters[i]] = rawArgs[i];
                    }

                    return FuncCommand.CalcFunc(app, function, args).ToString();
                }
                else
                {
                    throw new ArgumentException($"Undefined function: {funcName}");
                }
            });
        }

        private static string ValueReplace(App app, string expression)
        {
            return Regex.Replace(expression, VAR_PATTERN, match =>
            {
                string varName = match.Value;

                if (app.Variables.TryGetValue(varName, out decimal value))
                    return value.ToString();
                else
                    throw new ArgumentException($"Undefined variable: {varName}");
            });
        }
    }
}