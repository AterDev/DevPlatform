import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AuthService } from 'src/app/share/services/auth.service';
import { UserService } from 'src/app/share/services/user.service';
import { UserLogin } from 'src/app/share/models/user/user-login.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public loginForm!: FormGroup;

  constructor(
    private router: Router,
    private authService: AuthService,
    private userService: UserService,
    private snb: MatSnackBar
  ) {
  }
  get username() { return this.loginForm.get('username'); }
  get password() { return this.loginForm.get('password'); }

  ngOnInit(): void {
    // 表单验证
    this.loginForm = new FormGroup({
      username: new FormControl('', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]),
      password: new FormControl('', [Validators.required, Validators.minLength(6), Validators.maxLength(50)]),
    });
  }
  /**
   * 错误信息
   * @param type 字段名称
   */
  getValidatorMessage(type: string): string {
    switch (type) {
      case 'username':
        return this.username?.errors?.['required'] ? '用户名必填' :
          this.username?.errors?.['minlength'] ? '最少4位' :
            this.username?.errors?.['minlength'] ? '长度不可超过50位' : '';
      case 'password':
        return this.password?.errors?.['required'] ? '密码必填' :
          this.password?.errors?.['minlength'] ? '密码长度不可低于6位' :
            this.password?.errors?.['maxlength'] ? '密码长度不可超过50' : '';
      default:
        break;
    }
    return '';
  }

  doLogin(): void {
    if (this.loginForm.valid) {
      const data = this.loginForm.value as UserLogin;
      this.userService.login(data)
        .subscribe(res => {
          this.authService.saveUserLoginState(res);
          // 登录成功
          this.snb.open('登录成功');
          this.router.navigateByUrl('/docs');
        }, error => {
          this.snb.open(error.detail);
        });

    } else {
      // this.snb.open('');
    }
  }
}
