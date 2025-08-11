namespace Calapp.Command.Util
{
    internal class HelpCommand : BaseCommand
    {
        public override (string, ConsoleColor) Run()
        {
            return (
                "Available commands:\n" +
                "  exit, quit - Exit the application\n" +
                "  help - Show this help message\n" +
                "  clear - Clear the console\n" +
                "  var [NAME] = [VALUE] - Define a variable with the given name\n" +
                "  show [NAME] - Show the value of the variable with the given name\n" +
                "  calc [EXPERSSION] - Calculate the given mathematical expression\n",
                ConsoleColor.Yellow
            );
        }
    }
}