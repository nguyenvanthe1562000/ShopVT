import { AfterViewInit, Component, Injector, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from '../../../core/authentication.service';
import { BaseComponent } from '../../../core/base-component';

@Component({
  selector: 'app-left-slidebar',
  templateUrl: './left-slidebar.component.html',
  styleUrls: ['./left-slidebar.component.css']
})
export class LeftSlidebarComponent extends BaseComponent implements OnInit, AfterViewInit{
  
  constructor(injector: Injector, private router: Router, private authenticationService: AuthenticationService) {
    super(injector);
     // redirect to home if already logged in
    //  if (this.authenticationService.userValue) {
    //   this.router.navigate(['/auth/login']);
    // }
  }
  ngOnInit() {}
  onLogin(){
    this.router.navigate(['/auth/login']);
  }
  onRegister(){
    this.router.navigate(['/auth/register']);
  }
  onLogOut(){
    this.authenticationService.logout();
  }
  ngAfterViewInit() { 
    this.loadScripts(); 
  }

}