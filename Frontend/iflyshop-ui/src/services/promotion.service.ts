import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { Promotion } from '../models/promotion';
import { AppConfigService } from '../services/app-config.service';

@Injectable({
  providedIn: 'root'
})
export class PromotionService {
  private apiUri: string;

  getPromotions(): Observable<Promotion> {
    return this.http.get<Promotion>(this.apiUri);
  }

  constructor(private http: HttpClient,
    private appConfig: AppConfigService) {
      this.apiUri = `${appConfig.config.apiBaseUri}/promotion/1`;
    }
}
