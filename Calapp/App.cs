namespace Calapp
{
    internal class App
    {
        private static App? _instance;
        private Dictionary<string, decimal> _variables = new Dictionary<string, decimal>();

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
        public Dictionary<string, decimal> Variables
        {
            get { return _variables; }
        }

        public void Run()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("> ");
                string? input = Console.ReadLine();

                if (string.IsNullOrEmpty(input?.Trim(' ')))
                {
                    continue; // Skip empty input
                }

                Command.RawCommand command = new Command.RawCommand(this, input ?? string.Empty);
                Command.BaseCommand result = command.Interpret();

                (string, bool) res = result.Run();

                if (res.Item2)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                Console.WriteLine(res.Item1);
            }
        }
    }
}
