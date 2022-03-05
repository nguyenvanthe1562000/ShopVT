import { AfterViewInit, Component, Injector, OnInit } from '@angular/core';
import { BaseComponent } from '../../../core/base-component';
import 'rxjs/add/observable/combineLatest';
import 'rxjs/add/operator/takeUntil';


import { environment } from '../../../../environments/environment'

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent extends BaseComponent implements OnInit {
  public categories:any;
  public product:any;
  public blog:any;
  constructor(injector: Injector) {
    super(injector);
  }
  ngOnInit(): void {
    window.scroll(0,0);
    this._api.get('/api/LoaiSanPham/get-home').takeUntil(this.unsubscribe).subscribe(res => {
      this.categories = res;
      setTimeout(() => {
        this.loadScripts();
      });
    }); 
        this.getProductHome();
        this.getBlogHome();
        this.url=environment.apiUrl;
  }
url:any;
  getProductHome()
  {
    this._api.get('/api/SanPham/get-home').takeUntil(this.unsubscribe).subscribe(res => {
      this.product = res;
     
    }); 
  }
  getBlogHome()
  {
    this._api.get('/api/TinTuc/get-home').takeUntil(this.unsubscribe).subscribe(res => {
      this.blog = res;
    }); 
  }
  addToCart(it) { 
    this._cart.addToCart(it);
    alert('Thêm thành công!'); 
  }
}
