import { Injectable, Injector } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AppConfigServiceService {
  private appConfig;

  loadAppConfig() {
    const http = this.injector.get(HttpClient);

    return http.get('/assets/app-config.json')
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
