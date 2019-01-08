import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductListComponent } from './product-list/product-list.component';
import { OrderComponent } from './order/order.component';

const routes: Routes = [
  { path: '', redirectTo: '/products', pathMatch: 'full' },
  { path: 'order', component: OrderComponent },
  { path: 'products', component: ProductListComponent }
];

@NgModule({
    exports: [ RouterModule ],
    imports: [ RouterModule.forRoot(routes) ]
})
export class AppRoutingModule { }
