import { Component, Injector, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { vB20Order } from 'src/app/shared/model/vB20Order';
import { vB20OrderDetail } from 'src/app/shared/model/vB20OrderDetail';
import { BaseComponent } from '../../../core/base-component';
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
  totalqty:number = 0;
  constructor(injector: Injector) { 
    super(injector);
  }
  
  ngOnInit(): void {
    window.scrollTo(0,0);
    var today = new Date();
    this.ngayDat = today.toLocaleDateString();
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
    this.order= new vB20Order();
   let vB20OrderDetails = new Array<vB20OrderDetail>();
    this.order.customerName = value.txtHo ;
    this.order.customerAddress = value.txtDiaChi;
    this.order.customerMobile = value.txtSDT;
    this.order.customerEmail = value.txtEmail;
    this.order.note = value.txtNote;
    this.order.orderStatus = 0;
    this.order.amount = this.total;
    this.items.forEach(element => {
      let orderDetail = new vB20OrderDetail();
      orderDetail.amount= element.money;
      orderDetail.productCode= element.code;
      orderDetail.quantity= element.quantity;
      orderDetail.unitPrice= element.unitPrice;
      orderDetail.productName= element.name;
      vB20OrderDetails.push(orderDetail);
    });
    this.order.vB20OrderDetail = JSON.stringify(vB20OrderDetails);
    console.log(JSON.stringify(this.order));
    this._api.post(`${this.api}/add`, this.order).takeUntil(this.unsubscribe).subscribe(res => {
      if(res)
      {
        alert("Đặt hàng thành công");
        window.location.href = "/";
        this._cart.clearCart();
      }
    });

    }
   
  }
 