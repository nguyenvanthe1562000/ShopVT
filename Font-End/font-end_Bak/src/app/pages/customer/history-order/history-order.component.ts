
import { Component, Injector, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PagedResult } from 'src/app/shared/model/PageResult';
import { FilterType, PagingRequest } from 'src/app/shared/model/PagingRequest';
import { BaseComponent } from '../../../core/base-component';
import jwt_decode from 'jwt-decode';
import { NguoiDung } from 'src/app/shared/model/NguoiDung';
@Component({
  selector: 'app-history-order',
  templateUrl: './history-order.component.html',
  styleUrls: ['./history-order.component.css']
})
export class HistoryOrderComponent extends BaseComponent implements OnInit {
  public list_item: any;
  public page = 1;
  public pageSize = 12;
  public totalItems: any;
  public filter: PagingRequest;
  public categories: any
  public listItem: any;
  api: string = "/api/client/post";
  constructor(injector: Injector, private route: ActivatedRoute, private router: Router) {
    super(injector);
    this.filter = new PagingRequest();

  }
UserCode: string = "";
  ngOnInit(): void {
   
    window.scroll(0, 0);
    let token = localStorage.getItem('user');
    let user = <NguoiDung>JSON.parse(token);
    this._userCode = this.getDecodedAccessToken(user.token);
   
    this.route.params.subscribe(params => {
      this.GetHistoryOrder();
      
    });

   
  }
  public _userCode:any;
 
  OrderType(orderStatus){
    this._api.getAuth(`/api/client/order/get-data?code=${this._userCode.UserCode}&v=${orderStatus}`).takeUntil(this.unsubscribe).subscribe(res => {
      this.listItem = res;
    });
  }
  getDecodedAccessToken(token: string): any {
    try {
      return jwt_decode(token);
    } catch(Error) {
      return null;
    }
  }
 GetHistoryOrder(orderStatus:number = -1){
  debugger;
  this._api.getAuth(`/api/client/order/get-data?code=${this._userCode.UserCode}`).takeUntil(this.unsubscribe).subscribe(res => {
    this.listItem = res;
  });
 }

  addToCart(it) {
    this._cart.addToCart(it);
    alert('Thêm thành công!');
  }
}
