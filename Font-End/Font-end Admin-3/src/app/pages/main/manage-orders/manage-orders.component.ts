import { Component, Injector, OnInit } from '@angular/core';
import { BaseComponent } from '../../../core/base-component';
import 'rxjs/add/observable/combineLatest';
import 'rxjs/add/operator/takeUntil';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, Validators} from '@angular/forms';
declare var $: any;
@Component({
  selector: 'app-manage-orders',
  templateUrl: './manage-orders.component.html',
  styleUrls: ['./manage-orders.component.css']
})
export class ManageOrdersComponent extends BaseComponent implements OnInit {
  public doneSetup = false;
  public orderdetail:any;
  public orders: any;
  public page = 1;
  public pageSize = 10;
  public totalItems:any;
  public formsearch: any;
  public total:any;
  public SanPhams: any;
  public SanPham: any;
  public soLuong: any;
  public origin_listjson_chitiet:any; 
  public formdata: any;
  public doneSetupForm: any;
  public showUpdateModal: any;
  submitted = false;
  display: boolean = false;
  constructor(private fb: FormBuilder, injector: Injector,private route: ActivatedRoute, private router: Router) {
    super(injector);
  }
  
  ngOnInit(): void {
    this.formsearch = this.fb.group({
      'hoTen': [''],
      'diaChiNhan': [''],     
      'email': [''],     
    });
    
    this.search();
  }
  
  loadPage(page) { 
    this._api.post('/api/DonHang/search',{page: page, pageSize: this.pageSize}).takeUntil(this.unsubscribe).subscribe(res => {
      this.orders = res.data;
      this.totalItems =  res.totalItems;
      this.pageSize = res.pageSize;
    });
  } 
  onRowExpand(row) {
    this.doneSetup = false; 
    this._api.get('/api/DonHang/get-by-id/'+ row.data.maDonHang).subscribe((res:any) => {
      this.orderdetail = res;
      this.doneSetup = true; 
      debugger;
    });
  }
  search() { 
    this.page = 1;
    this.pageSize = 5;
    this._api.post('/api/DonHang/search',{page: this.page, pageSize: this.pageSize, hoTen: this.formsearch.get('hoTen').value, diaChiNhan: this.formsearch.get('diaChiNhan').value, email: this.formsearch.get('email').value}).takeUntil(this.unsubscribe).subscribe(res => {
      this.orders = res.data;
      this.totalItems =  res.totalItems;
      this.pageSize = res.pageSize;
    });
  }
  
  onSubmit(value) {
    debugger;
    this.orderdetail.hoTen = this.formdata.get('hoTen').value;
    this.orderdetail.diaChiNhan = this.formdata.get('diaChiNhan').value;
    
    let orderdetail_new =  $.extend(true, {},   this.orderdetail);
    orderdetail_new.listjson_chitiet = this.compare(this.origin_listjson_chitiet, this.orderdetail.listjson_chitiet, 'maSanPham');
    if(orderdetail_new.listjson_chitiet)
    {
      orderdetail_new.listjson_chitiet.forEach(element => {
        element.soLuong = +element.soLuong;
      });
    } 
console.log( orderdetail_new);
    this._api.post('/api/DonHang/update-hoadon',  orderdetail_new).takeUntil(this.unsubscribe).subscribe(res => {
      this.display = false;
      alert('Cập nhật thành công');
      this.search();
      
    });
   
  }
  public Them() {
    debugger;
    let idx = this.SanPhams.findIndex(x => x.maSanPham == this.SanPham);
    if (idx !== -1) {
      let _item_name = this.SanPhams[idx].tenSanPham;
      let _price = this.SanPhams[idx].giaBan;
      this.orderdetail.listjson_chitiet.push({ tenSanPham: _item_name, maDonHang: this.orderdetail.maDonHang, maSanPham: this.SanPham, soLuong: this.soLuong, giaBan: _price });
    }
  }
  Xoa(SanPham) {
    let idx = this.orderdetail.listjson_chitiet.findIndex(x => x.maSanPham == SanPham.maSanPham);
    if (idx !== -1) {
      this.orderdetail.listjson_chitiet.splice(idx, 1);
    }
  }
  
  
  public openUpdateModal(row) {
    this.doneSetupForm = false;
    this.display = true;
    setTimeout(() => {
      this._api.get('/api/DonHang/get-by-id/' + row.maDonHang).takeUntil(this.unsubscribe).subscribe((res: any) => {
        this.orderdetail = res;
        this.origin_listjson_chitiet = $.extend(true, [],   this.orderdetail.listjson_chitiet);
        this.formdata = this.fb.group({
          'hoTen': [this.orderdetail.hoTen, Validators.required],
          'diaChiNhan': [this.orderdetail.diaChiNhan],
          'soLuong': [],
          'sanpham': [],
          'abc': [],
        });
        this._api.get('/api/SanPham/get-all').takeUntil(this.unsubscribe).subscribe((res: any) => {
          this.SanPhams = res;
        });
        this.doneSetupForm = true;
      });
    }, 700);
  }
  
  
}
