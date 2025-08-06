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
        private const string HELP_COMMAND = "help";
        private const string CLEAR_COMMAND = "clear";

        private const string VAR_COMMAND = "var";
        private const string VAR_COMMAND_SHORT = "v";
        private const string SHOW_COMMAND = "show";
        private const string SHOW_COMMAND_SHORT = "s";
        private const string CALC_COMMAND = "calc";
        private const string CALC_COMMAND_SHORT = "c";

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
                    return new ExitCommand();
                case HELP_COMMAND:
                    return new HelpCommand();
                case CLEAR_COMMAND:
                    return new ClearCommand();
                default:
                    if (parts[0] == VAR_COMMAND || parts[0] == VAR_COMMAND_SHORT)
                    {
                        return new VarCommand(_app, parts[1]);
                    }

                    else if (parts[0] == SHOW_COMMAND || parts[0] == SHOW_COMMAND_SHORT)
                    {
                        return new ShowCommand(_app, parts[1]);
                    }

                    else if (parts[0] == CALC_COMMAND || parts[0] == CALC_COMMAND_SHORT)
                    {
                        return new CalcCommand(_app, parts[1]);
                    }

                    else
                    {
                        return new UnknownCommand(_command);
                    }
            }
        } 
    }
}
