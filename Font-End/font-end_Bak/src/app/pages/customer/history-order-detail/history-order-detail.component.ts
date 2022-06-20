
import { Component, Injector, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PagedResult } from 'src/app/shared/model/PageResult';
import { PagingRequest } from 'src/app/shared/model/PagingRequest';
import { BaseComponent } from '../../../core/base-component';


@Component({
  selector: 'app-history-order-detail',
  templateUrl: './history-order-detail.component.html',
  styleUrls: ['./history-order-detail.component.css']
})
export class HistoryOrderDetailComponent extends BaseComponent implements OnInit {

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
  api: string = "/api/client/order";
  ngOnInit(): void {
    window.scroll(0, 0);
    window.scroll(0, 0);
   debugger;
    this.route.params.subscribe(params => {
      let id = params['id'];
      this._api.getAuth('/api/client/order/' + id).takeUntil(this.unsubscribe).subscribe(res => {
        this.item = res;
       
        setTimeout(() => {
          this.loadScripts();
        });
      });
    });  
  }
  Cancel(id : number)
  {
    this.item.orderStatus=4;
    this._api.postAuth('/api/client/order/update', this.item).takeUntil(this.unsubscribe).subscribe(res => {
      this.item = res;
    });
  }
  itemRelated: any;

  slide: any;
 
}
