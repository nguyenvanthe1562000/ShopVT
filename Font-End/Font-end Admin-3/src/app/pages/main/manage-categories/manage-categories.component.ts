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
interface Category {
  MaNhom: string,
  TenLoai: string
    MoTa: string,
      Anh: string
}
@Component({
  selector: 'app-manage-categories',
  templateUrl: './manage-categories.component.html',
  styleUrls: ['./manage-categories.component.css']
})
export class ManageCategoriesComponent extends BaseComponent implements OnInit {
  public categories: any;
  public page = 1;
  public pageSize = 3;
  public totalItems:any;
  public productsGroup: ProductsGroup[];
  selectedProductGroup: ProductsGroup;
  constructor(injector: Injector,private route: ActivatedRoute, private httpclient: HttpClient, private router: Router) {
    super(injector);
   }

  ngOnInit(): void {
   this.search();
 setTimeout(() => {
          this.loadScripts();
        });
    this._api.get('/api/NhomSanPham/get-all').takeUntil(this.unsubscribe).subscribe(res => {
      this.productsGroup = res;
    }); 
  }
  search()
  {
   this.route.params.subscribe(params => {
      this._api.post('/api/LoaiSanPham/category-all-paginate',{page: this.page, pageSize: this.pageSize}).takeUntil(this.unsubscribe).subscribe(res => {
        this.categories = res.data;
        this.totalItems = res.totalItems;
       
      });
    });
  }
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
mgresult:any
 async AddNew(form: NgForm) {
  
    try {
      let img:string;
      this.upload(this.file).subscribe(res => { 
 const category: LoaiSanPham = new LoaiSanPham();
        category.MaLoai ="";
         category.TenLoai= form.controls['tenLoai'].value;
          //  category.MaNhom=   form.controls['MaNhom'].value;
           category.MaNhom=   form.controls['MaNhom'].value;
          category.MoTa = form.controls['moTa'].value;
          category.Anh = res.data;
         console.log(JSON.stringify(category))
  this._api.post('/api/LoaiSanPham/create-category', category).takeUntil(this.unsubscribe).subscribe(res => {
       alert("thêm mới thành công");
       this.search();
       this.displayAdd = false;
     });
     
      });

    
    }
    catch (error) {
      console.log(error);
    }
  }

  loadPage(page) { 
    this._route.params.subscribe(params => {
      this._api.post('/api/LoaiSanPham/category-all-paginate', { page: page, pageSize: this.pageSize}).takeUntil(this.unsubscribe).subscribe(res => {
        this.categories = res.data;
        this.totalItems = res.totalItems;
        }, err => { });       
   });   
  }
   delete(id: any) {
    this._api.delete('/api/LoaiSanPham/delete-category/' + id).takeUntil(this.unsubscribe).subscribe(res => {
      alert("Xóa thành công");
      this.search();

    }, err => { console.log(err); });
  }
}
