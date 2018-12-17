using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ThirteenDaysAWeek.iFlyShop.Api.Telemetry
{
    public class DependencyTracker : IDependencyTracker
    {
        private readonly ITelemetryService _telemetryService;

        public DependencyTracker(ITelemetryService telemetryService)
        {
            _telemetryService = telemetryService ?? throw new ArgumentNullException(nameof(telemetryService));
        }

        public async Task<TReturnType> TrackDependencyAsync<TReturnType>(Func<Task<TReturnType>> dependencyCall, string target,
            string dependencyType, string dependencyName,
            string data)
        {
            var startTime = DateTime.UtcNow;
            var timer = Stopwatch.StartNew();
            var success = false;
            var returnVal = default(TReturnType);

            try
            {
                returnVal = await dependencyCall();
                success = true;
            }
            finally
            {
                timer.Stop();
                _telemetryService.LogDependency(target, dependencyType, dependencyName, startTime, timer.Elapsed, success, data);
            }

            return returnVal;
        }

        public async Task TrackDependencyAsync(Func<Task> dependencyCall, string target, string dependencyType,
            string dependencyName,
            string data)
        {
            var startTime = DateTime.UtcNow;
            var timer = Stopwatch.StartNew();
            var success = false;

            try
            {
                await dependencyCall();
                success = true;
            }
            finally
            {
                timer.Stop();
                _telemetryService.LogDependency(target, dependencyType, dependencyName, startTime, timer.Elapsed,
                    success, data);
            }
        }
    }
}