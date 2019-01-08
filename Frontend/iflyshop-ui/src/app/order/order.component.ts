import { Component, OnInit } from '@angular/core';

import { ShoppingCartService } from '../../services/shopping-cart.service';
import { MonitoringService } from '../../services/monitoring.service';
import { OrderService } from '../../services/order.service';

import { ShoppingCart } from '../../models/shoppingCart';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent implements OnInit {

  cart: ShoppingCart;
  message: string;

  get total(): number {
    const total = this.cart.items.map(_ => _.quantity * _.unitPrice).reduce((p, n) => p + n);

    return total;
  }

  placeOrder(): void {
    this.orderService.placeOrder(this.cart)
      .subscribe(_ => {
        this.message = `You order was successfully placed, your order number is ${_.orderNumber}`;
        this.monitoringService.logEvent('UI.OrderSubmitted', { 'orderNumber': _.orderNumber });
      });
  }

  constructor(private shoppingCartService: ShoppingCartService,
    private monitoringService: MonitoringService,
    private orderService: OrderService) { }

  ngOnInit() {
    this.cart = this.shoppingCartService.getCart();
  }
}
