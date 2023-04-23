import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, map } from 'rxjs/operators';
import { Observable, throwError as observableThrowError } from 'rxjs';
import { NguoiDung } from 'src/app/shared/models/NguoiDung';
import { AbstractControl, NgForm } from '@angular/forms';
import jwt_decode from 'jwt-decode';
@Injectable({
  providedIn: 'root',
})
export class ApiService {
  public host = 'https://localhost:5001';
  user: NguoiDung;
  constructor(private _http: HttpClient, public router: Router) {
    let token = localStorage.getItem('user');
    this.user = <NguoiDung>JSON.parse(token);
    this.CheckTokenExpirationTime();
  }
  CheckTokenExpirationTime() {
    let token = localStorage.getItem('user');
    if (token) {
      //Check token hết hạn  
      const tokenPayload = jwt_decode(token);
       
      console.log(tokenPayload);
      const test = tokenPayload as { [exp: string]: any };
      const expirationTime = test.exp;
      const currentTime = Date.now() / 1000; // convert to seconds
      if (expirationTime < currentTime) {
        localStorage.removeItem('user')
        this.router.navigate(['/auth/login']);
      }
    }
    else{
      this.router.navigate(['/auth/login']);
    }
  }
  postFormData(url: string, formData: FormData) {
    this.CheckTokenExpirationTime();
    let cloneHeader: any = {};
    let token = localStorage.getItem('user');
    this.user = <NguoiDung>JSON.parse(token);
    cloneHeader['Authorization'] = `Bearer ${this.user.token}`;
    const headerOptions = new HttpHeaders(cloneHeader);
    return this._http.post(this.host + url, formData, { headers: headerOptions }).pipe(
      map((res: any) => {
        return res;
      })
    ).pipe(
      catchError((err: Response) => {
        return this.handleError(err);
      })
    );;

  }
  postWithFormControl(url: string, form: NgForm) {
    this.CheckTokenExpirationTime();
    var object = {};
    let token = localStorage.getItem('user');
    this.user = <NguoiDung>JSON.parse(token);
    Object.keys(form.controls).forEach((control: string) => {
      const typedControl: AbstractControl = form.controls[control];
      object[control] = typedControl.value;
    });
    var body = JSON.stringify(object);

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
          return this.handleError(err);
        })
      );
  }
  post(url: string, obj: any) {
    this.CheckTokenExpirationTime();
    let token = localStorage.getItem('user');
    this.user = <NguoiDung>JSON.parse(token);
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
          return this.handleError(err);
        })
      );
  }
  serverContraint(name:string, listParameters: Array<any>) {
    try {
      this.CheckTokenExpirationTime();

      const serverContraintClass = {
        command: false,
        parameters: []
      };
      let contraint = Object.create(serverContraintClass);
      contraint.command = name;
      contraint.parameters = listParameters;
      let token = localStorage.getItem('user');
      this.user = <NguoiDung>JSON.parse(token);
      const body = JSON.stringify(contraint);
      let cloneHeader: any = {};
      cloneHeader['Content-Type'] = 'application/json';
      cloneHeader['Authorization'] = `Bearer ${this.user.token}`;
      const headerOptions = new HttpHeaders(cloneHeader);
      return this._http
        .post<any>(this.host + '/api/server-contraint', body, { headers: headerOptions })
        .pipe(
          map((res: any) => {
            return res;
          })
        ).pipe(
          catchError((err: Response) => {
            return this.handleError(err);
          })
        );
    } catch (error) {
      alert(error)
    }
 
  }
  get(url: string) {
    this.CheckTokenExpirationTime();
    let token = localStorage.getItem('user');
    this.user = <NguoiDung>JSON.parse(token);
    let cloneHeader: any = {};
    cloneHeader['Content-Type'] = 'application/json';
    cloneHeader['Authorization'] = `Bearer ${this.user.token}`;
    const headerOptions = new HttpHeaders(cloneHeader);
   
    return this._http
      .get(this.host + url, { headers: headerOptions })
      .pipe(
        map((res: any) => {
          return res;
        }), catchError(error => {
       

          return this.handleError({ error });
        })
      ).pipe(
        catchError((err: Response) => {
        
          return this.handleError(err);
        })
      );
  }

  getTest<T>(url: string) {
    this.CheckTokenExpirationTime();
    let token = localStorage.getItem('user');
    this.user = <NguoiDung>JSON.parse(token);
    let cloneHeader: any = {};
    cloneHeader['Content-Type'] = 'application/json';
    cloneHeader['Authorization'] = `Bearer ${this.user.token}`;
    const headerOptions = new HttpHeaders(cloneHeader);
    return this._http
      .get<T>(this.host + url, { headers: headerOptions })
      .pipe(
        map((res: T) => {
          return res;
        })
      ).pipe(
        catchError((err: Response) => {
          return this.handleError(err);
        })
      );
  }
  Lookup3(url: string, obj: any) {
    this.CheckTokenExpirationTime();
    let token = localStorage.getItem('user');
    this.user = <NguoiDung>JSON.parse(token);
    const body = JSON.stringify(obj);
    let cloneHeader: any = {};
    cloneHeader['Content-Type'] = 'application/json';
    cloneHeader['Authorization'] = `Bearer ${this.user.token}`;
    const headerOptions = new HttpHeaders(cloneHeader);
    // let headers = new Headers();
    // headers.append('Content-Type', 'application/json');
    // let authToken = localStorage.getItem('auth_token');
    // headers.append('Authorization', `Bearer ${authToken}`);
    return this._http
      .post<any>(this.host + url, body, { headers: headerOptions })
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
  getLookup2(url: string, str: string) {
    this.CheckTokenExpirationTime();
    let token = localStorage.getItem('user');
    this.user = <NguoiDung>JSON.parse(token);
    let cloneHeader: any = {};
    cloneHeader['Content-Type'] = 'application/json';
    cloneHeader['Authorization'] = `Bearer ${this.user.token}`;
    const headerOptions = new HttpHeaders(cloneHeader);
    return this._http
      .get(this.host + `/api/${url}?v=${str}`, { headers: headerOptions })
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
  getLookup(url: string, str: string) {
    this.CheckTokenExpirationTime();
    let token = localStorage.getItem('user');
    this.user = <NguoiDung>JSON.parse(token);
    let cloneHeader: any = {};
    cloneHeader['Content-Type'] = 'application/json';
    cloneHeader['Authorization'] = `Bearer ${this.user.token}`;
    const headerOptions = new HttpHeaders(cloneHeader);
    return this._http
      .get(this.host + `/api/${url}/look-up?v=${str}`, { headers: headerOptions })
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
  putParamUrl(url: string, obj: number) {
    this.CheckTokenExpirationTime();
    let token = localStorage.getItem('user');
    this.user = <NguoiDung>JSON.parse(token);
    let cloneHeader: any = {};
    cloneHeader['Content-Type'] = 'application/json';
    cloneHeader['Authorization'] = `Bearer ${this.user.token}`;
    const headerOptions = new HttpHeaders(cloneHeader);
    return this._http
      .put(this.host + url + `?rowid=${obj}`, null, { headers: headerOptions })
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
  putFormData(url: string, formData: FormData) {
    this.CheckTokenExpirationTime();
    let token = localStorage.getItem('user');
    this.user = <NguoiDung>JSON.parse(token);
    let cloneHeader: any = {};
    cloneHeader['Authorization'] = `Bearer ${this.user.token}`;
    const headerOptions = new HttpHeaders(cloneHeader);
    return this._http.put(this.host + url, formData, { headers: headerOptions }).pipe(
      map((res: any) => {
        return res;
      })
    ).pipe(
      catchError((err: Response) => {
        return this.handleError(err);
      })
    );;

  }
  put(url: string, obj: any) {
    this.CheckTokenExpirationTime();
    let token = localStorage.getItem('user');
    this.user = <NguoiDung>JSON.parse(token);
    let cloneHeader: any = {};
    cloneHeader['Content-Type'] = 'application/json';
    cloneHeader['Authorization'] = `Bearer ${this.user.token}`;
    const headerOptions = new HttpHeaders(cloneHeader);
    let body = JSON.stringify(obj);
    return this._http
      .put(this.host + url, body, { headers: headerOptions })
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
  deleteParamUrl(url: string, obj: number) {
    this.CheckTokenExpirationTime();
    let token = localStorage.getItem('user');
    this.user = <NguoiDung>JSON.parse(token);
    let cloneHeader: any = {};
    cloneHeader['Content-Type'] = 'application/json';
    cloneHeader['Authorization'] = `Bearer ${this.user.token}`;
    const headerOptions = new HttpHeaders(cloneHeader);
    return this._http
      .delete(this.host + url + `?rowid=${obj}`, { headers: headerOptions })
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
    this.CheckTokenExpirationTime();
    let token = localStorage.getItem('user');
    this.user = <NguoiDung>JSON.parse(token);
    let cloneHeader: any = {};
    cloneHeader['Content-Type'] = 'application/json';
    cloneHeader['Authorization'] = `Bearer ${this.user.token}`;
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


  ServerConstraint(ServerConstraintRequest) {
    this.CheckTokenExpirationTime();
    let token = localStorage.getItem('user');
    this.user = <NguoiDung>JSON.parse(token);
    const body = JSON.stringify(ServerConstraintRequest);
    let cloneHeader: any = {};
    cloneHeader['Content-Type'] = 'application/json';
    cloneHeader['Authorization'] = `Bearer ${this.user.token}`;
    const headerOptions = new HttpHeaders(cloneHeader);
 
    return this._http
      .post<any>(this.host + '/api/server-contraint', ServerConstraintRequest, { headers: headerOptions })
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
