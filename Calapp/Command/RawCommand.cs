using Calapp.Command.Math;
using Calapp.Command.Util;

namespace Calapp.Command
{
    internal class RawCommand
    {
        private App _app;
        private string _command;

        public RawCommand(App app, string command)
        {
            _app = app;
            _command = command;
        }

        private const string EXIT_COMMAND = "exit";
        private const string QUIT_COMMAND = "quit";
        private const string QUIT_COMMAND_SHORT = "q";
        private const string HELP_COMMAND = "help";
        private const string HELP_COMMAND_SHORT = "h";
        private const string CLEAR_COMMAND = "clear";
        private const string CLEAR_COMMAND_SHORT = "cls";

        private const string VAR_COMMAND = "var";
        private const string VAR_COMMAND_SHORT = "v";
        private const string SHOW_COMMAND = "show";
        private const string SHOW_COMMAND_SHORT = "s";
        private const string CALC_COMMAND = "calc";
        private const string CALC_COMMAND_SHORT = "c";
        private const string ARRAY_COMMAND = "arr";
        private const string ARRAY_COMMAND_SHORT = "a";
        private const string FUNCTION_COMMAND = "func";
        private const string FUNCTION_COMMAND_SHORT = "f";

        public static readonly string[] Keywords =
        [
            "exit", "quit", "q", "help", "h", "clear", "cls",
            "var", "v", "show", "s", "calc", "c", "arr", "a", "func", "f",
        ];

        public BaseCommand Interpret()
        {
            string[] parts = _command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length == 0)
            {
                parts = ["", ""];
            }
            else if (parts.Length == 1)
            {
                parts = [parts[0], ""];
            }
            else if (parts.Length > 2)
            {
                parts = [parts[0], string.Join(" ", parts.Skip(1))];
            }

            switch (parts[0].ToLower())
            {
                case EXIT_COMMAND:
                case QUIT_COMMAND:
                case QUIT_COMMAND_SHORT:
                    return new ExitCommand();
                case HELP_COMMAND:
                case HELP_COMMAND_SHORT:
                    return new HelpCommand();
                case CLEAR_COMMAND:
                case CLEAR_COMMAND_SHORT:
                    return new ClearCommand();
                case VAR_COMMAND:
                case VAR_COMMAND_SHORT:
                    return new VarCommand(_app, parts[1]);
                case SHOW_COMMAND:
                case SHOW_COMMAND_SHORT:
                    return new ShowCommand(_app, parts[1]);
                case CALC_COMMAND:
                case CALC_COMMAND_SHORT:
                    return new CalcCommand(_app, parts[1]);
                case ARRAY_COMMAND:
                case ARRAY_COMMAND_SHORT:
                    return new ArrayCommand(_app, parts[1]);
                case FUNCTION_COMMAND:
                case FUNCTION_COMMAND_SHORT:
                    return new FuncCommand(_app, parts[1]);
                default:
                    return new UnknownCommand(_command);
            }
        }
    }
}
