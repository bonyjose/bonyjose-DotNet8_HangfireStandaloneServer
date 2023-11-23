using Hangfire;
using TestLibrary;

namespace HangfireServerCore
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IBackgroundJobClient _backgroundJobs;


        public Worker(ILogger<Worker> logger
                            ,IBackgroundJobClient backgroundJobs
            )
        {
            _backgroundJobs = backgroundJobs;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                //_backgroundJobs.Enqueue(() => Console.WriteLine("Hello world from Hangfire!"));
                BackgroungProcess backgroungProcess = new BackgroungProcess();
                backgroungProcess.execute();
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}