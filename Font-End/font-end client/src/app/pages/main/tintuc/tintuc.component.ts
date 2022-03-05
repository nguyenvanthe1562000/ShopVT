import { Component, Injector, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BaseComponent } from '../../../core/base-component';
@Component({
  selector: 'app-tintuc',
  templateUrl: './tintuc.component.html',
  styleUrls: ['./tintuc.component.css']
})
export class TintucComponent extends BaseComponent implements OnInit {
  public list_tintuc: any;
  public page = 1;
  public pageSize = 10;
  public totalItems:any;


  
  constructor(injector: Injector,private route: ActivatedRoute, private router: Router) { 
    super(injector);
    
  }
 

  ngOnInit(): void {
    window.scroll(0,0);
    this.route.params.subscribe(params => {
      
      this._api.post('/api/TinTuc/get-paging',{page: this.page, pageSize: this.pageSize}).takeUntil(this.unsubscribe).subscribe(res => {
        this.list_tintuc = res.data;
        this.totalItems = res.totalItems;
        setTimeout(() => {
          this.loadScripts();
        });
      });
    });
  }

    loadPage(page) { 
    this._route.params.subscribe(params => {
      
      this._api.post('/api/TinTuc/get-paging', { page: page, pageSize: this.pageSize}).takeUntil(this.unsubscribe).subscribe(res => {
        this.list_tintuc = res.data;
        this.totalItems = res.totalItems;
        }, err => { });       
   });   
  }


}
