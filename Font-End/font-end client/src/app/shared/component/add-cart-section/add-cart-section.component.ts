import { Component, Injector, OnInit } from '@angular/core';
import { BaseComponent } from '../../../core/base-component';
import { environment } from '../../../../environments/environment'
@Component({
  selector: 'app-add-cart-section',
  templateUrl: './add-cart-section.component.html',
  styleUrls: ['./add-cart-section.component.css']
})
export class AddCartSectionComponent extends BaseComponent implements OnInit {
  items:any;
  total:any;
  url:string;
  constructor(injector: Injector) { 
    super(injector);
   this.url= environment.apiUrl;
  }

  ngOnInit(): void {
    this._cart.items.subscribe((res) => {
      this.items = res;
      this.total = 0;
      for(let x of this.items){ 
        x.money = x.quantity * x.giaBan;
        this.total += x.quantity * x.giaBan;
      } 
    });
  } 
  clearCart() { 
    this._cart.clearCart();
    alert('Xóa thành công');
  }
  delete(maSanPham){
    this._cart.deleteItem(maSanPham);
  }
  addQty(item, quantity){ 
    item.quantity =  quantity;
    item.money =  Number.parseInt(item.quantity) *  item.giaBan;
    this._cart.addQty(item);
  }

}
