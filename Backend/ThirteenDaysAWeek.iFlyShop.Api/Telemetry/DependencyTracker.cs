using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ThirteenDaysAWeek.iFlyShop.Api.Telemetry
{
    public class DependencyTracker : IDependencyTracker
    {
        public DependencyTracker()
        {
            
        }

        public async Task<TReturnType> TrackDependencyAsync<TReturnType>(Func<TReturnType> dependencyCall, string target,
            string dependencyType, string dependencyName,
            string data)
        {
            var startTime = DateTime.UtcNow;
            var timer = Stopwatch.StartNew();
            var success = false;
            var returnVal = default(TReturnType);

            try
            {
                   
            }
            finally
            {

            }

            return returnVal;
        }

        public async Task TrackDependencyAsync(Action dependencyCall, string target, string dependencyType,
            string dependencyName,
            string data)
        {
            throw new NotImplementedException();
        }
    }
}