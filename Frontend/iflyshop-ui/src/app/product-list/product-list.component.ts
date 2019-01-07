import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { Product } from '../../models/product';
import { MonitoringService } from '../../services/monitoring.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  products: Product[];

  getProducts(): void {
    this.monitoringService.logTrace('Loading products for product-list component');
    this.productService.getProducts()
      .subscribe(_ => this.products = _);
  }

  constructor(private productService: ProductService,
    private monitoringService: MonitoringService) { }

  ngOnInit() {
    this.getProducts();
  }
}
