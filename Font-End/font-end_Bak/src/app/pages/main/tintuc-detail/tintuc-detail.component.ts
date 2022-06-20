import { Component, Injector, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PagedResult } from 'src/app/shared/model/PageResult';
import { PagingRequest } from 'src/app/shared/model/PagingRequest';
import { BaseComponent } from '../../../core/base-component';

@Component({
  selector: 'app-tintuc-detail',
  templateUrl: './tintuc-detail.component.html',
  styleUrls: ['./tintuc-detail.component.css']
})
export class TintucDetailComponent extends BaseComponent implements OnInit {

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
  api: string = "/api/client/post";
  ngOnInit(): void {
    window.scroll(0, 0);
    window.scroll(0, 0);
    this.getSlide();
    this.route.params.subscribe(params => {
      let id = params['id'];
      this._api.get('/api/client/post/' + id).takeUntil(this.unsubscribe).subscribe(res => {
        this.item = res;
        this.getRelated();
        setTimeout(() => {
          this.loadScripts();
        });
      });
    });
    this._api.get('/api/client/home/category-post').takeUntil(this.unsubscribe).subscribe(res => {
      this.categories = res;
    });
  }

  itemRelated:any;
  getRelated()
  {
    this._api.get('/api/client/post/related?v=' + this.item.postCategoryCode).takeUntil(this.unsubscribe).subscribe(res => {
      this.itemRelated=res;
    });
   
  }
  slide: any;
  getSlide()
  {
    debugger;
    this._api.get(`${this.api}/slide`).takeUntil(this.unsubscribe).subscribe(res => {
      this.slide = res;
      console.log(this.slide);
     
    }); 
  }
}
