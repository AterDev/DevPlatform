import { Component, OnInit } from '@angular/core';
// import { OAuthService, OAuthErrorEvent, UserInfo } from 'angular-oauth2-oidc';
import { Router } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AccountService } from 'src/app/services/account.service';
import { SignInForm } from 'src/app/share/models/sign-in-form.model';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public loginForm!: FormGroup; constructor(
    private service: AccountService,
    private router: Router,
    private snb: MatSnackBar

  ) {
  }
  get email() { return this.loginForm.get('email'); }
  get password() { return this.loginForm.get('password'); }
  ngOnInit(): void {
    this.loginForm = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required, Validators.minLength(6), Validators.maxLength(50)])
    });
  }

  /**
   * 错误信息
   * @param type 字段名称
   */
  getValidatorMessage(type: string): string {
    switch (type) {
      case 'email':
        return this.email?.errors?.required ? '邮箱必填' :
          this.email?.errors?.email ? '错误的邮箱格式' : '';
      case 'password':
        return this.password?.errors?.required ? '密码必填' :
          this.password?.errors?.minlength ? '密码长度不可低于6位' :
            this.password?.errors?.maxlength ? '密码长度不可超过50' : '';
      default:
        break;
    }
    return '';
  }
  doLogin(): void {
    if (this.loginForm.valid) {
      const signInForm: SignInForm = {
        username: this.email?.value,
        password: this.password?.value,
        captcha: '0000'
      }
      this.service.signUp(signInForm)
        .subscribe(res => {
          if (res) {
            this.snb.open('登录成功');
            this.router.navigateByUrl('/home');
          }
        }, (error: any) => {
          this.snb.open(error.detail);
        });
    }

  }

  logout(): void {

  }

  get userName(): string | null {
    return '';
  }

}
