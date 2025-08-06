namespace Calapp.Command.Util
{
    internal class ExitCommand : BaseCommand
    {
        public override (string, bool) Run()
        {
            Environment.Exit(0);
            
            return ("Exiting application...", true);
        }
    }
}