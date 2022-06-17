import { AfterViewInit, Component, Injector, OnInit } from '@angular/core';
import { BaseComponent } from '../../../core/base-component';


@Component({
  selector: 'app-contact-us',
  templateUrl: './contact-us.component.html',
  styleUrls: ['./contact-us.component.css']
})
export class ContactUsComponent extends BaseComponent implements OnInit, AfterViewInit {

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
