

import { Component, Injector, OnInit } from '@angular/core';
import { BaseComponent } from '../../../core/base-component';
import 'rxjs/add/observable/combineLatest';
import 'rxjs/add/operator/takeUntil';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, NgForm } from '@angular/forms';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { FilterType, PagingRequest } from '../../../shared/models/PagingRequest';
import { PagedResult } from '../../../shared/models/PageResult';
import { catchError, map } from 'rxjs/operators';
import { formatDate } from '@angular/common';
import { HttpHeaders } from '@angular/common/http';
import { B10PostCategory } from '../../../shared/models/B10PostCategory';

interface FilterTypeColumn { value: string, viewValue: string }
interface FilterTypeValue { value: FilterType, viewValue: string }


@Component({
  selector: 'app-post-category',
  templateUrl: './post-category.component.html',
  styleUrls: ['./post-category.component.css']
})

export class PostCategoryComponent extends BaseComponent implements OnInit {
  public tintuc: any;
  public page = 1;
  public pageSize = 10;
  public totalItems: any;
  public filter: PagingRequest;
  public listItem: PagedResult<B10PostCategory>;
  public checkFilter: boolean;
  public ClickColumn: string = '';
  public api: string = '/api/post-category';
  public filterTypeColumn: any;
  public filterTypeValue: any;



  constructor(private fb: FormBuilder, private httpclient: HttpClient, injector: Injector, private route: ActivatedRoute, private router: Router) {
    super(injector);
    this.filter = new PagingRequest();
    this.listItem = new PagedResult<B10PostCategory>();


  }

  ngOnInit(): void {
    this.filter.PageIndex = this.page;
    this.filter.PageSize = this.pageSize;
    this.Filter(this.filter);
  }
  //start //explore

  InitValueFormFilter(value: string = null) {
    if (value) {
      this.filter.FilterValue = value;
    }
    this.filterTypeColumn = [{ value: `${this.filter.FilterColumn}`, viewValue: `Cột hiện thời "${this.filter.FilterColumn}"` }, { value: '*', viewValue: 'Tất cả các cột' }];
    this.filterTypeValue = [
      { value: FilterType.Contains, viewValue: `Chứa nội dung "${this.filter.FilterValue}"` }
      , { value: FilterType.StartsWith, viewValue: `Nội dung bắt đầu với "${this.filter.FilterValue}"` }
      , { value: FilterType.EndsWith, viewValue: `Nội dung kết thúc với "${this.filter.FilterValue}"` }
      , { value: FilterType.Equals, viewValue: `Nội dung tương tự "${this.filter.FilterValue}"` }
      , { value: FilterType.NotEmpty, viewValue: `Nội dung khác rỗng "${this.filter.FilterValue}"` }
      , { value: FilterType.Empty, viewValue: `Nội dung rỗng "${this.filter.FilterValue}"` }
    ];

  }

  Filter(PagingRequest: PagingRequest) {
    let orderBy = PagingRequest.OrderBy;
    this.route.params.subscribe(params => {
      this._api.post(`${this.api}/filter`, { pageIndex: PagingRequest.PageIndex, pageSize: PagingRequest.PageSize, orderBy: PagingRequest.OrderBy, orderDesc: PagingRequest.OrderDesc, filterColumn: PagingRequest.FilterColumn, filterType: PagingRequest.FilterType, filterValue: PagingRequest.FilterValue }).takeUntil(this.unsubscribe).subscribe(res => {
        this.listItem.PageIndex = res.pageIndex;
        this.listItem.PageSize = res.pageSize;
        this.listItem.PageCount = res.pageCount;
        this.listItem.TotalRecords = res.totalRecords;
        this.listItem.Items = res.items;
        setTimeout(() => {
          this.loadScripts();
        });
        console.log(res);
        console.log(this.listItem);
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

    if (!this.ClickColumn) {
      this.ClickColumn = column;
    }
    if (this.filter.FilterColumn != column) {
      if (this.filter.FilterColumn == '*')
      {
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
  search(form: NgForm) {
    this.Filter(this.filter);
  }
  //end  //explore

  displayAdd: boolean = false;
  showAdd() {
    this.displayAdd = true;
  }



  file: any;
  image?: string;
  onChange(event: any) {
    this.file = event.target.files[0];
    var reader = new FileReader();

    reader.readAsDataURL(event.target.files[0]);
    reader.onload = (e: any) => {
      this.image = e.target.result;
    }

  }
  upload(file?: any): Observable<any> {

    const apiURL = 'https://localhost:5001/api/SanPham/up-file';
    const formData = new FormData();
    formData.append("file", file, file.name);
    return this.httpclient.post(apiURL, formData).pipe();
  }
  imgresult: any
  async AddNew(form: NgForm) {
    // console.log(form.value);
    // try {
    //   let img: string;
    //   this.upload(this.file).subscribe(res =>{
    //    const tintuc: TinTuc = new TinTuc();
    //   tintuc.ID = "";
    //   tintuc.TieuDe = form.controls['TieuDe'].value;
    //   tintuc.HinhAnh =res.data;
    //   tintuc.NoiDung = form.controls['NoiDung'].value;
    //   tintuc.NgayDang=formatDate(Date.now(),'yyyy-MM-dd','en-US');
    //   tintuc.TrangThai =true;
    //   console.log(JSON.stringify(tintuc))
    //    this._api.post('/api/TinTuc/insert', tintuc).takeUntil(this.unsubscribe).subscribe(res => {
    //    alert("thêm mới thành công");
    //    this.search();
    //    this.displayAdd = false;
    //  });
    // });




    //   // product.photosmall=this.file2.name;
    //   // this._api.addnews(news).subscribe(res=>{
    //   // this.news?.push(res);
    //   // alert("Thêm Thành Công");
    //   //  this.router.navigate(['/news_management']);
    //   // });
    // }

    // catch (error) {
    //   console.log(error);
    // }

  }
  delete(id: any) {
    this._api.delete('/api/TinTuc/delete/' + id).takeUntil(this.unsubscribe).subscribe(res => {
      alert("Xóa thành công");


    }, err => { console.log(err); });
  }
}
