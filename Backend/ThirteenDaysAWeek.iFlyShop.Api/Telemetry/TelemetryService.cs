﻿using System;
using System.Collections.Generic;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;

namespace ThirteenDaysAWeek.iFlyShop.Api.Telemetry
{
    public class TelemetryService : ITelemetryService
    {
        private readonly TelemetryClient _telemetryClient =
            new TelemetryClient(new TelemetryConfiguration(""));

        public void Error(Exception exception, string message = null)
        {
            var telemetry = new ExceptionTelemetry(exception);

            if (!string.IsNullOrWhiteSpace(message))
            {
                telemetry.Properties.Add("message", message);
            }

            _telemetryClient.TrackException(telemetry);
        }

        public void Trace(string message, SeverityLevel level = SeverityLevel.Information)
        {
            var telemetry = new TraceTelemetry(message, level);
            _telemetryClient.TrackTrace(telemetry);
        }

        public void LogEvent(string eventName, IDictionary<string, string> args = null)
        {
            _telemetryClient.TrackEvent(eventName, args);
        }

        public void LogDependency(string target, string dependencyType, string dependencyName, DateTime startTime,
            TimeSpan elapsedTime, bool success, string data)
        {
            var dependencyData = new DependencyTelemetry(dependencyType, target, dependencyName, data, startTime, elapsedTime, success.ToString(), success);
            _telemetryClient.TrackDependency(dependencyData);
        }
    }
}