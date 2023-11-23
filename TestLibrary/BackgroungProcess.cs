using Hangfire;

namespace TestLibrary
{
    public class BackgroungProcess
    {
        public void execute()
        {
            BackgroundJob.Enqueue(() => Console.WriteLine("Hello, world!"));
        }
    }
}
