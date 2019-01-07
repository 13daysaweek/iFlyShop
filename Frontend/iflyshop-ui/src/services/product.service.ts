import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { Product } from '../models/product';
import { AppConfigService } from '../services/app-config.service';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private apiUri: string;

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.apiUri);
  }

  constructor(private http: HttpClient,
    private appConfig: AppConfigService) {
      this.apiUri = `${appConfig.config.apiBaseUri}/product`;
     }
}
