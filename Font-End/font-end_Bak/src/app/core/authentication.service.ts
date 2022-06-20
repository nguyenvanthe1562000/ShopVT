import { environment } from './../../environments/environment';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { NguoiDung } from '../shared/model/NguoiDung';
 
@Injectable({ providedIn: 'root' })
export class AuthenticationService {
    private userSubject: BehaviorSubject<NguoiDung>;
    public user: Observable<NguoiDung>;

    constructor(
        private router: Router,
        private http: HttpClient
    ) {
        this.userSubject = new BehaviorSubject<NguoiDung>(JSON.parse(localStorage.getItem('user')));
        this.user = this.userSubject.asObservable();
    }

    public get userValue(): NguoiDung {
        return this.userSubject.value;
       
    }
    register(userName: string, passWord: string, email: string)
    {debugger;
        return this.http.post<any>(`${environment.apiUrl}/api/LoginClient/register`, { userName, passWord ,email})
        .pipe(map(user => {
            // store user details and jwt token in local storage to keep user logged in between page refreshes
            localStorage.setItem('user', JSON.stringify(user));
            this.login(userName,passWord,email);
            return user;
        }));
    }
    login(userName: string, passWord: string, ipAddress: string) {
        debugger;
        return this.http.post<any>(`${environment.apiUrl}/api/LoginClient/Login-Client`, { userName, passWord })
            .pipe(map(user => {
                // store user details and jwt token in local storage to keep user logged in between page refreshes
                localStorage.setItem('user', JSON.stringify(user));
                this.userSubject.next(user);
                return user;
            }));
    }

    logout() {
        // remove user from local storage to log user out
        localStorage.removeItem('user');
        this.userSubject.next(null);
        this.router.navigate(['/']);
    }

    remove() {
        // remove user from local storage to log user out
        localStorage.removeItem('user');
        this.userSubject.next(null);
    }
}