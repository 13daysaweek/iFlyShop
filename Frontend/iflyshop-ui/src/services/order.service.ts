import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

import { ShoppingCart } from '../models/shoppingCart';
import { Order } from '../models/order';
import { OrderLineItem } from '../models/orderLineItem';
import { OrderResponse } from '../models/orderResponse';

import { MonitoringService } from './monitoring.service';
import { AppConfigService } from '../services/app-config.service';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  placeOrder(cart: ShoppingCart): Observable<OrderResponse> {
    const orderUrl = `${this.appConfig.config.apiBaseUri}/order`;
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    const order = new Order();
    order.customerId = 1; // TODO:  something other than hardcode :)
    cart.items.forEach(element => {
      const lineItem = new OrderLineItem();
      lineItem.productId = element.productId;
      lineItem.quantity = element.quantity;
      order.items.push(lineItem);
    });

    return this.http.post<OrderResponse>(orderUrl, order, httpOptions);
  }

  constructor(private http: HttpClient,
    private monitoringService: MonitoringService,
    private appConfig: AppConfigService) { }
}
