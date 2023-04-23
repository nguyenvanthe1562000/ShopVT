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
  public productPc:any;
  public productlk:any;
  public slide:any;
  public blog:any;
  api: string = "api/client/home";
  constructor(injector: Injector) {
    super(injector);

  }
  ngOnInit(): void {
    window.scroll(0,0);
    this._api.get('/api/client/home/category-product').takeUntil(this.unsubscribe).subscribe(res => {
      this.categories = res;
     
    }); 
    setTimeout(() => {
      this.loadScripts();
    });
        this.getProductlaptop();
        this.getProductPc();
        this.getSlide();
        this.getProductLinhkien();
        this.getPost();
        this.url=environment.apiUrl;
  }
url:any;
getSlide()
{
  this._api.get('/api/client/home/slide-header').takeUntil(this.unsubscribe).subscribe(res => {
    this.slide = res;
    console.log(this.slide);
   
  }); 
}
  getProductlaptop()
  {
    this._api.get('/api/client/home/product-laptop').takeUntil(this.unsubscribe).subscribe(res => {
      this.product = res;
     
    }); 
  }
  getProductPc()
  {
    this._api.get('/api/client/home/product-pc').takeUntil(this.unsubscribe).subscribe(res => {
      this.productPc = res;
     
    }); 
  }
  getProductLinhkien()
  {
    this._api.get('/api/client/home/product-linhkien').takeUntil(this.unsubscribe).subscribe(res => {
      this.productlk= res;
     
    }); 
  }
  post:any;
  getPost()
  {
    this._api.get('/api/client/home/post').takeUntil(this.unsubscribe).subscribe(res => {
      this.post= res;
     
    }); 
  }
  addToCart(it) { 
    this._cart.addToCart(it);
    alert('Thêm thành công!'); 
  }
}
