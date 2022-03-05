import { environment } from './../../environments/environment';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { NguoiDung } from '../shared/models/NguoiDung';
 
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

    login(TaiKhoan: string, MatKhau: string, ipAddress: string) {
        return this.http.post<any>(`${environment.apiUrl}/api/NguoiDung/authenticate`, { TaiKhoan, MatKhau, ipAddress })
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
        this.router.navigate(['/auth/login']);
    }

    remove() {
        // remove user from local storage to log user out
        localStorage.removeItem('user');
        this.userSubject.next(null);
    }
}