namespace Calapp.Command
{
    internal class Var : Result
    {
        private string _command;

        public Var (string command)
        {
            _command = command;
        }

        public override void Run()
        {
            throw new NotImplementedException();    
        }
    }
}
