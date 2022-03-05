import { AfterViewInit, Component, Injector, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BaseComponent } from '../../../core/base-component';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent extends BaseComponent implements OnInit, AfterViewInit {
  items:any;
  total:any;
  totalqty:number;
  constructor(injector: Injector, private router: Router) { 
    super(injector);
  }
  ngOnInit(): void {
    window.scroll(0,0);

    this._cart.items.subscribe((res) => {
      this.items = res;
      this.total = 0;
      this.totalqty = 0;
      for(let x of this.items){ 
        x.money = x.quantity * x.giaBan;
        this.total += x.quantity * x.giaBan;
        this.totalqty += 1;
      } 
    });
  }
  clearCart() { 
    this._cart.clearCart();
    alert('Xóa thành công');
  }
  addQty(item, quantity){ 
    item.quantity =  quantity;
    item.money =  Number.parseInt(item.quantity) *  item.giaBan;
    this._cart.addQty(item);
  }
  onHome() {
    this.router.navigate(['/'])
  }
  ngAfterViewInit() { 
    this.loadScripts(); 
   }
}
