import { Component, Injector, OnInit } from '@angular/core';
import { BaseComponent } from '../../../core/base-component';

@Component({
  selector: 'app-add-cart-modal',
  templateUrl: './add-cart-modal.component.html',
  styleUrls: ['./add-cart-modal.component.css']
})
export class AddCartModalComponent extends BaseComponent implements OnInit {

  items:any;
  total:any;
  constructor(injector: Injector) { 
    super(injector);
  }


  ngOnInit(): void {
    this._cart.items.subscribe((res) => {
      this.items = res;
      this.total = 0;
      for(let x of this.items){ 
        x.money = x.quantity * x.item_price;
        this.total += x.quantity * x.item_price;
      } 
    });
  }

}
