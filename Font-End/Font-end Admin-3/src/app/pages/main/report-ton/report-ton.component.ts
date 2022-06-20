
import { Component, Injector, OnInit } from '@angular/core';
import { BaseComponent } from '../../../core/base-component';
import 'rxjs/add/observable/combineLatest';
import 'rxjs/add/operator/takeUntil';
import { ActivatedRoute, Router } from '@angular/router';
import { AbstractControl, FormBuilder, NgForm } from '@angular/forms';
import { from, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { FilterType, PagingRequest } from '../../../shared/models/PagingRequest';
import { PagedResult } from '../../../shared/models/PageResult';
import { catchError, map } from 'rxjs/operators';
import { formatDate } from '@angular/common';
import { HttpHeaders } from '@angular/common/http';
import { B10Post } from '../../../shared/models/B10Post';
import { B10PostCategory } from '../../../shared/models/B10PostCategory';
import { GroupData } from '../../../shared/models/GroupData';

import { css } from 'jquery';
import { stringify } from 'querystring';
interface FilterTypeColumn { value: string, viewValue: string }
interface FilterTypeValue { value: FilterType, viewValue: string }
@Component({
  selector: 'app-report-ton',
  templateUrl: './report-ton.component.html',
  styleUrls: ['./report-ton.component.css']
})
export class ReportTonComponent extends BaseComponent implements OnInit {
  //exploredata
  public tintuc: any;
  public page = 1;
  public pageSize = 20;
  public totalItems: any;
  public filter: PagingRequest;
  public listItem: any;
  public checkFilter: boolean;
  public ClickColumn: string = '';
  public api: string = '/api/report';
  public groupData: GroupData;
  public selectGroup: any;
  public selectItem: B10Post;
  public filterTypeColumn: any;
  public filterTypeValue: any;
  public displayFormGroup: boolean = false;
  public dataGroup: B10Post;
  public formData = new FormData();
  public addType: number = 0; //thao tác lưu dữ liệu vd 0: lưu và thêm mới
  public lookupRows: number = 10;
  public lookupData: B10PostCategory;
  //editordata
  public displayUpdate: boolean = false;
  public displayConvert: boolean = false;// chuyển nhóm dữ liệu
  displayAdd: boolean = false;
  constructor(private fb: FormBuilder, private httpclient: HttpClient, injector: Injector, private route: ActivatedRoute, private router: Router) {
    super(injector);
    this.filter = new PagingRequest();
    
    this.groupData = new GroupData();
    this.selectItem = new B10Post();
  }

  ngOnInit(): void {
    this.filter.PageIndex = this.page;
    this.filter.PageSize = this.pageSize;
    this.filter.DataIsActive = true;

  }
  //start //explore

 
  search(form: NgForm) {
    this._api.post(`${this.api}/ton`, form.value).takeUntil(this.unsubscribe).subscribe(res => {
      this.listItem = res;
    });
  }
  
  
  //end  //explore

  /// DataEditor

 
  SelectForeignKey(event:any,foreignKey: string)
  {
    this.formData.append(foreignKey, event.code);
  }
  
  //data editor
 
    //end data editor
}
