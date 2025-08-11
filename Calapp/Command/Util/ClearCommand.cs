namespace Calapp.Command.Util
{
    internal class ClearCommand : BaseCommand
    {
        public override (string, ConsoleColor) Run()
        {
            Console.Clear();
            
            return ("Console cleared.", ConsoleColor.Green);
        }
    }
}