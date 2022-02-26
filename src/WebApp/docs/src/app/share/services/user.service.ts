import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { UserLogin } from '../models/user/user-login.model';
import { UserFilter } from '../models/user/user-filter.model';
import { User } from '../models/user/user.model';
import { BatchUpdateOfUserUpdateDto } from '../models/user/batch-update-of-user-update-dto.model';
import { UserUpdateDto } from '../models/user/user-update-dto.model';
import { LoginResult } from '../models/login-result/login-result.model';
import { PageResultOfUserItemDto } from '../models/user/page-result-of-user-item-dto.model';

/**
 * 用户
 */
@Injectable({ providedIn: 'root' })
export class UserService extends BaseService {
  /**
   * 登录
   * @param data UserLogin
   */
  login(data: UserLogin): Observable<LoginResult> {
    const url = `/api/User/login`;
    return this.request<LoginResult>('post', url, data);
  }

  /**
   * 分页筛选
   * @param data UserFilter
   */
  filter(data: UserFilter): Observable<PageResultOfUserItemDto> {
    const url = `/api/User/filter`;
    return this.request<PageResultOfUserItemDto>('post', url, data);
  }

  /**
   * 添加
   * @param data User
   */
  add(data: User): Observable<User> {
    const url = `/api/User`;
    return this.request<User>('post', url, data);
  }

  /**
   * ⚠ 批量删除
   * @param data string[]
   */
  batchDelete(data: string[]): Observable<number> {
    const url = `/api/User`;
    return this.request<number>('delete', url, data);
  }

  /**
   * 批量更新
   * @param data BatchUpdateOfUserUpdateDto
   */
  batchUpdate(data: BatchUpdateOfUserUpdateDto): Observable<number> {
    const url = `/api/User`;
    return this.request<number>('put', url, data);
  }

  /**
   * ⚠更新
   * @param id string
   * @param data UserUpdateDto
   */
  update(id: string, data: UserUpdateDto): Observable<User> {
    const url = `/api/User/${id}`;
    return this.request<User>('put', url, data);
  }

  /**
   * ⚠删除
   * @param id string
   */
  delete(id: string): Observable<boolean> {
    const url = `/api/User/${id}`;
    return this.request<boolean>('delete', url);
  }

  /**
   * 详情
   * @param id string
   */
  getDetail(id: string): Observable<User> {
    const url = `/api/User/${id}`;
    return this.request<User>('get', url);
  }

}
