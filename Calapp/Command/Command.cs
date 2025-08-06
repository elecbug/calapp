namespace Calapp.Command
{
    internal class Raw
    {
        private App _app;
        private string _command;

        public Raw(App app, string command)
        {
            _app = app;
            _command = command;
        }

        public Result Interpret()
        {
            switch (_command.ToLower())
            {
                case "exit":
                case "quit":
                    return new Exit();
                case "help":
                    return new Help();
                case "clear":
                    return new Clear();
                default:
                    if (_command.StartsWith("var "))
                    {
                        return new Var(_command.Substring(4));
                    }
                    else
                    {
                        return new UnknownCommand(_command);
                    }
            }
        } 
    }
}
