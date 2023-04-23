import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'DateVN'
})
export class DateVNPipe implements PipeTransform {

  transform(date: any): string {
    var d = new Date(date);
    var weekday = new Array(7);
    weekday[0] = "Chủ Nhật, ngày ";
    weekday[1] = "Thứ 2, ngày ";
    weekday[2] = "Thứ 3, ngày ";
    weekday[3] = "Thứ 4, ngày ";
    weekday[4] = "Thứ 5, ngày ";
    weekday[5] = "Thứ 6, ngày ";
    weekday[6] = "Thứ 7, ngày ";
    return weekday[d.getDay()] + (d.getUTCDate() + 1) + '/' + (d.getUTCMonth() + 1) + '/' + d.getUTCFullYear();
  }

}
@Pipe({
  name: 'bytes'
})
export class BytesPipe implements PipeTransform {

  transform(value: number, precision: number = 2): string {
    if (value === 0) {
      return '0 bytes';
    }
  
    const units = ['bytes', 'KB', 'MB', 'GB', 'TB', 'PB', 'EB', 'ZB', 'YB'];
    const exponent = Math.floor(Math.log(Math.abs(value)) / Math.log(1024));
    const unit = units[exponent];
    const formattedValue = parseFloat((value / Math.pow(1024, exponent)).toFixed(precision));
  
    return `${formattedValue} ${unit}`;
  }

}