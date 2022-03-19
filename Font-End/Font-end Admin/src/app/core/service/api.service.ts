import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, map } from 'rxjs/operators';
import { throwError as observableThrowError } from 'rxjs';
import { NguoiDung } from 'src/app/shared/models/NguoiDung';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  public host = 'https://localhost:51256';
  user:NguoiDung;
  constructor(private _http: HttpClient, public router: Router) {
    let token= localStorage.getItem('user');
    this.user=<NguoiDung>JSON.parse(token);
    console.log(this.user.token);
  }
  post(url: string, obj: any) {
    const body = JSON.stringify(obj);
    let cloneHeader: any = {};
    cloneHeader['Content-Type'] = 'application/json';
    cloneHeader['Authorization']=`Bearer ${ this.user.token}`;
    const headerOptions = new HttpHeaders(cloneHeader);
      // let headers = new Headers();
      // headers.append('Content-Type', 'application/json');
      // let authToken = localStorage.getItem('auth_token');
      // headers.append('Authorization', `Bearer ${authToken}`);
      console.log(headerOptions);
      return this._http
      .post<any>(this.host + url, body, { headers: headerOptions })
      .pipe(
        map((res: any) => {
          return res ;
        })
      ).pipe(
        catchError((err: Response) => {
          return this.handleError(err);
        })
      );
  }

  get(url: string) {
    let cloneHeader: any = {};
    cloneHeader['Content-Type'] = 'application/json';
    cloneHeader['Authorization']=`Bearer ${ this.user.token}`;
    const headerOptions = new HttpHeaders(cloneHeader);
    return this._http
      .get(this.host + url, { headers: headerOptions })
      .pipe(
        map((res: any) => {
          return res;
        })
      ).pipe(
        catchError((err: Response) => {
          return this.handleError(err);
        })
      );
  }
  put(url: string) {
    let cloneHeader: any = {};
    cloneHeader['Content-Type'] = 'application/json';
    cloneHeader['Authorization']=`Bearer ${ this.user.token}`;
    const headerOptions = new HttpHeaders(cloneHeader);
    return this._http
      .put(this.host + url, { headers: headerOptions })
      .pipe(
        map((res: any) => {
          return res;
        })
      ).pipe(
        catchError((err: Response) => {
          return this.handleError(err);
        })
      );
  }
  delete(url: string) {
    let cloneHeader: any = {};
    cloneHeader['Content-Type'] = 'application/json';
    const headerOptions = new HttpHeaders(cloneHeader);
    return this._http
      .delete(this.host + url, { headers: headerOptions })
      .pipe(
        map((res: any) => {
          return res;
        })
      ).pipe(
        catchError((err: Response) => {
          return this.handleError(err);
        })
      );
  }
  public handleError(error: any) {
    this.router.navigate(['/err']);
    return observableThrowError(error);
  }
}
