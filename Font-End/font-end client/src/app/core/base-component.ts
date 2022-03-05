import { Injector, Renderer2 } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { of as observableOf, Subject } from 'rxjs';
import { ApiService } from './service/api.service';
import { CartService } from './service/cart.service';
import { environment } from '../../environments/environment'
export class BaseComponent {
   public unsubscribe = new Subject();
   public _renderer: any;
   public _api: ApiService;
   public _cart: CartService;
   public _route: ActivatedRoute;
   public _url:any;
   constructor(injector: Injector) {
      this._renderer = injector.get(Renderer2);
      this._cart = injector.get(CartService);
      this._api = injector.get(ApiService);
      this._route = injector.get(ActivatedRoute);
      this._url=environment.apiUrl;
   }
   public loadScripts() {
      
     this.renderExternalScript('assets/libs/jquery/jquery.min.js').onload = () => { },
     this.renderExternalScript('assets/libs/popper/popper.min.js').onload = () => { },
     this.renderExternalScript('assets/libs/bootstrap/js/bootstrap.min.js').onload = () => { },
     this.renderExternalScript('assets/libs/nivo-slider/js/jquery.nivo.slider.js').onload = () => { },
     this.renderExternalScript('assets/libs/owl-carousel/owl.carousel.min.js').onload = () => { },
     this.renderExternalScript('assets/libs/slider-range/js/tmpl.js').onload = () => { },
     this.renderExternalScript('assets/libs/slider-range/js/jquery.dependClass-0.1.js').onload = () => { },
     this.renderExternalScript('assets/libs/slider-range/js/draggable-0.1.js').onload = () => { },
     this.renderExternalScript('assets/libs/slider-range/js/jquery.slider.js').onload = () => { },
     this.renderExternalScript('assets/js/theme.js').onload = () => { }
   
   }
   public renderExternalScript(src: string): HTMLScriptElement {
      const script = document.createElement('script');
      script.type = 'text/javascript';
      script.src = src;
      script.async = true;
      script.defer = true;
      this._renderer.appendChild(document.body, script);
      return script;
   }
}