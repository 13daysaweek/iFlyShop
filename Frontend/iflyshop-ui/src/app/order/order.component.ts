import { Component, OnInit } from '@angular/core';

import { ShoppingCartService } from '../../services/shopping-cart.service';
import { MonitoringService } from '../../services/monitoring.service';

import { ShoppingCart } from '../../models/shoppingCart';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent implements OnInit {

  cart: ShoppingCart;

  get total(): number {
    const total = this.cart.items.map(_ => _.quantity * _.unitPrice).reduce((p, n) => p + n);

    return total;
  }

  placeOrder(): void {

  }

  constructor(private shoppingCartService: ShoppingCartService,
    private monitoringService: MonitoringService) { }

  ngOnInit() {
    this.cart = this.shoppingCartService.getCart();
    console.log(this.cart.total);
  }
}
