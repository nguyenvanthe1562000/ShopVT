import { of as observableOf, fromEvent, Subject } from 'rxjs';
import { map } from 'rxjs/operators';
import { FileUpload } from 'primeng/fileupload';
import { ApiService } from '../core/service/api.service';
import { ActivatedRoute } from '@angular/router';
import { Injector, Renderer2 } from '@angular/core';
import { AbstractControl } from '@angular/forms';

declare var $: any;

export class BaseComponent {
   public genders: any;
   public roles: any;
   public locale_vn: any;
   public today: any;
   public dateFormat: any;

   public unsubscribe = new Subject();
   public _renderer: any;
   public _api: ApiService;
   public _url = 'https://localhost:5001';
   public _route: ActivatedRoute;
   public _apiLookUp = "/api/lookup";
   public _currency ='VND'
   constructor(injector: Injector) {

      this._renderer = injector.get(Renderer2);
      this._api = injector.get(ApiService);
      this._route = injector.get(ActivatedRoute);
      this.today = new Date();
      this.dateFormat = "dd/mm/yy";
      this.genders = [
         { label: 'Nam', value: 'Nam' },
         { label: 'Nữ', value: 'Nữ' },
         { label: 'Khác', value: 'Khác' }
      ];
      this.roles = [
         { label: 'Admin', value: 'Admin' },
         { label: 'User', value: 'User' }
      ];
      this.locale_vn = {
         "firstDayOfWeek": 1,
         "dayNames": [
            "Chủ nhật",
            "Thứ 2",
            "Thứ 3",
            "Thứ 4",
            "Thứ 5",
            "Thứ 6",
            "Thứ 7"
         ],
         "dayNamesShort": [
            "CN",
            "T2",
            "T3",
            "T4",
            "T5",
            "T6",
            "T7"
         ],
         "dayNamesMin": [
            "CN",
            "T2",
            "T3",
            "T4",
            "T5",
            "T6",
            "T7"
         ],
         "monthNames": [
            "Tháng 1",
            "Tháng 2",
            "Tháng 3",
            "Tháng 4",
            "Tháng 5",
            "Tháng 6",
            "Tháng 7",
            "Tháng 8",
            "Tháng 9",
            "Tháng 10",
            "Tháng 11",
            "Tháng 12"
         ],
         "monthNamesShort": [
            "Th 1",
            "Th 2",
            "Th 3",
            "Th 4",
            "Th 5",
            "Th 6",
            "Th 7",
            "Th 8",
            "Th 9",
            "Th 10",
            "Th 11",
            "Th 12"
         ],
         "today": "Hôm nay",
         "clear": "Xóa"
      };
   }

  

   public convertToSlug(str: string): string {
      str = str.replace(/^\s+|\s+$/g, ''); // trim
      str = str.toLowerCase();

      // remove accents, swap ñ for n, etc
      var from = "ãàáäâẽèéëêìíïîõòóöôùúüûñç·/_,:;";
      var to = "aaaaaeeeeeiiiiooooouuuunc------";
      for (var i = 0, l = from.length; i < l; i++) {
         str = str.replace(new RegExp(from.charAt(i), 'g'), to.charAt(i));
      }

      str = str.replace(/[^a-z0-9 -]/g, '') // remove invalid chars
         .replace(/\s+/g, '-') // collapse whitespace and replace by -
         .replace(/-+/g, '-'); // collapse dashes

      return str;
   }

   public ConvertFormDataToObject(obj:any ,formData: FormData) {      
      formData.forEach(function (value, key) {
         obj[key] = value;
      });     
   }
   public ConvertNgFormToObject(form: any, obj: any) {
      Object.keys(form.controls).forEach((control: string) => {
         const typedControl: AbstractControl = form.controls[control];
         obj[control] =  typedControl.value;
         // should log the form controls value and be typed correctly
      });
   }
   public ConvertObjectToFormData(obj: any, formData: FormData) {
      Object.keys(obj).forEach(control => {
         const typedControl: AbstractControl = obj[control];
         formData.append(control, obj[control]);

         // should log the form controls value and be typed correctly
      });
   }

   public ConvertNgFormToFormData(form: any, formData: FormData) {
      Object.keys(form.controls).forEach((control: string) => {
         const typedControl: AbstractControl = form.controls[control];
         formData.append(control, typedControl.value);
         // should log the form controls value and be typed correctly
      });
   }

   public getEncodeFromImage(fileUpload: FileUpload) {
      if (fileUpload) {
         if (fileUpload.files == null || fileUpload.files.length == 0) {
            return observableOf('');
         }
         let file: File = fileUpload.files[0];
         let reader: FileReader = new FileReader();
         reader.readAsDataURL(file);
         return fromEvent(reader, 'load').pipe(
            map((e) => {
               let result = '';
               let tmp: any = reader.result;
               let baseCode = tmp.substring(tmp.indexOf('base64,', 0) + 7);
               result = file.name + ';' + file.size + ';' + baseCode;
               return result;
            })
         );
      } else {
         return observableOf(null);
      }
   }

   public compare(pObject_1, pObject_2, keyField = 'id') {
      let result = [];
      let originSources = [];
      let originIDs = [];
      let handleSources = [];
      let handleIDs = [];
      if (pObject_1 == null && pObject_2 != null) {
         if (!$.isArray(pObject_2)) {
            return [Object.assign({}, pObject_2, { status: 1 })];
         } else {
            pObject_2.forEach(ds => {
               result.push(Object.assign({}, ds, { status: 1 }));
            });
            return result;
         }
      }

      if (pObject_1 != null && pObject_2 == null) {
         if (!$.isArray(pObject_1)) {
            return [Object.assign({}, pObject_1, { status: 3 })];
         } else {
            pObject_1.forEach(ds => {
               result.push(Object.assign({}, ds, { status: 3 }));
            });
            return result;
         }
      }

      if (!$.isArray(pObject_1)) {
         pObject_1 = [{ data: pObject_1 }];
      }

      if (!$.isArray(pObject_2)) {
         pObject_2 = [{ data: pObject_2 }];
      }
      this.executeRecursive(pObject_1, (item) => {
         let tmp = Object.assign({}, item);
         if (tmp.parent) {
            tmp.parent = null;
         }
         originSources.push(tmp.data || tmp);
      });
      for (let i = 0; i < originSources.length; i++) {
         originIDs.push(originSources[i][keyField]);
         if (originSources[i].children) {
            originSources[i].children = null;
         }
      }
      this.executeRecursive(pObject_2, (item) => {
         let tmp = Object.assign({}, item);
         if (tmp.parent) {
            tmp.parent = null;
         }
         handleSources.push(tmp.data || tmp);
      });
      for (let i = 0; i < handleSources.length; i++) {
         handleIDs.push(handleSources[i][keyField]);
         if (handleSources[i].children) {
            handleSources[i].children = null;
         }
      }
      for (let i = 0; i < originIDs.length; i++) {
         // Record keep on new item
         let idx = handleIDs.indexOf(originIDs[i]);
         if (idx > -1) {
            let origin = Object.assign({}, originSources[i]);
            let handle = Object.assign({}, handleSources[idx]);
            this.formatTypeofToStringObject(origin);
            this.formatTypeofToStringObject(handle);
            // Compare to set status
            if (JSON.stringify(origin, Object.keys(origin).sort()) != JSON.stringify(handle, Object.keys(origin).sort())) {
               result.push(Object.assign({}, handleSources[idx], { status: 2 }));
            }
         } else {
            result.push(Object.assign({}, originSources[i], { status: 3 }));
         }
      }
      for (let i = 0; i < handleIDs.length; i++) {
         // New item -> set status to 1
         if (originIDs.indexOf(handleIDs[i]) < 0) {
            result.push(Object.assign({}, handleSources[i], { status: 1 }));
         }
      }
      return result;
   }
   public executeRecursive(data, predicate) {
      return !!!data ? null : data.reduce((list, entry) => {
         predicate(entry);
         if (entry.data && entry.data.children != null) {
            this.executeRecursive(entry.data.children, predicate);
         } else if (entry.children != null) {
            this.executeRecursive(entry.children, predicate);
         }
         return list;
      }, []);
   }
   public formatTypeofToStringObject(obj) {
      if (obj && typeof obj === 'object') {
         for (let i in obj) {
            if (Array.isArray(obj[i])) {
               for (let j in obj[i]) {
                  this.formatTypeofToStringObject(obj[i][j]);
               }
            }
            if (typeof obj[i] === 'number') { obj[i] = obj[i].toString(); }
            if (obj[i] instanceof Date) { obj[i] = obj[i].toString(); }
         }
      }
   }
   public loadScripts() {
      this.renderExternalScript('assets/js/app.js').onload = () => {
      }
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