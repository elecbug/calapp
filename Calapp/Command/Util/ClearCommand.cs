namespace Calapp.Command.Util
{
    internal class ClearCommand : BaseCommand
    {
        public override (string, bool) Run()
        {
            Console.Clear();
            
            return ("Console cleared.", true);
        }
    }
}