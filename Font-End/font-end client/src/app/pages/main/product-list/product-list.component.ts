import { Component, Injector, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BaseComponent } from '../../../core/base-component';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent extends BaseComponent implements OnInit {
  public list_item: any;
  public page = 1;
  public pageSize = 5;
  public totalItems:any;
public categories:any

  
  constructor(injector: Injector,private route: ActivatedRoute, private router: Router) { 
    super(injector);
    
  }

  ngOnInit(): void {
    window.scroll(0,0);
    this.route.params.subscribe(params => {
      let id = params['id'];
      this._api.post('/api/SanPham/get-product-by-category',{page: this.page, pageSize: this.pageSize, maloai: id}).takeUntil(this.unsubscribe).subscribe(res => {
        this.list_item = res.data;
        this.totalItems = res.totalItems;
        setTimeout(() => {
          this.loadScripts();
        });
      });
    });
     this._api.get('/api/LoaiSanPham/get-all').takeUntil(this.unsubscribe).subscribe(res => {
      this.categories = res;
     

    }); 
  }

  loadPage(page) { 
    console.log(this.pageSize);
    this._route.params.subscribe(params => {
      let id = params['id'];
      this._api.post('/api/SanPham/get-product-by-category', { page: page, pageSize: this.pageSize, maloai: id}).takeUntil(this.unsubscribe).subscribe(res => {
        this.list_item = res.data;
        this.totalItems = res.totalItems;
        }, err => { });       
   });   
  }

  addToCart(it) { 
    this._cart.addToCart(it);
    alert('Thêm thành công!'); 
  }
}
