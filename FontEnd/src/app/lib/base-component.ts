import { of as observableOf, fromEvent, Subject } from 'rxjs';
import { map } from 'rxjs/operators';
import { FileUpload } from 'primeng/fileupload';
import { ApiService } from '../lib/api.service';
import { ActivatedRoute } from '@angular/router';
import { Injector } from '@angular/core';
export class BaseComponent {
   public genders: any;
   public roles: any;
   public locale_vn:any;
   public today: any;
   public dateFormat: any;
   public unsubscribe = new Subject();
   public _api: ApiService;
   public _route: ActivatedRoute;
   constructor(injector: Injector) { 
          this.today = new Date();
          this.dateFormat = "dd/mm/yy";
          this.genders =  [
            {label:'Nam',value:'Nam'},
            {label:'Nữ',value:'Nữ'},
            {label:'Khác',value:'Khác'}
          ];   
          this.roles =  [
            {label:'Admin',value:'Admin'},
            {label:'User',value:'User'}
          ];   
          this.locale_vn={
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
          this._api = injector.get(ApiService);
          this._route = injector.get(ActivatedRoute);
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
}