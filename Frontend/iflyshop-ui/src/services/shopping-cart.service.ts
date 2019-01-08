import { Injectable } from '@angular/core';

import { ShoppingCart } from '../models/shoppingCart';
import { CartItem } from '../models/cartItem';
import { Product } from '../models/product';

import { MonitoringService } from './monitoring.service';

@Injectable({
  providedIn: 'root'
})
export class ShoppingCartService {
  private cartKey = 'cart';

  getCart(): ShoppingCart {
    const cartString = localStorage.getItem(this.cartKey);
    const cart = JSON.parse(cartString);

    return cart;
  }

  addItem(product: Product, quantity: number): void {
    let cartString = localStorage.getItem(this.cartKey);
    let cart: ShoppingCart;

    const item = new CartItem();
    item.productId = product.productId;
    item.quantity = quantity;
    item.unitPrice = product.unitPrice;
    item.name = product.name;

    if (cartString === null) {
      cart = new ShoppingCart();
      cart.items.push(item);
    } else {
      cart = JSON.parse(cartString);
      cart.items.push(item);
    }

    cartString = JSON.stringify(cart);
    localStorage.setItem(this.cartKey, cartString);
  }

  removeItem(productId: number): void {
    try {
      let cartString = localStorage.getItem(this.cartKey);
      let cart: ShoppingCart;

      cart = JSON.parse(cartString);
      const filteredItems = cart.items.filter((v, i, a) => {
        return v.productId !== productId;
      });

      cart.items = filteredItems;
      cartString = JSON.stringify(cart);
      // intentionally calling an invalid method here so we have an exception to log with App Insights :)
      localStorage.seItem(this.cartKey, cartString);
    } catch (err) {
      this.monitoringService.logException(err);
    }
  }

  constructor(private monitoringService: MonitoringService) { }
}
