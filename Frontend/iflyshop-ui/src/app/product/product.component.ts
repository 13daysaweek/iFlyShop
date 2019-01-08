import { Component, OnInit, Input } from '@angular/core';

import { MonitoringService } from '../../services/monitoring.service';
import { Product } from '../../models/product';
import { CartItem } from '../../models/cartItem';
import { ShoppingCart } from '../../models/shoppingCart';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  @Input() product: Product;

  quantity: number;

  addItemToCart(): void {
    const cartKey = 'cart';
    let cartString = localStorage.getItem(cartKey);
    let cart: ShoppingCart;

    const item = new CartItem();
    item.productId = this.product.productId;
    item.quantity = this.quantity;
    item.unitPrice = this.product.unitPrice;

    if (cartString === null) {
      cart = new ShoppingCart();
      cart.items.push(item);
    } else {
      cart = JSON.parse(cartString);
      cart.items.push(item);
    }

    cartString = JSON.stringify(cart);
    localStorage.setItem(cartKey, cartString);
  }

  constructor(private monitoringService: MonitoringService) { }

  ngOnInit() {
  }

}
