import { Component, Injector, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PagedResult } from 'src/app/shared/model/PageResult';
import { FilterType, PagingRequest } from 'src/app/shared/model/PagingRequest';
import { BaseComponent } from '../../../core/base-component';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent extends BaseComponent implements OnInit {
  public list_item: any;
  public page = 1;
  public pageSize = 12;
  public totalItems: any;
  public filter: PagingRequest;
  public categories: any
  public listItem: PagedResult<any>;
  api: string = "/api/client/product";
  constructor(injector: Injector, private route: ActivatedRoute, private router: Router) {
    super(injector);
    this.filter = new PagingRequest();
    this.listItem = new PagedResult<any>();
  }

  ngOnInit(): void {
    this.filter.PageIndex = this.page;
    this.filter.PageSize = this.pageSize;
    this.filter.DataIsActive = true;
    this.filter.FilterColumn = 'Code,Name';
    this.filter.FilterValue = '';
    this.filter.FilterType = FilterType.Contains;
    window.scroll(0, 0);
    this.route.params.subscribe(params => {
      this.filter.FilterValue = params['id'];
      this.Filter(this.filter);
    });
    this._api.get('/api/client/home/category-product').takeUntil(this.unsubscribe).subscribe(res => {
      this.categories = res;
    });
  }
  Filter(PagingRequest: PagingRequest) {
    let orderBy = PagingRequest.OrderBy;
    this.route.params.subscribe(params => {
      this._api.post(`${this.api}/filter`, { pageIndex: PagingRequest.PageIndex, pageSize: PagingRequest.PageSize, orderBy: PagingRequest.OrderBy, orderDesc: PagingRequest.OrderDesc, filterColumn: PagingRequest.FilterColumn, filterType: PagingRequest.FilterType, filterValue: PagingRequest.FilterValue, ParentId: PagingRequest.ParentId, dataIsActive: PagingRequest.DataIsActive }).takeUntil(this.unsubscribe).subscribe(res => {
        this.listItem.PageIndex = res.pageIndex ? res.pageIndex : 1;
        this.listItem.PageSize = res.pageSize ? res.pageSize : 10;
        this.listItem.PageCount = res.pageCount;
        this.listItem.TotalRecords = res.totalRecords;
        this.listItem.Items = res.items;
        setTimeout(() => {
          this.loadScripts();
        });
      }, err => { console.log(err) });
    });
  }

  loadPage(page) {
    console.log(this.pageSize);
    this._route.params.subscribe(params => {
      let id = params['id'];
      this._api.post('/api/SanPham/get-product-by-category', { page: page, pageSize: this.pageSize, maloai: id }).takeUntil(this.unsubscribe).subscribe(res => {
        this.list_item = res.data;
        this.totalItems = res.totalItems;
      }, err => { });
    });
  }
  OrderBy(event) {
    debugger;
    if (event.target.value == '1') {
      this.filter.OrderBy = 'ProductName';
      this.filter.OrderDesc = true;
    }
    else if (event.target.value == '2') {
      this.filter.OrderBy = 'ProductName';
      this.filter.OrderDesc = false;
    }
    else if (event.target.value == '3') {
      this.filter.OrderBy = 'ProductPrice';
      this.filter.OrderDesc = true;
    }
    else if (event.target.value == '4') {
      this.filter.OrderBy = 'ProductPrice';
      this.filter.OrderDesc = false;
    }
    this.Filter(this.filter);


  }
  addToCart(it) {
    this._cart.addToCart(it);
    alert('Thêm thành công!');
  }
}
