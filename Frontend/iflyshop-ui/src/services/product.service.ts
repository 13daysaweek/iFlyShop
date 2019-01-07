import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { Product } from '../models/product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private apiUril = 'http://localhost:1130/api/product'; // TODO:  Move to config

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.apiUril);
  }

  constructor(private http: HttpClient) { }
}
