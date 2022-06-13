import { Component, Injector, OnInit } from '@angular/core';
import { BaseComponent } from '../../../core/base-component';
import 'rxjs/add/observable/combineLatest';
import 'rxjs/add/operator/takeUntil';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-manage-products-group',
  templateUrl: './manage-products-group.component.html',
  styleUrls: ['./manage-products-group.component.css']
})
export class ManageProductsGroupComponent extends BaseComponent implements OnInit {
  public products_group:any;
  public page = 1;
  public pageSize = 3;
  public totalItems:any;
  constructor(injector: Injector,private route: ActivatedRoute, private router: Router) {
    super(injector);
   }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this._api.post('/api/NhomSanPham/group-all-paginate',{page: this.page, pageSize: this.pageSize}).takeUntil(this.unsubscribe).subscribe(res => {
        this.products_group = res.data;
        this.totalItems = res.totalItems;
        setTimeout(() => {
          this.loadScripts();
        });
      });
    });
  }
  displayAdd: boolean = false;

  showAdd() {
      this.displayAdd = true;
  }
  loadPage(page) { 
    this._route.params.subscribe(params => {
      this._api.post('/api/NhomSanPham/group-all-paginate', { page: page, pageSize: this.pageSize}).takeUntil(this.unsubscribe).subscribe(res => {
        this.products_group = res.data;
        this.totalItems = res.totalItems;
        }, err => { });       
   });   
  }
}
