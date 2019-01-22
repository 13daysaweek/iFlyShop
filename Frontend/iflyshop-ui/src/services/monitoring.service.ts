import { Injectable } from '@angular/core';
import { AppInsights } from 'applicationinsights-js';
import { AppConfigService } from '../services/app-config.service';

@Injectable({
  providedIn: 'root'
})
export class MonitoringService {
  private config: Microsoft.ApplicationInsights.IConfig;

  logPageView(name?: string,
    url?: string,
    properties?: any,
    measurements?: any,
    duration?: number) {
      AppInsights.trackPageView(name, url, properties, measurements, duration);
    }

  logEvent(name: string, properties?: any, measurements?: any) {
    AppInsights.trackEvent(name, properties, measurements);
  }

  logTrace(message: string, properties?: any, severityLevel?: any) {
    AppInsights.trackTrace(message, properties, severityLevel);
  }

  logException(e: any) {
    AppInsights.trackException(e);
  }

  constructor(private appConfig: AppConfigService) {
    const iKey = appConfig.config.instrumentationKey;

    this.config = {
      instrumentationKey: iKey
    };

    if (!AppInsights.config) {
      AppInsights.downloadAndSetup(this.config);
      AppInsights.config.samplingPercentage = 100;
      AppInsights.queue.push(() => {
        AppInsights.context.addTelemetryInitializer((envelope: Microsoft.ApplicationInsights.IEnvelope) => {
          const ti = envelope.data.baseData;
          ti.properties = ti.properties || {};
          ti.properties['cloud_RoleName'] = 'iFlyShop UI';
        });
      });
    }
  }
}
