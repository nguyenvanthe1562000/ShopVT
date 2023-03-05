
import { Component, Injector, OnInit } from '@angular/core';
import { BaseComponent } from '../../../core/base-component';
import 'rxjs/add/observable/combineLatest';
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
import { vB20Order } from 'src/app/shared/models/vB20Order';
interface FilterTypeColumn { value: string, viewValue: string }
interface FilterTypeValue { value: FilterType, viewValue: string }

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent extends BaseComponent implements OnInit {
  //exploredata
  public tintuc: any;
  public page = 1;
  public pageSize = 20;
  public totalItems: any;
  public filter: PagingRequest;
  public listItem: PagedResult<vB20Order>;
  public checkFilter: boolean;
  public ClickColumn: string = '';
  public api: string = '/api/order' ;
  public selectGroup: any;
  public selectItem: vB20Order;
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
    this.listItem = new PagedResult<vB20Order>();
  
    this.selectItem = new vB20Order();
  }

  ngOnInit(): void {
    this.filter.PageIndex = this.page;
    this.filter.PageSize = this.pageSize;
    this.filter.DataIsActive = true;
    this.filter.OrderBy = "orderStatus";
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

  /// DataEditor

  showAdd() {
    this.displayAdd = true;
    this.displayEditChild = true;
    this.displayEditGroup=false;
  }
  showEdit(item: any) {
    this.selectItem = item;
    this.displayUpdate = true;
   this.GetById(item.id)
    if (item.isGroup == true) {
      this.displayEditGroup = true;
      this.displayEditChild = false;
    }
    else {
      this.displayEditGroup = false;
      this.displayEditChild = true;
    }

  }
  displayEditGroup: boolean = false;
  showAddGroup() {
    this.displayEditGroup = true;
    this.displayEditChild = false;
  }
  displayEditChild: boolean = false;
  showAddChild() {
    this.displayEditGroup = false;
    this.displayEditChild = true;
  }

  SelectForeignKey(event:any,foreignKey: string)
  {
    debugger;
    this.formData.append(foreignKey, event.code);
    this.selectItem.orderStatusName=event.name;
  }
  SelectForeignKeyGrid(event:any,foreignKey: string)
  {
    this.formData.append(foreignKey, event.code);
    this.newAttribute.productCode=event.code;
    this.newAttribute.productName = event.name;
    this.newAttribute.unit = event.unit;
    this.newAttribute.image = event.image;
  }
  //grid
  fieldArray: Array<any> = [];
  newAttribute: any = {};
  newAttributeChild: any = {};
  addFieldValue() {
      this.fieldArray.push(this.newAttribute)
      this.newAttribute = {};
  }
  deleteFieldValue(index) {
    this.fieldArray.splice(index, 1);
  }
  //end grid

  SelectFile(event: any, name: string, isMultiple: boolean) {
    if (isMultiple) {
      event.target.files.forEach(element => {
        this.formData.append(name, element);
      });
    }
    else {
      this.formData.append(name, event.target.files[0]);
    }
  }
  //data editor
  Add(form: NgForm, addDataIsGroup: boolean, addType: number) {

    

    let obj:vB20Order = new vB20Order();
    this.ConvertNgFormToFormData(form,this.formData);
    
    this.formData.append('vB20OrderDetail', JSON.stringify(this.fieldArray));
    this.ConvertFormDataToObject(obj, this.formData);  
 debugger;
    this._api.post(`${this.api}/add`, obj).takeUntil(this.unsubscribe).subscribe(res => {
      alert(res.messages[0].message)
      this.formData = new FormData();
      this.Filter(this.filter);
    });
    if (addType == 0) {
      form.resetForm();
    }
    else if (addType == 1) {
      form.control['code'].setValue('');
    }
    else {
      form.resetForm();
      this.displayAdd = false;
    }
  }

  Update(form: NgForm, addType: number) {
    
    this.selectItem.vB20OrderDetail = this.fieldArray;
    this.formData.append('vB20OrderDetail', JSON.stringify(this.fieldArray));
    this.ConvertFormDataToObject(this.selectItem, this.formData);  
    this._api.put(`${this.api}/update`, this.selectItem).takeUntil(this.unsubscribe).subscribe(res => {
      this.Filter(this.filter);
      this.formData = new FormData();
      alert(res.messages[0].message)
    });
    if (addType == 0) {
      form.resetForm();
    }
    else if (addType == 1) {
      if( form.control['code'])
        {form.control['code'].setValue('');}
    }
    else {
      form.resetForm();
      this.displayUpdate = false;
    }
  }
  ConvertGroupToGroup(event: any) {
    this.selectGroup = event;
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
  lookupOrderStatus:any;
  LookupOrderStatus(str: any) {

    this._api.getLookup2(`class/look-up-order-status`,str.query).takeUntil(this.unsubscribe).subscribe(res => {
      this.lookupOrderStatus = res;
    });
  }
  lookupPaymentMethod:any;
  paymentMethod(str: any) {
    this._api.getLookup2(`class/look-up-payment-method`,str.query).takeUntil(this.unsubscribe).subscribe(res => {
      this.lookupPaymentMethod = res;
    });
  }
  GetById(id: number) {   
    debugger;
      this._api.get(`${this.api}/${id}`,).takeUntil(this.unsubscribe).subscribe(res => {
  
        this.selectItem = res;
      
        this.selectItem.vB20OrderDetail=res.vB20OrderDetail_Json;
       
        this.fieldArray = this.selectItem.vB20OrderDetail;
       //check fieldarray is null
        if(this.fieldArray==null)
        {
          this.fieldArray= [];;
        }
      } );    
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
  setAmount()
  {
    this.newAttribute.amount=  this.newAttribute.quantity * this.newAttribute.unitPrice;
  }
  // setAmount2(i)
  // {
  //   this.fieldArray[i].amount=  this.fieldArray[i].quantity * this.fieldArray[i].unitPrice;
  // }
}

