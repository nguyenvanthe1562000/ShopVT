 

import { Component, Injector, OnInit, HostListener } from '@angular/core';
import { BaseComponent } from '../../../core/base-component';
import 'rxjs/add/observable/combineLatest';
import 'rxjs/add/operator/takeUntil';
import { ActivatedRoute, Router } from '@angular/router';
import { AbstractControl, FormBuilder, NgForm } from '@angular/forms';
import { PrimeNGConfig } from 'primeng/api';
import { HttpClient } from '@angular/common/http';
import { FilterType, lookupRequest, PagingRequest } from '../../../shared/models/PagingRequest';
import { MessageService } from 'primeng/api';
import { vB10HomePage } from 'src/app/shared/models/vB10HomePage';
import { vB10HomePageDetail } from 'src/app/shared/models/vB10HomePageDetail';
 
@Component({
  selector: 'app-home-page-edit',
  templateUrl: './home-page-edit.component.html',
  styleUrls: ['./home-page-edit.component.css']
})
export class HomePageEditComponent extends BaseComponent implements OnInit {
  //exploredata  


  public api: string = '/api/home-page';
  public formData = new FormData();
  public addType: number = 0; //thao tác lưu dữ liệu vd 0: lưu và thêm mới
  public _Parent:vB10HomePage;
  public _Child1:vB10HomePageDetail;
  public _FieldArray: Array<any> = [];
  public lookupResponse: any;
  public lookupRequest: lookupRequest;
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
    this._FieldArray = [];
    this.lookupRequest = new lookupRequest();
    this._Parent = new vB10HomePage();
    
    var id = this.route.snapshot.paramMap.get('id');
    this.DefaultValue();
    if (id != null || id != undefined) {
      this.GetById(Number(id));
      this.IsUpdate = true
    }
    else {
      
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

  DefaultValue() {
    this._Child1 = new vB10HomePageDetail();
  }
  //grid 
  addFieldValue() {
    const obj = new vB10HomePageDetail();

    const propertyNames = Reflect.ownKeys(obj);
    console.log(propertyNames);
      this._FieldArray.push(this._Child1);
      this._Child1 = new vB10HomePageDetail();
  }
  deleteFieldValue(index,child?:string) {
    this._FieldArray.splice(index, 1);
  }
  
  //end grid
  SelectFile(event: any, name: string, isMultiple: boolean) {
      this.formData.append(name, event.target.files[0]);
      var reader = new FileReader();
      reader.onload = (event2:any) =>{
        this._Parent.bannerImage=event2.target.result;
      }
      reader.readAsDataURL(event.target.files[0])
  }
  //data editor
  Add(form: NgForm, addDataIsGroup: boolean, addType: number) {

     if(!this.IsUpdate)
     {
      this.formData.append('homePageDetail_Json', JSON.stringify(this._FieldArray));
      this.ConvertObjectToFormData(this._Parent,this.formData);
      
      this._api.postFormData(`${this.api}/add`, this.formData).takeUntil(this.unsubscribe).subscribe(res => {
        alert(res.messages[0].message)
        this.messageService.add({ severity: 'success', summary: 'Success', detail: 'Message Content' });
        this.formData = new FormData();
      });
      if (addType == 0) {
        form.resetForm();
        this._FieldArray=[];
      }
      else if (addType == 1) {
        form.control['code'].setValue('');
      }
      else {
        form.resetForm();
        this.displayAdd = false;
        this._FieldArray=[];
      }
     }
     else
     {
      this.DefaultValue()
      this.formData.append('HomePageDetail_Json', JSON.stringify(this._FieldArray));
      this.ConvertObjectToFormData(this._Parent, this.formData);  
      this._api.putFormData(`${this.api}/update`, this.formData).takeUntil(this.unsubscribe).subscribe(res => {
        this.formData = new FormData();
        this.messageService.add({ severity: 'success', summary: 'Success', detail: 'Message Content' });
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
        this._FieldArray=[];
      }
     }
  
  }

  SelectProduct(event: any, i?) {
    if (this.checkEditGrid(i)) {
 
      this._FieldArray[i].productCode = event.Code;
      this._FieldArray[i].productName = event.Name?event.Name:'';
      this._FieldArray[i].unit = event.Unit? event.Unit:'';
      this._FieldArray[i].standardPriceRetail = event.StandardPriceRetail?event.StandardPriceRetail : 0;
      this._FieldArray[i].unitPrice = event.UnitPrice?event.UnitPrice:0 ;
      this._FieldArray[i].discountRate = event.DiscountRate? event.discountRate:0;
    }
    else {
      this._Child1.productCode = event.Code;
      this._Child1.productName = event.Name?event.Name:'';
      this._Child1.unit = event.Unit? event.Unit:'';
      this._Child1.standardPriceRetail = event.StandardPriceRetail?event.StandardPriceRetail : 0;
      this._Child1.unitPrice = event.UnitPrice?event.UnitPrice:0 ;
      this._Child1.discountRate = event.DiscountRate? event.discountRate:0;
   

    }

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
     
        this._Parent.vB10HomePageDetail_Json=res.vB10HomePageDetail_Json;
        this._FieldArray = this._Parent.vB10HomePageDetail_Json;
       //check _FieldArray is null
       if(this._FieldArray==null)
       {
         this._FieldArray= [];;
       }
       if(this._Parent.vB10HomePageDetail_Json == null)
       {
        this._Parent.vB10HomePageDetail_Json = []
       }
      });    
  }
   
  
  showConfirm() {
    this.messageService.add({ key: 'c', sticky: true, severity: 'warn', summary: 'Lưu ý', detail: 'Bạn có chắc hủy dữ liệu đã thay đổi' });
  }
  onConfirm() {
    this.messageService.clear('c');
    this.router.navigate(['/product']);
    
  }
  onReject() {
    this.messageService.clear('c');
  }
  checkEditGrid(i) {
    if (i != undefined && i >= 0)
      return true
    return false
  }
}
