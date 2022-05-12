import { HttpClient } from '@angular/common/http';
import { Component, Injector, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BaseComponent } from 'src/app/core/base-component';
import { SanPham } from 'src/app/shared/models/SanPham';

@Component({
  selector: 'app-open-inventory-system',
  templateUrl: './open-inventory-system.component.html',
  styleUrls: ['./open-inventory-system.component.css']
})
export class OpenInventorySystemComponent  extends BaseComponent implements OnInit {
  public products: any;
  public product: any;
  public page = 1;
  public pageSize = 10;
  public totalItems: any;
  public formsearch: any;
  constructor(private fb: FormBuilder, private httpclient: HttpClient, injector: Injector, private route: ActivatedRoute, private router: Router) {
    super(injector);

    this.product = new SanPham();
  }
  isEdit: boolean = false;
  ngOnInit(): void {
this. getIPAddress();
    this._api.get('/api/vOpenInventorySystem/get-all').takeUntil(this.unsubscribe).subscribe(res => {
      this.products = res;
  
      for (var val of res) {
        if(val.quantity<0)
        {
          this.IsWrong=true;
          break;
        }
      }
    });

  }
  ipAddress = '';
  IsWrong: boolean = false;
  getIPAddress()
  {
    this.httpclient.get("http://api.ipify.org/?format=json").subscribe((res:any)=>{
      this.ipAddress = res.ip;
    });
  }
}
