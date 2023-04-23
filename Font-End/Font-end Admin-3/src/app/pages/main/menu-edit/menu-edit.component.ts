
 
import { Component, Injector, OnInit, HostListener } from '@angular/core';
import { BaseComponent } from '../../../core/base-component';
import 'rxjs/add/observable/combineLatest';
import { takeUntil } from 'rxjs/operators';
import { ActivatedRoute, Router } from '@angular/router';
import { AbstractControl, FormBuilder, NgForm } from '@angular/forms';
import { PrimeNGConfig } from 'primeng/api';
import { HttpClient } from '@angular/common/http';
import { FilterType, lookupRequest, PagingRequest } from '../../../shared/models/PagingRequest';;
import { MessageService } from 'primeng/api';
import { vB10Menu } from 'src/app/shared/models/vB10Menu';
 
@Component({
  selector: 'app-menu-edit',
  templateUrl: './menu-edit.component.html',
  styleUrls: ['./menu-edit.component.css']
})
export class MenuEditComponent extends BaseComponent implements OnInit {
  //exploredata  

  public api: string = '/api/menu';
  public formData = new FormData();
  public addType: number = 0; //thao tác lưu dữ liệu vd 0: lưu và thêm mới
  public _Parent:vB10Menu;
  public lookupResponse: any;
  public lookupRequest: lookupRequest;
  public _TypeMenu;
  public _ParentId;

  //editordata

  displayAdd: boolean = false;
  public IsUpdate: boolean = false;
  constructor(primengConfig: PrimeNGConfig,private fb: FormBuilder, private httpclient: HttpClient, injector: Injector, private route: ActivatedRoute, private router: Router,private messageService: MessageService) {
    super(injector);
    setTimeout(() => {
      this.loadScripts();
    });
  }

  ngOnInit(): void {
    debugger;
    this.lookupRequest = new lookupRequest();
    this.route.queryParams.subscribe(params => {
      this._TypeMenu = params['type'];
      this._ParentId = params['parentId'];
    });
    var id = this.route.snapshot.paramMap.get('id');
    if (id != null || id != undefined) {
      this.GetById(Number(id));
      this.IsUpdate = true
    }
    else {
      this.DefaultValue();
      this.displayAdd = false;
      this.IsUpdate = false;
    }
  }
  @HostListener('window:keydown.f3', ['$event'])
  Edit(event: KeyboardEvent) {
    event.preventDefault();
    this.displayAdd = false;
  }
  //start //explore
  changeForm(type)
  {
    if(this.IsUpdate)
    {
      this._Parent = new vB10Menu();
      this._Parent.parentId = this._ParentId;
      this._Parent.type = this._TypeMenu;
      this.IsUpdate=false;
    }
    this._Parent.isGroup = type == 1?true:false;
  }
  DefaultValue() {
    this._Parent = new vB10Menu();
    this._Parent.code = "";
    this._Parent.parentId = this._ParentId;
    this._Parent.type = this._TypeMenu;

  }
  //grid 
  
  //data editor
  Add(form: NgForm, addDataIsGroup: boolean, addType: number) {

     if(!this.IsUpdate)
     {
      debugger
      this._api.post(`${this.api}/add`, this._Parent).takeUntil(this.unsubscribe).subscribe(res => {
        alert(res.messages[0].message)
        this.messageService.add({ severity: 'success', summary: 'Success', detail: 'Message Content' });
        this.formData = new FormData();
      });
      if (addType == 0) {
        form.resetForm();
      }
      else if (addType == 1) {
        form.control['_Parent.code'].setValue('');
      }
      else {
        form.resetForm();
        this.router.navigate(['/menu']);
      }
     }
     else
     {

      this._api.put(`${this.api}/update`, this._Parent).takeUntil(this.unsubscribe).subscribe(res => {
        this.formData = new FormData();
        this.messageService.add({ severity: 'success', summary: 'Success', detail: 'Message Content' });
        alert(res.messages[0].message)
      });
      if (addType == 0) {
        form.resetForm();
      }
      else if (addType == 1) {
        if( form.control['_Parent.code'])
          {form.control['_Parent.code'].setValue('');}
      }
      else {
        form.resetForm();
        this.router.navigate(['menu']);
      }
     }
  
  }
  
  RandomString(){
    this._api.serverContraint("usp_generate_unique_random_string",[8]).pipe(takeUntil(this.unsubscribe)).subscribe(res => {
      this._Parent.code = res[0].Column1;
    });
  }


  Lookup(event: any, LookUpKey: string, LoadFilterExpr?: string, OrderBy?: string, NumberRow?: string) {
    this.lookupRequest.LookupKey = LookUpKey;
    this.lookupRequest.LookupValue = event.query == undefined ? "" : event.query;
    this.lookupRequest.LoadFilterExpr = LoadFilterExpr == undefined ? "" : LoadFilterExpr;
    this.lookupRequest.NumberRow = NumberRow == undefined ? "" : NumberRow;
    this.lookupRequest.OrderBy = OrderBy == undefined ? "" : OrderBy;
    this._api.Lookup3(`/api/look-up`, this.lookupRequest).takeUntil(this.unsubscribe).subscribe(res => {
      this.lookupResponse = res;

    });
  }
  GetById(id: number) {   
      this._api.get(`${this.api}/${id}`,).takeUntil(this.unsubscribe).subscribe(res => {
        this._Parent =res;
      });    
  }
 
  showConfirm() {
    this.messageService.add({ key: 'c', sticky: true, severity: 'warn', summary: 'Lưu ý', detail: 'Bạn có chắc hủy dữ liệu đã thay đổi' });
  }
  onConfirm() {
    this.messageService.clear('c');
    this.router.navigate(['/menu']);
    
  }
  onReject() {
    this.messageService.clear('c');
  }
  Lookup3(event: any, LookUpKey: string, LoadFilterExpr?: string, OrderBy?: string, NumberRow?: string) {
    debugger;
    this.lookupRequest = new lookupRequest();
    this.lookupRequest.LookupKey = LookUpKey;
    this.lookupRequest.LookupValue = event.query == undefined ? "" : event.query;
    this.lookupRequest.LoadFilterExpr = LoadFilterExpr == undefined ? "" : LoadFilterExpr;
    this.lookupRequest.NumberRow = NumberRow == undefined ? "" : NumberRow;
    this.lookupRequest.OrderBy = OrderBy == undefined ? "" : OrderBy;
    this._api.Lookup3(`/api/look-up`, this.lookupRequest).takeUntil(this.unsubscribe).subscribe(res => {
      this.lookupResponse = res;

    });
  }
  setMenuType(event) {
  this._Parent.type = event.Code;
  this._Parent.menuType = event.Name;
  
  }
  convertNameToSlug(){
    this._Parent.alias= this.convertToSlug(this._Parent.name);
  } 
  setMenuParent(event) {
    this._Parent.parentId = event.Id;
    this._Parent.menuParentName = event.Name;
    
    }
}
