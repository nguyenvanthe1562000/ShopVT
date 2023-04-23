import { AfterViewInit,ViewChild, Component, Injector, OnInit,ElementRef, OnDestroy } from '@angular/core';
import { BaseComponent } from '../../../core/base-component';
import 'rxjs/add/observable/combineLatest';
import 'rxjs/add/operator/takeUntil';
import { takeUntil } from 'rxjs/operators';
import * as $ from 'jquery';
import { environment } from '../../../../environments/environment'
import { Router } from '@angular/router';
 

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent extends BaseComponent implements OnInit,OnDestroy {
  @ViewChild('myVideo') myVideo: any;
  public categories:any;
  public product:any;
  public productPc:any;
  public productlk:any;
  public slide:any;
  public blog:any;
  api: string = "api/client/home";
  constructor(injector: Injector,private elementRef: ElementRef,private router:Router) {
    super(injector);
 

  }


 
  ngOnInit(): void {
    window.scroll(0,0);
  
    this._api.get('/api/client/home/category-product').takeUntil(this.unsubscribe).subscribe(res => {
      this.categories = res;
      this.recallJsFuntions();
    }); 
        this.getHome();
        this.getProductlaptop();
        this.getProductPc();
        this.getSlide();
        this.getProductLinhkien();
        this.getPost();
       
        
  }
  
  routerSubscription: any;
  
  ngOnDestroy(): void {
  }
XuHuong :any;  
getHome(){
  this._api.serverContraint("usp_Home",[]).pipe(takeUntil(this.unsubscribe)).subscribe(res => {
    this.XuHuong = res.Table1;
    // setTimeout(() => {
    //   this.loadScripts();
    // });
  });
}
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
