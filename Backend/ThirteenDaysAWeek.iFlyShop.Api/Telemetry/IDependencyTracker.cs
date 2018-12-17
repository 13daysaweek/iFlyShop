using System;
using System.Threading.Tasks;

namespace ThirteenDaysAWeek.iFlyShop.Api.Telemetry
{
    public interface IDependencyTracker
    {
        Task<TReturnType> TrackDependencyAsync<TReturnType>(Func<TReturnType> dependencyCall, string target,
            string dependencyType, string dependencyName, string data);

        Task TrackDependencyAsync(Action dependencyCall, string target, string dependencyType, string dependencyName,
            string data);
    }
}