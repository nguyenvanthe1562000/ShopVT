

import { AfterViewInit, Component, Injector, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { BaseComponent } from '../../../core/base-component';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent extends BaseComponent implements OnInit {
  items:any;
  total:any;
  totalqty:number;
  constructor(injector: Injector, private router: Router) { 
    super(injector);
  }
  ngOnInit(): void {

  }
  search(frm:NgForm)
  {debugger;
 

    this.router.navigate([`search/${frm.controls['key'].value}`]);
  }

}
