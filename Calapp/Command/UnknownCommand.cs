namespace Calapp.Command
{
    internal class UnknownCommand : Result
    {
        private string _command;

        public UnknownCommand(string command)
        {
            _command = command;
        }

        public override void Run()
        {
            throw new NotImplementedException();
        }
    }
}