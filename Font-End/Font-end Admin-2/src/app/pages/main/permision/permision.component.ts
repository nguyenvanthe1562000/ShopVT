import { Component, Injector, OnInit } from '@angular/core';
import { FormBuilder, NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BaseComponent } from 'src/app/core/base-component';
import { Permision } from 'src/app/shared/models/Permision';

@Component({
  selector: 'app-permision',
  templateUrl: './permision.component.html',
  styleUrls: ['./permision.component.css']
})

export class PermisionComponent extends BaseComponent implements OnInit {

  public Pemisions: any;
  public permision: Permision;
  public page = 1;
  public pageSize = 10;
  public totalItems: any;
  public formsearch: any;
  public doneSetupForm: any;
  public showUpdateModal: any;
  public formdata: any;
  submitted = false;
  public isCreate: boolean;
  constructor(private fb: FormBuilder, injector: Injector, private route: ActivatedRoute, private router: Router) {
    super(injector);
  }
  ngOnInit(): void {
   
    this.search();
    setTimeout(() => {
             this.loadScripts();
           });
      //  this._api.get('/api/NhomSanPham/get-all').takeUntil(this.unsubscribe).subscribe(res => {
      //    this.productsGroup = res;
      //  }); 
  }
  productsGroup: any;
  search() {
   
    // this._api.get('​/api​/Permision​/get-all').takeUntil(this.unsubscribe).subscribe(res => {
    //   this.Pemisions = res.data;
    // });
      this._api.get('/api/Permision/get-all').takeUntil(this.unsubscribe).subscribe(res => {
        this.Pemisions = res;
       }); 
  } 

  displayAdd: boolean = false;
  showAdd() {
    this.displayAdd = true;
  }

 
 
   AddNew(form: NgForm) {

    try {
      let img: string;
      
       
        console.log(JSON.stringify(form.value))
        this._api.post('/api/Permision/insert', form.value).takeUntil(this.unsubscribe).subscribe(res => {
          alert("thêm mới thành công");
          this.search();
          this.displayAdd = false;
        });
        
    }
    catch (error) {
      console.log(error);
    }
  }

  // loadPage(page) {
  //   this._route.params.subscribe(params => {
  //     this._api.post('/api/LoaiSanPham/category-all-paginate', { page: page, pageSize: this.pageSize }).takeUntil(this.unsubscribe).subscribe(res => {
  //       this.categories = res.data;
  //       this.totalItems = res.totalItems;
  //     }, err => { });
  //   });
  // }
  delete(id: any) {
    this._api.delete('/api/Permision/delete/' + id).takeUntil(this.unsubscribe).subscribe(res => {
      alert("Xóa thành công");
      this.search();

    }, err => { console.log(err); });
  }


}
