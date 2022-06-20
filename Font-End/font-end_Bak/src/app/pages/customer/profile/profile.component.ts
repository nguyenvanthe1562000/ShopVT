import { Component, Injector, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NguoiDung } from 'src/app/shared/model/NguoiDung';
import { PagedResult } from 'src/app/shared/model/PageResult';
import { PagingRequest } from 'src/app/shared/model/PagingRequest';
import { BaseComponent } from '../../../core/base-component';import jwt_decode from 'jwt-decode';
@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent extends BaseComponent implements OnInit {

  constructor(injector: Injector, private route: ActivatedRoute) {
    super(injector);
  }
  public list_item: any;
  public page = 1;
  public pageSize = 12;
  public totalItems: any;
  public filter: PagingRequest;
  public categories: any
  public listItem: PagedResult<any>;
  public item: any;
  api: string = "/api/client/customer";
  UserCode: string = "";
  ngOnInit(): void {
    window.scroll(0, 0);
    window.scroll(0, 0);
   debugger;
   let token = localStorage.getItem('user');
   let user = <NguoiDung>JSON.parse(token);
   this._userCode = this.getDecodedAccessToken(user.token);
  
    this.route.params.subscribe(params => {
      let id = params['id'];
      this._api.getAuth(`${this.api}?code=${this._userCode.UserCode}`).takeUntil(this.unsubscribe).subscribe(res => {
        this.item = res;
 console.log(this.item);
       
        setTimeout(() => {
          this.loadScripts();
        });
      });
    });  
  }
  public _userCode:any;
  getDecodedAccessToken(token: string): any {
    try {
      return jwt_decode(token);
    } catch(Error) {
      return null;
    }
  }
  
  itemRelated: any;

  slide: any;
 
}
