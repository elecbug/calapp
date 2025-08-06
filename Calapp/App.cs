namespace Calapp
{
    internal class App
    {
        private static App? _instance;

        public static App Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new App();
                }

                return _instance;
            }
        }

        public void Run()
        {
            while (true)
            {
                Console.Write("> ");
                string? input = Console.ReadLine();

                Command.Raw command = new Command.Raw(this, input ?? string.Empty);
                Command.Result result = command.Interpret();

                result.Run();
            }
        }
    }
}
