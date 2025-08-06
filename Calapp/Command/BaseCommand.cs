namespace Calapp.Command
{
    internal abstract class BaseCommand
    {
        public abstract (string, bool) Run();
    }
}
