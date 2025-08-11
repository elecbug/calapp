namespace Calapp.Command.Util
{
    internal class ExitCommand : BaseCommand
    {
        public override (string, ConsoleColor) Run()
        {
            Environment.Exit(0);
            
            return ("Exiting application...", ConsoleColor.Green);
        }
    }
}