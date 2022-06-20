
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder, } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from '../../../core/authentication.service';
import { first } from 'rxjs/operators';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  namePattern= "^([a-zA-ZÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂưăạảấầẩẫậắằẳẵặẹẻẽềềểỄỆỈỊỌÓỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳýỵỷỹ\s]+)$";

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
    
  }

  ngOnInit(): void {
    this.frmLogin = this.formBuilder.group({
      TaiKhoan: ['', Validators.required, Validators.minLength(2), Validators.maxLength(24), Validators.pattern(this.namePattern)],
      Email: ['', Validators.required, Validators.minLength(2), Validators.maxLength(24), Validators.pattern(this.namePattern)],
      MatKhau: ['', Validators.required, Validators.minLength(6), Validators.maxLength(8), Validators.pattern(this.namePattern)],
      MatKhau2: ['', Validators.required,, Validators.minLength(6), Validators.maxLength(8),  Validators.pattern(this.namePattern)],
      remember: [''],
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
    this.f.TaiKhoan.value, this.f.MatKhau.value
    this.authenticationService.register(this.f.TaiKhoan.value, this.f.MatKhau.value, this.f.Email.value)
    .pipe(first())
      .subscribe(
        (data) => {
          this.router.navigate(["/"]);
        },
        (error) => {
          alert("Đăng ký thất bại");
          this.loading = false;
        }
      );
  }


}
