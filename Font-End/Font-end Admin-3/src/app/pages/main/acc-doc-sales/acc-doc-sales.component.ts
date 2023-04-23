 
import { Component, Injector, OnInit,HostListener} from '@angular/core';
import { BaseComponent } from '../../../core/base-component';
import 'rxjs/add/operator/takeUntil';
import { ActivatedRoute, Router } from '@angular/router';
import { AbstractControl, FormBuilder, NgForm } from '@angular/forms';
import { from, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { FilterType, PagingRequest } from '../../../shared/models/PagingRequest';
import { PagedResult } from '../../../shared/models/PageResult';
import { catchError, map } from 'rxjs/operators';
import { formatDate } from '@angular/common';
import { HttpHeaders } from '@angular/common/http';
import { GroupData } from '../../../shared/models/GroupData';

import { css } from 'jquery';
import { stringify } from 'querystring';
import { vB10Product } from 'src/app/shared/models/B10Product';
import { vB20AccDoc_Sales } from 'src/app/shared/models/B20AccDoc_Sales';
interface FilterTypeColumn { value: string, viewValue: string }
interface FilterTypeValue { value: FilterType, viewValue: string }

@Component({
  selector: 'app-acc-doc-sales',
  templateUrl: './acc-doc-sales.component.html',
  styleUrls: ['./acc-doc-sales.component.css']
})
export class AccDocSalesComponent extends BaseComponent implements OnInit {
  //exploredata
  public tintuc: any;
  public page = 1;
  public totalItems: any;
  public filter: PagingRequest;
  public listItem: PagedResult<vB20AccDoc_Sales>;
  public checkFilter: boolean;
  public ClickColumn: string = '';
  public api: string = '/api/accdoc-sales' ;
  public groupData: GroupData;
  public selectGroup: any;
  public selectItem: vB20AccDoc_Sales;
  public filterTypeColumn: any;
  public filterTypeValue: any;
  public displayFormGroup: boolean = false;
 
  public formData = new FormData();
  public addType: number = 0; //thao tác lưu dữ liệu vd 0: lưu và thêm mới
  public lookupProduct: vB10Product;
 
  //editordata
  public displayUpdate: boolean = false;
  public displayConvert: boolean = false;// chuyển nhóm dữ liệu
  displayAdd: boolean = false;
  constructor(private fb: FormBuilder, private httpclient: HttpClient, injector: Injector, private route: ActivatedRoute, private router: Router) {
    super(injector);
    this.filter = new PagingRequest();
    this.listItem = new PagedResult<vB20AccDoc_Sales>();
    this.selectItem = new vB20AccDoc_Sales();
  }

  ngOnInit(): void {
    debugger;
    this.filter.PageIndex = this.page;
    this.filter.DataIsActive = true;
    this.filter.OrderBy="DocStatus,DocDate";
    this.Filter(this.filter);

  }
  @HostListener('window:keydown.f5', ['$event'])
  bigFont(event: KeyboardEvent) {
    event.preventDefault();
    this.Filter(this.filter);
  }
  //start //explore

  InitValueFormFilter(value: string = null) {
    if (value) {
      this.filter.FilterValue = value;
    }
    this.filterTypeColumn = [{ value: `${this.filter.FilterColumn}`, viewValue: `Cột hiện thời "${this.filter.FilterColumn}"` }, { value: '*', viewValue: 'Tất cả các cột' }];
    if (this.filter.FilterValue) {
      this.filterTypeValue = [
        { value: FilterType.Contains, viewValue: `Chứa nội dung "${this.filter.FilterValue}"` }
        , { value: FilterType.StartsWith, viewValue: `Nội dung bắt đầu với "${this.filter.FilterValue}"` }
        , { value: FilterType.EndsWith, viewValue: `Nội dung kết thúc với "${this.filter.FilterValue}"` }
        , { value: FilterType.Equals, viewValue: `Nội dung tương tự "${this.filter.FilterValue}"` }
        , { value: FilterType.NotEmpty, viewValue: `Nội dung khác rỗng "${this.filter.FilterValue}"` }
        , { value: FilterType.Empty, viewValue: `Nội dung rỗng "${this.filter.FilterValue}"` }
      ];
      if (Number(this.filter.FilterValue)) {
        // add value filer
        this.filterTypeValue.push({ value: FilterType.GreaterThan, viewValue: `Lớn hơn "${this.filter.FilterValue}"` });
        this.filterTypeValue.push({ value: FilterType.LessThan, viewValue: `Nhỏ hơn "${this.filter.FilterValue}"` });
        this.filterTypeValue.push({ value: FilterType.Equals, viewValue: `Bằng "${this.filter.FilterValue}"` });
      }
    }
    else {
      this.filterTypeValue = [
        { value: FilterType.NotEmpty, viewValue: `Nội dung khác rỗng ` }
        , { value: FilterType.Empty, viewValue: `Nội dung rỗng ` }
      ];
    }
  }

  Filter(PagingRequest: PagingRequest) {
    let orderBy = PagingRequest.OrderBy;
    this.route.params.subscribe(params => {
      this._api.post(`${this.api}/filter`, { pageIndex: PagingRequest.PageIndex, pageSize: PagingRequest.PageSize, orderBy: PagingRequest.OrderBy, orderDesc: PagingRequest.OrderDesc, filterColumn: PagingRequest.FilterColumn, filterType: PagingRequest.FilterType, filterValue: PagingRequest.FilterValue, ParentId: PagingRequest.ParentId, dataIsActive: PagingRequest.DataIsActive }).takeUntil(this.unsubscribe).subscribe(res => {
        this.listItem.PageIndex = res.pageIndex?res.pageIndex:1;
        this.listItem.PageSize = res.pageSize?  res.pageSize:10;
        this.listItem.PageCount = res.pageCount;
        this.listItem.TotalRecords = res.totalRecords;
        this.listItem.Items = res.items;
        setTimeout(() => {
          this.loadScripts();
        });
      }, err => { console.log(err) });
    });
  }
  OrderBy(column: string) {
    this.filter.OrderBy = column;
    this.filter.OrderDesc = !this.filter.OrderDesc;
    this.Filter(this.filter);
  }
  loadPage(page) {
    this.filter.PageIndex = page;
    this.Filter(this.filter);
  }
  ChangeColorColumnIsClick(column: string) {
    if (column == this.filter.FilterColumn) {
      document.getElementById(this.filter.FilterColumn).style.backgroundColor = '#f8f9fa';
      this.filter.FilterColumn = null;
      return;
    }
    else if (!this.ClickColumn) {
      this.ClickColumn = column;
    }
    else if (this.filter.FilterColumn != column) {
      if (this.filter.FilterColumn == '*') {
        document.getElementById(this.ClickColumn).style.backgroundColor = '#f8f9fa';
      }
      else if (this.filter.FilterColumn) {
        document.getElementById(this.filter.FilterColumn).style.backgroundColor = '#f8f9fa';
      }
    }
    this.filter.FilterColumn = column;
    document.getElementById(column).style.backgroundColor = 'aqua';
    this.InitValueFormFilter();
  }

  IsActive() {
    this.filter.ParentId = 0;
    this.filter.DataIsActive = false;
    this.Filter(this.filter);
  }
  search(form: NgForm) {
    console.log(this.filter);
    this.Filter(this.filter);
  }
  ShowGroup() {
    this.displayAdd = true;
  }

  nodeSelect(event?, item?: any) {
    this.filter.DataIsActive = true;
    if (item != undefined) {
      if (item.isGroup == true) {
        this.filter.ParentId = item.id;
        this.Filter(this.filter);
      }
    }
    else {
      this.filter.ParentId = event.node.data;
      this.Filter(this.filter);
      return;
    }
  }
  //end  //explore
  showAdd()
  {
    this.router.navigate(['/acc-doc-sales-edit']);
  }
  showEdit(item)
  {
    this.router.navigate(['/acc-doc-sales-edit/'+item]);
  }
  Delete(id: number) {
    if (confirm("Bạn có chắc chắn muốn xóa?")) {
      this._api.deleteParamUrl(`${this.api}`,id).takeUntil(this.unsubscribe).subscribe(res => {
        this.Filter(this.filter);
        alert(res.messages[0].message)
      });
    }
  }

  Lookup(str: any) {
    debugger;
    this._api.getLookup(`product`,str.query).takeUntil(this.unsubscribe).subscribe(res => {
      this.lookupProduct = res;
    });
  }
  GetById(id: number) {   
    debugger;
      this._api.get(`${this.api}/${id}`,).takeUntil(this.unsubscribe).subscribe(res => {

      });    
  }

  Restore(id: number) {
    if (confirm("Bạn có chắc chắn muốn khôi phục?")) {
      this._api.putParamUrl(`${this.api}/restore`, id).takeUntil(this.unsubscribe).subscribe(res => {
        this.Filter(this.filter);
        alert(res.messages[0].message)
      });
    }
    //end data editor
  }
   
}

