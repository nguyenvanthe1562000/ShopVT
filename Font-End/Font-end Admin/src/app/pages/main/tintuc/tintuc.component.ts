import { Component, Injector, OnInit } from '@angular/core';
import { BaseComponent } from '../../../core/base-component';
import 'rxjs/add/observable/combineLatest';
import 'rxjs/add/operator/takeUntil';
import { ActivatedRoute, Router } from '@angular/router';
import { LoaiSanPham } from '../../../shared/models/LoaiSanPham';
import { FormBuilder, NgForm } from '@angular/forms';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { TinTuc } from '../../../shared/models/tintuc';
import { catchError, map } from 'rxjs/operators';
import {formatDate} from '@angular/common';
import {  HttpHeaders } from '@angular/common/http';
interface ProductsGroup {
  maNhom: string,
  tenNhom: string
}
@Component({
  selector: 'app-tintuc',
  templateUrl: './tintuc.component.html',
  styleUrls: ['./tintuc.component.css']
})
export class TintucComponent extends BaseComponent implements OnInit {

  public tintuc: any;
  public page = 1;
  public pageSize = 3;
  public totalItems: any;
  public productsGroup: ProductsGroup[];
  selectedProductGroup: ProductsGroup;
  constructor(private fb: FormBuilder, private httpclient: HttpClient, injector: Injector, private route: ActivatedRoute, private router: Router) {
    super(injector);


  }

  ngOnInit(): void {
    this.search();

    
  }

  getData() { 
      this._api.get('/api/TinTuc/getall').takeUntil(this.unsubscribe).subscribe(res => {
        this.tintuc = res;
        this.totalItems = this.tintuc.length;
      }, err => { console.log(err); });
  }
  
   loadPage(page) {
    this._api.post('/api/TinTuc/get-paging', { page: page, pageSize: this.pageSize }).takeUntil(this.unsubscribe).subscribe(res => {
      this.tintuc = res.data;
      this.totalItems = res.totalItems;
      this.pageSize = res.pageSize;
    });
  }
  displayAdd: boolean = false;
  showAdd() {
    this.displayAdd = true;
  }
  search() {
    this.route.params.subscribe(params => {
      this._api.post('/api/TinTuc/get-paging', { page: this.page, pageSize: this.pageSize }).takeUntil(this.unsubscribe).subscribe(res => {
        this.tintuc = res.data;
        this.totalItems = res.totalItems;
        setTimeout(() => {
          this.loadScripts();
        });
      });
    });
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
  upload(file?: any): Observable<any>  {

    const apiURL = 'https://localhost:5001/api/SanPham/up-file';
    const formData = new FormData();
    formData.append("file", file, file.name);
    return this.httpclient.post(apiURL, formData) .pipe();
  }
  imgresult: any
 async AddNew(form: NgForm) {
    console.log(form.value);
    try {
      let img: string;
      this.upload(this.file).subscribe(res =>{
       const tintuc: TinTuc = new TinTuc();
      tintuc.ID = "";
      tintuc.TieuDe = form.controls['TieuDe'].value;
      tintuc.HinhAnh =res.data;
      tintuc.NoiDung = form.controls['NoiDung'].value;
      tintuc.NgayDang=formatDate(Date.now(),'yyyy-MM-dd','en-US');
      tintuc.TrangThai =true;
      console.log(JSON.stringify(tintuc))
       this._api.post('/api/TinTuc/insert', tintuc).takeUntil(this.unsubscribe).subscribe(res => {
       alert("thêm mới thành công");
       this.search();
       this.displayAdd = false;
     });
    });
     
     
    

      // product.photosmall=this.file2.name;
      // this._api.addnews(news).subscribe(res=>{
      // this.news?.push(res);
      // alert("Thêm Thành Công");
      //  this.router.navigate(['/news_management']);
      // });
    }

    catch (error) {
      console.log(error);
    }

  }
  delete(id: any) {
    this._api.delete('/api/TinTuc/delete/' + id).takeUntil(this.unsubscribe).subscribe(res => {
      alert("Xóa thành công");
      this.search();

    }, err => { console.log(err); });
  }
}
