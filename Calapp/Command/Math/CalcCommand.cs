using System.Data;
using System.Text.RegularExpressions;

namespace Calapp.Command.Math
{
    internal class CalcCommand : BaseCommand
    {
        private App _app;
        private string _command;

        public CalcCommand(App app, string command)
        {
            _app = app;
            _command = command;
        }

        public override (string, bool) Run()
        {
            if (string.IsNullOrEmpty(_command.Trim()))
            {
                return ("No expression provided. Use 'calc expression' to evaluate an expression.", false);
            }
            try
            {
                decimal result = EvaluateExpression(_app, _command);
                return ($"Result: {result}", true);
            }
            catch (Exception ex)
            {
                return ($"Error evaluating expression: {ex.Message}", false);
            }
        }

        internal static decimal EvaluateExpression(App app, string expression)
        {
            string pattern = @"\b[a-zA-Z_][a-zA-Z0-9_]*\b";

            string replaced = Regex.Replace(expression, pattern, match =>
            {
                string varName = match.Value;

                if (app.Variables.TryGetValue(varName, out decimal value))
                    return value.ToString();
                else
                    throw new ArgumentException($"Undefined variable: {varName}");
            });

            var table = new DataTable();
            return Convert.ToDecimal(table.Compute(replaced, string.Empty));
        }
    }
}