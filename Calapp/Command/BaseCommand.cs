using System.Text.RegularExpressions;

namespace Calapp.Command
{
    internal abstract class BaseCommand
    {
        public abstract (string, ConsoleColor) Run();

        protected static bool IsValidVariableName(string input, bool excludeKeywords = false)
        {
            var regex = new Regex(@"^[a-zA-Z_][a-zA-Z0-9_]*$");

            if (!regex.IsMatch(input))
                return false;

            if (excludeKeywords && Array.Exists(RawCommand.Keywords, kw => kw == input))
                return false;

            return true;
        }

        protected static bool IsValidFunctionName(string command)
        {
            string pattern = @"^[a-zA-Z_][a-zA-Z0-9_]*\s*\(.*\).*$";
            return Regex.IsMatch(command, pattern);
        }
    }
}
