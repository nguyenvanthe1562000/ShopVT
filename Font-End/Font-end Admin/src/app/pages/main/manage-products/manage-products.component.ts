import { Component, Injector, OnInit } from '@angular/core';
import { BaseComponent } from '../../../core/base-component';
import 'rxjs/add/observable/combineLatest';
import 'rxjs/add/operator/takeUntil';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, NgForm } from '@angular/forms';
import { SanPham } from '../../../shared/models/SanPham';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ProductLapTopInformation } from 'src/app/shared/models/ProductLapTopInformation';
interface Category {
  maLoai: string,
  tenLoai: string
}
interface Brand {
  maHang: string,
  tenHang: string
}
interface ISanPham {



  MaLoai: string,
  MaHang: string,
  TenSanPham: string,
  XuatXu: string,
  BaoHanh: string,
  MauSac: string,
  GiaBan: string,
  MoTa: string,
  GhiChu: string,
  Anh: string

}

@Component({
  selector: 'app-manage-products',
  templateUrl: './manage-products.component.html',
  styleUrls: ['./manage-products.component.css']
})
export class ManageProductsComponent extends BaseComponent implements OnInit {
  public products: any;
  public product: any;
  public page = 1;
  public pageSize = 10;
  public totalItems: any;
  public formsearch: any;

  public categories: Category[];
  selectedCategory: Category;
  public brands: Brand[];
  selectedBrand: Brand;

  formProduct: FormBuilder;

  constructor(private fb: FormBuilder, private httpclient: HttpClient, injector: Injector, private route: ActivatedRoute, private router: Router) {
    super(injector);

    this.product = new SanPham();
  }
  isEdit: boolean = false;
  ngOnInit(): void {
    this.formsearch = this.fb.group({
      'tenSanPham': ['']
    });
    this.search();
  }

  loadPage(page) {
    this._api.post('/api/SanPham/search', { page: page, pageSize: this.pageSize }).takeUntil(this.unsubscribe).subscribe(res => {
      this.products = res.data;
      this.totalItems = res.totalItems;
      this.pageSize = res.pageSize;
    });
  }

  search() {
    this.page = 1;
    this.pageSize = 5;
    debugger;
    this._api.post('/api/SanPham/search', { page: this.page, pageSize: this.pageSize, tenSanPham: this.formsearch.get('tenSanPham').value }).takeUntil(this.unsubscribe).subscribe(res => {
      this.products = res.data;
      this.totalItems = res.totalItems;
      this.pageSize = res.pageSize;
    });
  }

  displayAdd: boolean = false;
  showAdd() {
    this.displayAdd = true;
    this._api.get('/api/LoaiSanPham/get-all').takeUntil(this.unsubscribe).subscribe(res => {
      this.categories = res;
    });

    this._api.get('/api/HangSanPham/get-all').takeUntil(this.unsubscribe).subscribe(res => {
      this.brands = res;
    });
  }
  resetform(form) {
    if (form != null)
      form.resetForm();
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
  imgresult: any
  AddNewProduct(form: NgForm) {
    console.log(form.value);
    try {
      let img: string;
      this.upload(this.file).subscribe(res => {
        let sanpham: SanPham = new SanPham();
        sanpham.MaSanPham = "";
        sanpham.MaLoai = form.controls['maLoai'].value;
        sanpham.MaHang = form.controls['maHang'].value;
        sanpham.TenSanPham = form.controls['tenSanPham'].value;
        sanpham.XuatXu = form.controls['xuatXu'].value;
        sanpham.BaoHanh = form.controls['baoHanh'].value;
        sanpham.MauSac = form.controls['mauSac'].value;
        sanpham.GiaBan = form.controls['giaBan'].value;
        sanpham.MoTa = form.controls['moTa'].value;
        sanpham.GhiChu = form.controls['ghiChu'].value;
        sanpham.Anh = res.data;



        this._api.post('/api/sanpham/create-product', sanpham).takeUntil(this.unsubscribe).subscribe(res => {
          let info: ProductLapTopInformation = new ProductLapTopInformation();
          info.ProductCode = res.data;
          info.CPUType = form.value.CPUType;
          info.GraphicsCardType = form.value.GraphicsCardType;
          info.AmountRAM = form.value.AmountRAM;
          info.HardDrive = form.value.HardDrive;
          info.ScreenSize = form.value.ScreenSize;
          info.ScreenResolution = form.value.ScreenResolution;
          info.Communication = form.value.Communication;
          info.OperatingSystem = form.value.OperatingSystem;
          info.Size = form.value.Size;
          info.WIFI = form.value.WIFI;
          info.Bluetooth = form.value.Bluetooth;
          info.Weight = form.value.Weight;
          info.DisplayOrder = 1;
          this._api.post('/api/ProductLapTopInformation/insert', info).takeUntil(this.unsubscribe).subscribe(res => {
          }, err => { });
          this.resetform(form);
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

  edit(product: SanPham) {
    this.product = product;
    this._api.get('/api/LoaiSanPham/get-all').takeUntil(this.unsubscribe).subscribe(res => {
      this.categories = res;
    });

    this._api.get('/api/HangSanPham/get-all').takeUntil(this.unsubscribe).subscribe(res => {
      this.brands = res;
    });
    this.isEdit = true;
  }

  SaveData() {
    try {
      this._api.post('/api/SanPham/update-product', this.product).takeUntil(this.unsubscribe).subscribe(res => {
        alert("Cập nhật thành công");
        this.search();
        this.isEdit = false;
      }, err => { console.log(err); });
    }
    catch (error) {
      console.log(error);
    }
  }

  delete(maSanPham: string) {
    this._api.post('/api/SanPham/delete-product', { MaSanPham: maSanPham }).takeUntil(this.unsubscribe).subscribe(res => {
      alert("Xóa thành công");
      this.search();
    }, err => { console.log(err) });
  }
}
