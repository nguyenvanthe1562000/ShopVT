import { Component, Injector, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { vB20Order } from 'src/app/shared/model/vB20Order';
import { vB20OrderDetail } from 'src/app/shared/model/vB20OrderDetail';
import { BaseComponent } from '../../../core/base-component';
import jwt_decode from 'jwt-decode';
import { NguoiDung } from 'src/app/shared/model/NguoiDung';
@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent extends BaseComponent implements OnInit {
  public frmCheckout: FormGroup;
  namePattern= "^([a-zA-ZÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂưăạảấầẩẫậắằẳẵặẹẻẽềềểỄỆỈỊỌÓỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳýỵỷỹ\s]+)$";
  mobilePattern="^[0-9 _-]{10,12}$";
  items:any;
  total:any;
  ngayDat:any;
  public api: string = '/api/client/order' ;
  order:vB20Order;
  totalqty:number = 0;  frmLogin: FormGroup;
  loading = false;
  submitted = false;
  returnUrl: string;
  constructor(injector: Injector) { 
    super(injector);
  }
  
  ngOnInit(): void {
    window.scrollTo(0,0);
    var today = new Date();
    this.ngayDat = today.toLocaleDateString();
    this.GetData();
    this.frmCheckout = new FormGroup({
      txtHo: new FormControl('', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]),
      txtNote: new FormControl('', [Validators.required, Validators.minLength(2)]),
      txtDiaChi: new FormControl('',[Validators.required]),
      txtSDT: new FormControl('', [Validators.required, Validators.pattern(this.mobilePattern)]),
      txtEmail: new FormControl('', [this.CustomEmailValidator]),
    });
    
    this._cart.items.subscribe((res) => {
      this.items = res;
      this.total = 0;
      this.totalqty = 0;
      for(let x of this.items){ 
        x.amount = x.quantity * x.unitPrice;
        this.total += x.quantity * x.unitPrice;
        this.totalqty += 1;
      } 
    });
  }
  public CustomEmailValidator(control: AbstractControl): ValidationErrors | null {
    if ((control.value || '').toString() == '') {
      return null;
    }
    return Validators.email(control);
  }
  
  public txtMatKhauCheckValidator(control) {
    var filteredStrings = { search: control.value, select: '@#!$%&*' }
    var result = (filteredStrings.select.match(new RegExp('[' +
    filteredStrings.search + ']', 'g')) || []).join('');
    if ((control.value.length < 6 || result == '') && control.value) {
      return { nameX: true };
    }
  }
  
  public onSubmit(value: any) {
    debugger;
    this.submitted = true;
    // stop here if form is invalid
    if (this.frmLogin.invalid) {
      return;
    }
    debugger;
   

    }
    listItem:any;
    public _userCode:any;
    getDecodedAccessToken(token: string): any {
      try {
        return jwt_decode(token);
      } catch(Error) {
        return null;
      }
    }
    GetData(){
      let token = localStorage.getItem('user');
      let user = <NguoiDung>JSON.parse(token);
      this._userCode = this.getDecodedAccessToken(user.token);
      if(token)  
      {
        this._api.getAuth(`/api/client/customer/get-address?code=${this._userCode.UserCode}`).takeUntil(this.unsubscribe).subscribe(res => {
          this.listItem = res;
        });
      }
     
     }
     selectAddress(item:any)
     {

      this.frmCheckout.controls['txtHo'].setValue(item.fullName);
      this.frmCheckout.controls['txtDiaChi'].setValue(item.address);
      this.frmCheckout.controls['txtSDT'].setValue(item.phone);
     }
  }
 