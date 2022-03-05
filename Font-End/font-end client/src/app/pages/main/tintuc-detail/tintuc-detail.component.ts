import { Component, Injector, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BaseComponent } from '../../../core/base-component';

@Component({
  selector: 'app-tintuc-detail',
  templateUrl: './tintuc-detail.component.html',
  styleUrls: ['./tintuc-detail.component.css']
})
export class TintucDetailComponent extends BaseComponent implements OnInit {

constructor(injector: Injector,private route: ActivatedRoute) { 
    super(injector);
  }
  public list_tintuc: any;
  public page = 1;
  public pageSize = 4;
  public totalItems:any;
  ngOnInit(): void {
    window.scroll(0,0);
     window.scroll(0,0);
    this.route.params.subscribe(params => {
      let id = params['id'];
      this._api.get('/api/TinTuc/GetById/' + id).takeUntil(this.unsubscribe).subscribe(res => {
        this.tintuc = res;

      });
      this._api.post('/api/TinTuc/get-paging',{page: this.page, pageSize: this.pageSize}).takeUntil(this.unsubscribe).subscribe(res => {
        this.list_tintuc = res.data;
        this.totalItems = res.totalItems;
        setTimeout(() => {
          this.loadScripts();
        });
      });
    });
  }
  tintuc:any;
  
}
