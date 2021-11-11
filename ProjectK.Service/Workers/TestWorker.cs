using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ProjectK.Service.Workers
{
    public class TestWorker : IHostedService
    {
        private readonly ILogger<TestWorker> _logger;

        public TestWorker(ILogger<TestWorker> logger)
        {
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Test worker starting...");

            // Our stuff

            var result = new XpItem[] { };

            if (!result.Any())
            {
                // update
            }

            var calculatedResults = new XpItem[] { };

            var originalLevels = result.Select(r => r.Level).OrderBy(r => r).ToArray();
            var calculatedLevels = calculatedResults.Select(r => r.Level).OrderBy(r => r).ToArray();

            if (!calculatedLevels.SequenceEqual(originalLevels))
            {
                // update
            }

            var originalXp = result.Select(r => r.Experience).OrderBy(r => r).ToArray();
            var calculatedXp = calculatedResults.Select(r => r.Experience).OrderBy(r => r).ToArray();

            if (!calculatedXp.SequenceEqual(originalLevels))
            {
                // update
            }

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Test worker stopping...");

            return Task.CompletedTask;
        }
    }

    public class XpItem
    {
        public int Level { get; set; }
        public int Experience { get; set; }
    }
}