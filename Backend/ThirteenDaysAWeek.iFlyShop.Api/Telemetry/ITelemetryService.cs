using System;
using System.Collections.Generic;
using Microsoft.ApplicationInsights.DataContracts;

namespace ThirteenDaysAWeek.iFlyShop.Api.Telemetry
{
    public interface ITelemetryService
    {
        void Error(Exception exception, string message = null);
        void Trace(string message, SeverityLevel level = SeverityLevel.Information);
        void LogEvent(string eventName, IDictionary<string, string> args = null);

        void LogDependency(string target, string dependencyType, string dependencyName, DateTime startTime,
            TimeSpan elapsedTime, bool success, string data);
    }
}