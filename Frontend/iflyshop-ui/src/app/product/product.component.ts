import { Component, OnInit, Input } from '@angular/core';

import { MonitoringService } from '../../services/monitoring.service';
import { ShoppingCartService } from '../../services/shopping-cart.service';

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

  removeItemFromCart(): void {
    this.shoppingCartService.removeItem(this.product.productId);
  }

  addItemToCart(): void {
    this.shoppingCartService.addItem(this.product, this.quantity);
  }

  constructor(private monitoringService: MonitoringService,
    private shoppingCartService: ShoppingCartService) { }

  ngOnInit() {
  }

}
