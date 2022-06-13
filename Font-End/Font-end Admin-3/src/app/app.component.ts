import { AfterViewInit, Component, Injector, OnInit } from '@angular/core';
import { BaseComponent } from './core/base-component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent  implements OnInit{
  title = 'AdminQuanLyBanDoGiaDung';
  constructor() {
    
  }
  ngOnInit() {
    
  }
 
}
