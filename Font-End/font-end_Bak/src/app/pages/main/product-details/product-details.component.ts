import { Component, Injector, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BaseComponent } from '../../../core/base-component';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent extends BaseComponent implements OnInit {
  public product:any;
  constructor(injector: Injector,private route: ActivatedRoute) { 
    super(injector);
  }
  categories:any;
  ngOnInit(): void {
    window.scroll(0,0);
     this.route.params.subscribe(params => {
      let id = params['id'];
      debugger;
      this._api.get('/api/client/product/' + id).takeUntil(this.unsubscribe).subscribe(res => {
        this.product = res;
        this.getRelated();
        setTimeout(() => {
          this.loadScripts();
        });
      });
    });
    this._api.get('/api/client/home/category-product').takeUntil(this.unsubscribe).subscribe(res => {
      this.categories = res;
    }); 
    
  }
  productRelated:any;
  getRelated()
  {
    this._api.get('/api/client/product/related?v=' + this.product.productCategoryCode).takeUntil(this.unsubscribe).subscribe(res => {
      this.productRelated=res;
    });
    console.log(this.productRelated);
  }

  addToCart(it) { 
    this._cart.addToCart(it);
    alert('Thêm thành công!'); 
  }
}
