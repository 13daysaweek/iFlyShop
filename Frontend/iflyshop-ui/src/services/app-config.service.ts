import { Injectable, Injector } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AppConfigService {
  private appConfig;

  loadAppConfig() {
    const http = this.injector.get(HttpClient);

    return http.get(environment.configFileUri)
      .toPromise()
      .then(data => {
        this.appConfig = data;
      });
  }

  get config() {
    return this.appConfig;
  }

  constructor(private injector: Injector) { }
}
