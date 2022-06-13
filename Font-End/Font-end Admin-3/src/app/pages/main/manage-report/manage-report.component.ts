// import { Component, OnInit } from '@angular/core';

// @Component({
//   selector: 'app-manage-report',
//   templateUrl: './manage-report.component.html',
//   styleUrls: ['./manage-report.component.css']
// })
// export class ManageReportComponent implements OnInit {

//   constructor() { }

//   ngOnInit(): void {
//   }

// }

import { HttpClient } from '@angular/common/http';
import { Component, Injector, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BaseComponent } from 'src/app/core/base-component';

@Component({
  selector: 'app-manage-report',
  templateUrl: './manage-report.component.html',
  styleUrls: ['./manage-report.component.css']
})
export class ManageReportComponent extends BaseComponent implements OnInit {
  public products: any;
  public page = 1;
  public pageSize = 10;
  public totalItems:any;
  public formsearch: any;
  public getBestSelling:any;
  public arrTenSanPham = [];
  public arrSoLuong = [];
  constructor(private fb: FormBuilder,injector: Injector,private route: ActivatedRoute, private router: Router, private httpclient: HttpClient) {
    super(injector);
  }
  ngOnInit(): void {
    this.formsearch = this.fb.group({
      'tenSanPham': ['']
    });
    this.search();
  }  
  search() { 
    this.page = 1;
    this.pageSize = 5;
    this._api.post('/api/ThongKe/get-sanpham-banchay',{page: this.page, pageSize: this.pageSize, tenSanPham: this.formsearch.get('tenSanPham').value}).takeUntil(this.unsubscribe).subscribe(res => {
      this.products = res;
      this.products.data.forEach(item => {
        this.arrTenSanPham.push(item.tenSanPham);
      });
      this.products.data.forEach(item => {
        this.arrSoLuong.push(item.slbc);
      });
      this.getBestSelling = {
        labels: this.arrTenSanPham,
        datasets: [
          {
            label: 'Số lượng bán chạy',
            backgroundColor: '#42A5F5',
            data: this.arrSoLuong
          },
        ]
      }
    });
  }
}
