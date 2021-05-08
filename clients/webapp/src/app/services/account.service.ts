import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { AccountAddDto } from '../share/models/account-add-dto.model';
import { AccountFilter } from '../share/models/account-filter.model';
import { AccountUpdateDto } from '../share/models/account-update-dto.model';
import { SignInForm } from '../share/models/sign-in-form.model';
import { Account } from '../share/models/account.model';
import { PageResultOfAccountDto } from '../share/models/page-result-of-account-dto.model';
import { SignInDto } from '../share/models/sign-in-dto.model';

/**
 * 用户账号
 */
@Injectable({ providedIn: 'root' })
export class AccountService extends BaseService {

  /**
   * 注册账号
   * @param data AccountAddDto
   */
  add(data: AccountAddDto): Observable<Account> {
    const url = `/api/Account`;
    return this.request<Account>('post', url, data);
  }

  /**
   * 分页筛选Account
   * @param data AccountFilter
   */
  filter(data: AccountFilter): Observable<PageResultOfAccountDto> {
    const url = `/api/Account/filter`;
    return this.request<PageResultOfAccountDto>('post', url, data);
  }

  /**
   * 更新Account
   * @param id string
   * @param data AccountUpdateDto
   */
  update(id: string, data: AccountUpdateDto): Observable<Account> {
    const url = `/api/Account/${id}`;
    return this.request<Account>('put', url, data);
  }

  /**
   * 删除
   * @param id string
   */
  delete(id: string): Observable<Account> {
    const url = `/api/Account/${id}`;
    return this.request<Account>('delete', url);
  }

  /**
   * 获取详情
   * @param id string
   */
  getDetail(id: string): Observable<Account> {
    const url = `/api/Account/${id}`;
    return this.request<Account>('get', url);
  }

  /**
   * 登录
   * @param data SignInForm
   */
  signUp(data: SignInForm): Observable<SignInDto> {
    const url = `/api/Account/signIn`;
    return this.request<SignInDto>('post', url, data);
  }

  /**
   * 初始化管理员账号
   * @param username string
   * @param password string
   */
  initAdminUser(username: string, password: string): Observable<Account> {
    const url = `/api/Account/initAdminUser?username=${username}&password=${password}`;
    return this.request<Account>('post', url);
  }



}
