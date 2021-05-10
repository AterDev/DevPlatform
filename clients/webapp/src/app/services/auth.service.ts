import { Injectable } from '@angular/core';
import { SignInDto } from '../share/models/sign-in-dto.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  isLogin = false;
  username = '';
  redirectUrl = '/home';
  constructor() {
    this.updateUserLoginState();
  }

  saveUserInfo(data: SignInDto): void {
    localStorage.setItem('username', data.username ?? '');
    localStorage.setItem('id', data.id ?? '');
    localStorage.setItem('token', data.token ?? '');
    localStorage.setItem('role', data.roleName ?? '');
    if (data.id && data.token && data.username) {
      this.isLogin = true;
      this.username = data.username ?? '';
    } else {
      this.isLogin = false;
    }
  }
  /**
   * 更新用户状态
   */
  updateUserLoginState(): void {
    const userId = localStorage.getItem('id');
    const username = localStorage.getItem('username');
    const token = localStorage.getItem('token');
    if (userId && token && username) {
      this.isLogin = true;
      this.username = username ?? '';
    } else {
      this.isLogin = false;
    }
  }
  // 登出
  logout(): void {
    localStorage.clear();
    this.updateUserLoginState();
  }
}
