import { Component, Injector, OnInit } from '@angular/core';
import { FormBuilder, NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BaseComponent } from 'src/app/core/base-component';
import { Permision } from 'src/app/shared/models/Permision';

@Component({
  selector: 'app-acc-doc',
  templateUrl: './acc-doc.component.html',
  styleUrls: ['./acc-doc.component.css']
})
export class AccDocComponent extends BaseComponent implements OnInit {

  public AccDocs  : any;
 
  _selectedPermision: any;
  _selectedFunction: any;
  public Functions: any;
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
debugger  ;
    this._api.get('/api/AccDoc/get-all').takeUntil(this.unsubscribe).subscribe(res => {
      this.AccDocs = res;
    });

  }

  displayAdd: boolean = false;
  showAdd() {
   
  }
  CreateAccDoc() {


    this.router.navigate(['manage-acc-doc-detail']);
  }

  showEdit(id: any) {
     this.router.navigate(['manage-acc-doc-detail', id]);
  }
  
  delete(id: any) {
    this._api.delete('/api/AccDoc/delete/' + id).takeUntil(this.unsubscribe).subscribe(res => {
      alert("Xóa thành công");
      this.search();

    }, err => { console.log(err); });
  }

}


