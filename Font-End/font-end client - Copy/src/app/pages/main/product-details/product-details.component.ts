import { Component, ElementRef, Injector, OnDestroy, OnInit, Renderer2,VERSION  } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BaseComponent } from '../../../core/base-component';
import { takeUntil } from 'rxjs/operators';
import * as $ from 'jquery';
@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent extends BaseComponent implements OnInit,OnDestroy {
  public product:Array<any>=[];
  public productRelated:Array<any>=[];
  public productItemSet:Array<any>=[];
  public Images:Array<any>=[];
 

  constructor(injector: Injector,private route: ActivatedRoute, private router: Router,private elementRef: ElementRef, private renderer: Renderer2) { 
    super(injector);
    
  }
  categories:any;
  ngOnInit(): void {
   
    
  }
  ngAfterContentInit():void{
  
    this.route.params.subscribe(params => {
     let UrlProduct = params['url'];
     this.getDetail(UrlProduct)
    });
  }

  getDetail(url){
    this._api.serverContraint("usp_B10Product_Detail",[url]).takeUntil(this.unsubscribe).subscribe(res => {
      this.product = res.Table;
      this.Images = res.Table1;
      this.productItemSet= res.Table2;
      this.productRelated =res.Table3;
      this.recallJsFuntions()
      this.removeZoom()
     
    }); 
   
  }
  navigatorProduct(url: string)
  {
    this.getDetail(url);
    var zoomContainer = document.querySelectorAll('.zoomContainer');
  }
  
  getRelated()
  {
    this._api.get('/api/client/product/related?v=' + this.product[0].productCategoryCode).takeUntil(this.unsubscribe).subscribe(res => {
      this.productRelated=res;
    });
    const myElement = this.elementRef.nativeElement.querySelector('#scroll-top');
    this.renderer.selectRootElement(myElement).click();
  }

 
   

  addToCart(it) { 
    this._cart.addToCart(it);
    alert('Thêm thành công!'); 
  }
  boo : boolean = false;
  routerSubscription: any;
 
  ngOnDestroy(): void {
   this.recallJsFuntions();
  }
 
}

