import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder, } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from '../../../core/authentication.service';
import { first } from 'rxjs/operators';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  frmLogin: FormGroup;
  loading = false;
  submitted = false;
  returnUrl: string;
  error = '';
  ipAddress = '';
  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private httpclient: HttpClient,
    private authenticationService: AuthenticationService
  ) {
    // redirect to home if already logged in
    if (this.authenticationService.userValue) {
      this.router.navigate(['/auth/login']);
    }
  }

  ngOnInit(): void {
    this.frmLogin = this.formBuilder.group({
      TaiKhoan: ['', Validators.required],
      MatKhau: ['', Validators.required],
      remember: [''],
    });
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
    this.httpclient.get("http://api.ipify.org/?format=json").subscribe((res: any) => {
      this.ipAddress = res.ip;
    });
  }

  get f() {
    return this.frmLogin.controls;
  }

  onSubmit() {
    this.submitted = true;
    // stop here if form is invalid
    if (this.frmLogin.invalid) {
      return;
    }
    debugger;
    this.loading = true;
    this.authenticationService
      .login(this.f.TaiKhoan.value, this.f.MatKhau.value, this.ipAddress)
      .pipe(first())
      .subscribe(
        (data) => {
          this.router.navigate([this.returnUrl]);
        },
        (error) => {
          alert("Đăng nhập thất bại");
          this.loading = false;
        }
      );
  }


}
