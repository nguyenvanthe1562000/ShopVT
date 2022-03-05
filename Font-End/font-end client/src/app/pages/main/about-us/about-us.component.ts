import { AfterViewInit, Component, Injector, OnInit } from '@angular/core';
import { BaseComponent } from '../../../core/base-component';

@Component({
  selector: 'app-about-us',
  templateUrl: './about-us.component.html',
  styleUrls: ['./about-us.component.css']
})
export class AboutUsComponent extends BaseComponent implements OnInit, AfterViewInit {

  constructor(injector: Injector ) {
    super(injector);
  }

  ngOnInit(): void {
    window.scroll(0,0);
  }
  ngAfterViewInit() { 
    this.loadScripts(); 
   }

}
