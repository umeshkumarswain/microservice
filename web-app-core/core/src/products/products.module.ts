import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { StoreModule } from '@ngrx/store';
import { ProductsComponent } from './containers/products/products.component';
import { ProductitemComponent } from './containers/productitem/productitem.component';
import { reducers } from './store';
import { BrowserModule } from '@angular/platform-browser';
//Components
// import * as fromComponents from './components';

//Containers
// import * as fromContainers from './containers';

//Services
// import * as fromServices from './services';

export const ROUTES: Routes = [
  { path: '', component: ProductsComponent },
  // {path:'id',component:ProductItemComponent}
  // {path:'new',component:ProductsComponent}
];
@NgModule({
  declarations: [ProductsComponent],
  imports: [
    BrowserModule,
    CommonModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule.forChild(ROUTES),
    StoreModule.forFeature('products', reducers),
  ],
  providers: [],
  exports: [ProductsComponent],
})
export class ProductsModule {}
