using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;

namespace ThirteenDaysAWeek.iFlyShop.Api.Telemetry
{
    public class TelemetryService : ITelemetryService
    {
        private readonly TelemetryClient _telemetryClient;

        public TelemetryService(string instrumentationKey)
        {
            if (string.IsNullOrWhiteSpace(instrumentationKey))
            {
                throw new ArgumentException(nameof(instrumentationKey));
            }

            _telemetryClient = new TelemetryClient(new TelemetryConfiguration(instrumentationKey));
        }

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

            // TODO:  Need to figure out how to correlate these with the current request.  While below does get us the current operation id, it seems like what
            // we really need is request id
            var operationId = Activity.Current?.RootId;
            dependencyData.Context.Operation.ParentId = operationId;
            dependencyData.Context.Operation.Id = Guid.NewGuid().ToString();

            _telemetryClient.TrackDependency(dependencyData);
        }
    }
}