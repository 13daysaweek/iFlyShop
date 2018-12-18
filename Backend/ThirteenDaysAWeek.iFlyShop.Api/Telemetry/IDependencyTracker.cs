using System;
using System.Threading.Tasks;

namespace ThirteenDaysAWeek.iFlyShop.Api.Telemetry
{
    public interface IDependencyTracker
    {
        Task<TReturnType> TrackDependencyAsync<TReturnType>(Func<Task<TReturnType>> dependencyCall, string target,
            string dependencyType, string dependencyName, string data);

        Task TrackDependencyAsync(Func<Task> dependencyCall, string target, string dependencyType, string dependencyName,
            string data);
    }
}