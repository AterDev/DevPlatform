import { Injectable } from '@angular/core';
import { LoginResult } from '../models/login-result/login-result.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  isLogin = false;
  username = '';
  redirectUrl = '/index';
  constructor() {
    this.updateUserLoginState();
  }

  saveUserLoginState(userInfo: LoginResult): void {
    if (userInfo.token && userInfo.id && userInfo.userName) {
      this.isLogin = true;
      this.username = userInfo.userName;
      localStorage.setItem('id', userInfo.id);
      localStorage.setItem('username', userInfo.userName);
      localStorage.setItem('token', userInfo.token);
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
      this.username = username;
      this.isLogin = true;
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
