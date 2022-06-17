import { Component, Injector, OnInit } from '@angular/core';
import { BaseComponent } from '../../../core/base-component';
import 'rxjs/add/observable/combineLatest';
import 'rxjs/add/operator/takeUntil';
import { FormBuilder, NgForm } from '@angular/forms';
import { AbstractControl, FormControl, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { Router } from '@angular/router';
@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent extends BaseComponent implements OnInit {
  public categories:any;
  public categoriesblog:any;
  public products_group:any;
  public frmSearch: FormGroup;
  total:any;
  amount:any;
  constructor(injector: Injector  ,  private router: Router) {
    super(injector);
   }

  ngOnInit(): void {
    this.frmSearch = new FormGroup({
      
      keytxt: new FormControl('',[Validators.required])
    });
    this._api.get('/api/client/home/category-product').takeUntil(this.unsubscribe).subscribe(res => {
      this.categories = res;
    }); 
    this._api.get('/api/client/home/category-post').takeUntil(this.unsubscribe).subscribe(res => {
      this.categoriesblog = res;
    }); 

    this._cart.items.subscribe((res) => {
      this.total = res? res.length:0;
      this.amount = 0;
      for(let x of res){ 
        x.money = x.quantity * x.UnitPrice;
        this.amount += x.quantity * x.UnitPrice;
      } 
    });
  }
 onSubmit(form: NgForm) {
 const app = document.getElementById("search");
 app.classList.remove('open');
 
    this.router.navigate(['/tim-kiem/'+form.value.txtKey]);
    }
}
