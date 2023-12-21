using CommandPattern.Core;
using CommandPattern.Core.Contracts;

namespace CommandPattern
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ICommandInterpreter commandInterpeter = new CommandInterpreter();

            IEngine engine = new Engine(commandInterpeter);

            engine.Run();
        }
    }
}
