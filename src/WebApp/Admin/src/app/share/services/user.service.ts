import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { User } from '../models/user/user.model';
import { UserUpdateDto } from '../models/user/user-update-dto.model';
import { PageResultOfUserItemDto } from '../models/user/page-result-of-user-item-dto.model';
import { Status } from '../models/user/status.model';

/**
 * 账号表
 */
@Injectable({ providedIn: 'root' })
export class UserService extends BaseService {
  /**
   * 分页筛选
   * @param UserName string
   * @param Email string
   * @param EmailConfirmed boolean
   * @param ConcurrencyStamp A random value that must change whenever a user is persisted to the store
   * @param PhoneNumberConfirmed boolean
   * @param TwoFactorEnabled boolean
   * @param LockoutEnabled boolean
   * @param AccessFailedCount number
   * @param IsDeleted 软删除
   * @param RetryCount 密码重试次数
   * @param Status Status
   * @param ExtendId string
   * @param PageIndex number
   * @param PageSize number
   * @param TenantId string
   * @param MinCreatedTime string
   * @param MaxCreatedTime string
   */
  filter(UserName: string, Email: string, EmailConfirmed: boolean, ConcurrencyStamp: string, PhoneNumberConfirmed: boolean, TwoFactorEnabled: boolean, LockoutEnabled: boolean, AccessFailedCount: number, IsDeleted: boolean, RetryCount: number, Status: Status, ExtendId: string, PageIndex: number, PageSize: number, TenantId: string, MinCreatedTime: string, MaxCreatedTime: string): Observable<PageResultOfUserItemDto> {
    const url = `/api/User?UserName=${UserName}&Email=${Email}&EmailConfirmed=${EmailConfirmed}&ConcurrencyStamp=${ConcurrencyStamp}&PhoneNumberConfirmed=${PhoneNumberConfirmed}&TwoFactorEnabled=${TwoFactorEnabled}&LockoutEnabled=${LockoutEnabled}&AccessFailedCount=${AccessFailedCount}&IsDeleted=${IsDeleted}&RetryCount=${RetryCount}&Status=${Status}&ExtendId=${ExtendId}&PageIndex=${PageIndex}&PageSize=${PageSize}&TenantId=${TenantId}&MinCreatedTime=${MinCreatedTime}&MaxCreatedTime=${MaxCreatedTime}`;
    return this.request<PageResultOfUserItemDto>('get', url);
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
   * @param ids string[]
   */
  batchDelete(ids: string[]): Observable<number> {
    const url = `/api/User`;
    return this.request<number>('delete', url);
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
   * getDetail
   * @param id string
   */
  getDetail(id: string): Observable<User> {
    const url = `/api/User/${id}`;
    return this.request<User>('get', url);
  }

}
