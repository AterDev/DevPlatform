import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  isLogin = false;
  redirectUrl = '/home';
  constructor() {
    this.updateUserLoginState();
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
