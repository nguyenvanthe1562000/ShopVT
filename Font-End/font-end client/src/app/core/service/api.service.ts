import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, map } from 'rxjs/operators';
import { throwError as observableThrowError } from 'rxjs';
import { NguoiDung } from 'src/app/shared/model/NguoiDung';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  public host = 'https://localhost:5001';
  constructor(private _http: HttpClient, public router: Router) {}
  post(url: string, obj: any) {
    // const body = JSON.stringify(obj);
    let cloneHeader: any = {};
    cloneHeader['Content-Type'] = 'application/json';
    const headerOptions = new HttpHeaders(cloneHeader);
    return this._http
      .post<any>(this.host + url, obj)
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
    const headerOptions = new HttpHeaders(cloneHeader);
    return this._http
      .get(this.host + url, { headers: headerOptions })
      .pipe(
        map((res: any) => {
          return res;
        })
      ).pipe(
        catchError((err: Response) => {
          if (err.status === 401) {
            this.router.navigate(['/login']);
          }
          else
          {
            return this.handleError(err);
          }
        })
      );
  } user: NguoiDung;
  getAuth(url: string) {
    let token = localStorage.getItem('user');
    this.user= <NguoiDung>JSON.parse(token);
    let cloneHeader: any = {};
    cloneHeader['Content-Type'] = 'application/json';
    cloneHeader['Authorization'] = `Bearer ${this.user.token}`;
    const headerOptions = new HttpHeaders(cloneHeader);
    return this._http
      .get(this.host + url, { headers: headerOptions })
      .pipe(
        map((res: any) => {
          return res;
        })
      ).pipe(
        catchError((err: Response) => {
          if (err.status === 401) {
            this.router.navigate(['/login']);
          }
          else
          {
            return this.handleError(err);
          }
        })
      );
  }

  postAuth(url: string, obj: any) {
    let token = localStorage.getItem('user');
    this.user= <NguoiDung>JSON.parse(token);
    const body = JSON.stringify(obj);
    let cloneHeader: any = {};
    cloneHeader['Content-Type'] = 'application/json';
    cloneHeader['Authorization'] = `Bearer ${this.user.token}`;
    const headerOptions = new HttpHeaders(cloneHeader);
    return this._http
      .post<any>(this.host + url, body, { headers: headerOptions })
      .pipe(
        map((res: any) => {
          return res;
        })
      ).pipe(
        catchError((err: Response) => {
          if (err.status === 401) {
            this.router.navigate(['/login']);
          }
          return this.handleError(err);
        })
      );
  }

  public handleError(error: any) {
    this.router.navigate(['/err']);
    return observableThrowError(error);
  }
}
