import { Component, OnInit } from '@angular/core';
import { Pizza } from '../../models/pizza.model';
import { Store } from '@ngrx/store';
import * as fromStore from '../../store';
import { observable } from 'rxjs';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css'],
})
export class ProductsComponent implements OnInit {
  // pizzas: Pizza[];

  constructor(private store: Store<fromStore.ProductsState>) {}

  ngOnInit() {
    this.store.select<any>('products').subscribe(state => {
      console.log(state);
    });
  }
}
