import { HttpClient } from '@angular/common/http';
import { Component, Injector, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BaseComponent } from 'src/app/core/base-component';

@Component({
  selector: 'app-login-event',
  templateUrl: './login-event.component.html',
  styleUrls: ['./login-event.component.css']
})
export class LoginEventComponent  extends BaseComponent implements OnInit {
  public Events: any;
 
  constructor(private fb: FormBuilder, private httpclient: HttpClient, injector: Injector, private route: ActivatedRoute, private router: Router) {
    super(injector);
  }
  isEdit: boolean = false;
  ngOnInit(): void {
    this._api.get('/api/vLoginEvent/get-all').takeUntil(this.unsubscribe).subscribe(res => {
      this.Events = res;
    });

  }
}
