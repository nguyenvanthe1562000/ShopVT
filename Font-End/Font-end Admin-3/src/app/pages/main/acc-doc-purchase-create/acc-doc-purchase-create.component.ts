
import { Component, Injector, OnInit, HostListener } from '@angular/core';
import { BaseComponent } from '../../../core/base-component';
// import 'rxjs/add/operator/takeUntil';
import { ActivatedRoute, Router } from '@angular/router';
import { AbstractControl, FormBuilder, NgForm } from '@angular/forms';
import { takeUntil } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { FilterType, lookupRequest, PagingRequest } from '../../../shared/models/PagingRequest';
import { DatePipe } from '@angular/common';
import { MessageService } from 'primeng/api';
import { PrimeNGConfig } from 'primeng/api';
 
import { vB20AccDoc_Purchase } from 'src/app/shared/models/B20AccDoc_Purchase';
import { vB20AccDocPurchase } from 'src/app/shared/models/B20AccDocPurchase';

@Component({
  selector: 'app-acc-doc-purchase-create',
  templateUrl: './acc-doc-purchase-create.component.html',
  styleUrls: ['./acc-doc-purchase-create.component.css']
})
export class AccDocPurchaseCreateComponent extends BaseComponent implements OnInit {
  //exploredata

  public test: any = 'test';
  public api: string = '/api/accdoc-purchase';
  public _Parent: vB20AccDoc_Purchase;
  //grid
  public _FieldArray: Array<any> = [];
  public _Child: vB20AccDocPurchase;
  public formData = new FormData();
  public addType: number = 0; //thao tác lưu dữ liệu vd 0: lưu và thêm mới
  public lookupResponse: any;
  public lookupRequest: lookupRequest;
  //editordata 
  displayAdd: boolean = true;
  public IsUpdate: boolean = false;
  constructor(private fb: FormBuilder, private httpclient: HttpClient, injector: Injector, private route: ActivatedRoute, private router: Router, private datePipe: DatePipe, private messageService: MessageService, private primengConfig: PrimeNGConfig) {
    super(injector);
    this._Parent = new vB20AccDoc_Purchase();
    this._Child = new vB20AccDocPurchase();
    this.lookupRequest = new lookupRequest();
    this._FieldArray = [];

    var id = this.route.snapshot.paramMap.get('id');
    if (id != null || id != undefined) {
      this.GetById(Number(id));
      this.IsUpdate = true
    }
    else {
      this.DefaultValue()
      this.displayAdd = false;
      this.IsUpdate = false;
    }
  }
  ngOnInit(): void {
    this.primengConfig.ripple = true;
  }
  @HostListener('window:keydown.f3', ['$event'])
  Edit(event: KeyboardEvent) {
    event.preventDefault();
    this.displayAdd = false;
  }
  GetById(id: number) {

    this._api.get(`${this.api}/${id}`,).takeUntil(this.unsubscribe).subscribe(res => {

      this._Parent = res;

      this._Parent.vB20AccDocPurchase_Json = res.vB20AccDocPurchase_Json;

      this._FieldArray = this._Parent.vB20AccDocPurchase_Json;
      //check fieldarray is null
      if (this._FieldArray == null && this._FieldArray == undefined) {
        this._FieldArray = [];
      }
    });
  }
  DefaultValue() {

    this._Parent.docNo = 'NM-';
    this._Parent.docCode = 'NM';
    this._Parent.docGroup = '1';
    this._Parent.currencyCode = this._currency;
    this._Parent.exchangeRate = 1;
    var date = new Date();
    this._Parent.docDate = Date.now().toString();
  }

  SelectForeignKey(event: any, foreignKey: string) {
    debugger;
    this.formData.append(foreignKey, event.code);
  }
  SelectProduct(event: any, i) {
    if (this.checkEditGrid(i)) {
      this._FieldArray[i].productCode = event.Code;
      this._FieldArray[i].description = event.Name;
      this._FieldArray[i].unit = event.unit;
      this._FieldArray[i].convertRate9 = 1;
      this._FieldArray[i].imagePath = event.image;
      this._FieldArray[i].weight = event.weight;
      this.setQuantity(i);
    }
    else {
      this._Child.productCode = event.Code;
      this._Child.description = event.Name;
      this._Child.unit = event.unit;
      this._Child.convertRate9 = 1;
      this._Child.imagePath = event.image;
      this._Child.weight = event.weight;
    }

  }
  DiscountRateChange(event: any, i?) {

    if (this.checkEditGrid(i)) {
      this._FieldArray[i].discountRate = event.value == undefined ? 0 : event.value;
      this.setAmount(i);
    }
    else {
      this._Child.discountRate = event.value == undefined ? 0 : event.value;

      this.setAmount();
    }

  }
  SelectUnit(event: any, i?) {
    debugger;
    if (this.checkEditGrid(i)) {
      this._FieldArray[i].unit = event.Unit;
      this._FieldArray[i].convertRate9 = event.ConvertRate;
      this._FieldArray[i].quantity = Number(this._FieldArray[i].quantity9) * Number(this._FieldArray[i].convertRate9 == undefined ? 1 : this._FieldArray[i].convertRate9);
    }
    else {
      this._Child.unit = event.Unit;
      this._Child.convertRate9 = event.ConvertRate;
      this._Child.quantity = Number(this._Child.quantity9) * Number(this._Child.convertRate9 == undefined ? 1 : this._Child.convertRate9);

    }
  }
  SelectCurrency(event: any) {
    this._Parent.exchangeRate = event.SellingExchangeRate;
    this._Parent.currencyCode = event.Code;
    this.setExchangeRate();
  }
  
  SelectCustomer(event: any) {
    this._Parent.customerCode = event.Code;
    this._Parent.phone = event.Phone;
    this._Parent.email = event.Email;
    this._Parent.address = event.Address;
    this._Parent.customerName = event.Name;
  }
  SelectDocStatus(event: any) {
    this._Parent.docStatus = event.Code;
    this._Parent.docStatusName = event.Name;
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


  lookupOrderStatus: any;
  LookupOrderStatus(str: any) {
    debugger
    this._api.getLookup2(`class/look-up-order-status`, str.query).takeUntil(this.unsubscribe).subscribe(res => {
      this.lookupOrderStatus = res;
    });
  }
 

  Lookup3(event: any, LookUpKey: string, LoadFilterExpr?: string, OrderBy?: string, NumberRow?: string) {
    this.lookupRequest.LookupKey = LookUpKey;
    this.lookupRequest.LookupValue = event.query == undefined ? "" : event.query;
    this.lookupRequest.LoadFilterExpr = LoadFilterExpr == undefined ? "" : LoadFilterExpr;
    this.lookupRequest.NumberRow = NumberRow == undefined ? "" : NumberRow;
    this.lookupRequest.OrderBy = OrderBy == undefined ? "" : OrderBy;
    this._api.Lookup3(`/api/look-up`, this.lookupRequest).takeUntil(this.unsubscribe).subscribe(res => {
      this.lookupResponse = res;

    });
  }
  setExchangeRate(){
    if (this._FieldArray != undefined) {
      var x: number = 0;
      for (const item of this._FieldArray) {
        this._FieldArray[x].unitCost = this.MathRound(this._Parent.currencyCode, this._FieldArray[x].originalUnitCost * this._Parent.exchangeRate);
        this._FieldArray[x].amount = this.MathRound(this._Parent.currencyCode, this._FieldArray[x].originalAmount * this._Parent.exchangeRate);
        x = x + 1;
      }
    }
    this.sumAmount3();
    this.sumAmount();
  }
  setQuantity(i?) {

    if (this.checkEditGrid(i)) {
      this._FieldArray[i].quantity = this._FieldArray[i].convertRate9 * this._FieldArray[i].quantity9;
    }
    else {
      this._Child.quantity = this._Child.convertRate9 * this._Child.quantity9;
    }
  }
  setAmount(i?) {

    if (this.checkEditGrid(i)) {
      this._FieldArray[i].unitCost = this.MathRound(this._currency, this._FieldArray[i].originalUnitCost * Number(this._Parent.exchangeRate));

      this._FieldArray[i].originalAmount = (this._FieldArray[i].quantity9 * this._FieldArray[i].originalUnitCost);

      this._FieldArray[i].amount = this.MathRound(this._currency, this._FieldArray[i].quantity9 * this._FieldArray[i].unitCost)

      if (this._FieldArray[i].discountRate > 0 && this._FieldArray[i].discountRate != undefined) {
        this._FieldArray[i].originalDiscountAmount = this.MathRound(this._Parent.currencyCode, this._FieldArray[i].originalAmount * (this._FieldArray[i].discountRate / 100))
        this._FieldArray[i].discountAmount = this.MathRound(this._currency, (this._FieldArray[i].amount * (this._FieldArray[i].discountRate / 100)));
        if (this._FieldArray[i].originalDiscountAmount > 0 && this._FieldArray[i].originalAmount > 0) {
          this._FieldArray[i].originalAmount = this._FieldArray[i].originalAmount - this._FieldArray[i].originalDiscountAmount;
          this._FieldArray[i].amount = this.MathRound(this._currency, this._FieldArray[i].amount - this._FieldArray[i].discountAmount);
        }
      }
    }
    else {
      this._Child.unitCost = this.MathRound(this._Parent.currencyCode, this._Child.originalUnitCost * Number(this._Parent.exchangeRate));

      this._Child.originalAmount = this.MathRound(this._Parent.currencyCode, this._Child.quantity9 * this._Child.originalUnitCost);

      this._Child.amount = this.MathRound(this._currency, this._Child.quantity9 * this._Child.unitCost)

      if (this._Child.discountRate > 0 && this._Child.discountRate != undefined) {
        this._Child.originalDiscountAmount = (this._Child.originalAmount * (this._Child.discountRate / 100))
        this._Child.discountAmount = this.MathRound(this._currency, (this._Child.amount * (this._Child.discountRate / 100)));
        if (this._Child.originalDiscountAmount > 0 && this._Child.originalAmount > 0) {
          this._Child.originalAmount = this._Child.originalAmount - this._Child.originalDiscountAmount;
          this._Child.amount = this.MathRound(this._currency, this._Child.amount - this._Child.discountAmount);
        }
      }
    }
    this.sumAmount();
    this.sumAmount3();
  }

  setVAT($event) {
    this._Parent.taxCode = $event.Code;
    this._Parent.taxRate = $event.Rate;
    debugger;
    this._Child.originalAmount3 = this._Child.originalAmount * this._Parent.taxRate;
    this._Child.amount3 = this.MathRound(this._currency, this._Child.originalAmount * this._Parent.taxRate);
    this.sumAmount3();
    this.sumAmount();
  }
  sumAmount3() {
    var i: number = 0;
    for (const item of this._FieldArray) {
      this._FieldArray[i].taxCode = this._Parent.taxCode;
      this._FieldArray[i].taxRate = this._Parent.taxRate;
      this._FieldArray[i].originalAmount3 = this.MathRound(this._Parent.currencyCode, this._FieldArray[i].originalAmount * (this._FieldArray[i].taxRate / 100));
      this._FieldArray[i].amount3 = this.MathRound(this._currency, this._FieldArray[i].amount * (this._FieldArray[i].taxRate / 100));
      i = i + 1;
    }

  }
  sumAmount() {
    if (this._FieldArray != undefined) {
      this._Parent.totalOriginalAmount0 = this.MathRound(this._Parent.currencyCode, this._FieldArray.reduce((total, item) => total + item.originalAmount, 0));
      this._Parent.totalAmount0 = this.MathRound(this._currency, this._FieldArray.reduce((total, item) => total + item.amount, 0));
      this._Parent.totalOriginalAmount3 = this.MathRound(this._Parent.currencyCode, this._FieldArray.reduce((total, item) => total + item.originalAmount3, 0));
      this._Parent.totalAmount3 = this.MathRound(this._currency, this._FieldArray.reduce((total, item) => total + item.amount3, 0));
      this._Parent.totalOriginalAmount = this.MathRound(this._Parent.currencyCode, this._Parent.totalOriginalAmount0);
      this._Parent.totalAmount = this.MathRound(this._currency, this._Parent.totalAmount0);
      if (this._Parent.totalOriginalAmount3 != undefined && this._Parent.totalOriginalAmount3 >= 0) {
        this._Parent.totalOriginalAmount = this.MathRound(this._Parent.currencyCode, this._Parent.totalOriginalAmount0 + this._Parent.totalOriginalAmount3);
        this._Parent.totalAmount = this.MathRound(this._currency, this._Parent.totalAmount0 + this._Parent.totalAmount3);
      }


    }
  }
  checkEditGrid(i) {
    if (i != undefined && i >= 0)
      return true
    return false
  }
  //  add-delete grid
  addFieldValue() {
    this._FieldArray.push(this._Child)
    this._Child = new vB20AccDocPurchase();
    this.sumAmount3();
    this.sumAmount();
  }
  deleteFieldValue(index) {
    this._FieldArray.splice(index, 1);
    this.sumAmount3();
    this.sumAmount();

  }
  //update
  //data editor
  Add(form: NgForm, addDataIsGroup: boolean, addType: number) {

    const datePipe = new DatePipe('en-US'); // Replace 'en-US' with your preferred locale
    const formattedDate = datePipe.transform(this._Parent.docDate, 'yyyy-MM-dd');
    this._Parent.docDate = formattedDate.toString();
    this._Parent.vB20AccDocPurchase_Json = this._FieldArray;

    if (this.IsUpdate) {
      this._api.put(`${this.api}/update`, this._Parent).pipe(takeUntil(this.unsubscribe)).subscribe(res => {
        this.messageService.add({ severity: 'success', summary: 'Success', detail: 'Message Content' });
      });
      if (addType == 0) {
        form.resetForm();
      }
      else if (addType == 1) {
        form.control['code'].setValue('');
      }
      else {
        this.router.navigate(['/acc-doc-purchase']);
      }
    }
    else {
      this._api.post(`${this.api}/add`, this._Parent).pipe(takeUntil(this.unsubscribe)).subscribe(res => {
        alert(res.messages[0].message)
      });
      if (addType == 0) {
        form.resetForm();

      }
      else if (addType == 1) {
        form.control['code'].setValue('');
      }
      else {
        this.router.navigate(['/acc-doc-purchase']);
      }
    }

  }
  showConfirm() {
    this.messageService.add({ key: 'c', sticky: true, severity: 'warn', summary: 'Lưu ý', detail: 'Bạn có chắc hủy dữ liệu đã thay đổi' });
  }
  onConfirm() {
    this.messageService.clear('c');
    this.router.navigate(['/acc-doc-purchase']);
    
  }
  onReject() {
    this.messageService.clear('c');
  }
}


