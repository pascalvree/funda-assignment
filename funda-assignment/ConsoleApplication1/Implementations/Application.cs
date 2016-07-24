using ConsoleApplication1.Interfaces;

using log4net;

namespace ConsoleApplication1.Implementations
{
    public class Application
    {
        private readonly IWriter writer;
        private readonly ILog logger = LogManager.GetLogger(typeof(Application));

        public Application(IWriter writer)
        {
            this.writer = writer;
        }

        public void Run()
        {
            this.logger.Info(nameof(Application) + " started.");
            this.writer.WriteLine("Hello World!");
            this.logger.Info(nameof(Application) + " finished.");
        }
    }
}