import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { RoleFilter } from '../models/role/role-filter.model';
import { Role } from '../models/role/role.model';
import { RoleUpdateDto } from '../models/role/role-update-dto.model';
import { PageResultOfRoleItemDto } from '../models/role/page-result-of-role-item-dto.model';

/**
 * 角色表
 */
@Injectable({ providedIn: 'root' })
export class RoleService extends BaseService {
  /**
   * 分页筛选
   * @param data RoleFilter
   */
  filter(data: RoleFilter): Observable<PageResultOfRoleItemDto> {
    const url = `/api/Role`;
    return this.request<PageResultOfRoleItemDto>('get', url, data);
  }

  /**
   * 添加
   * @param data Role
   */
  add(data: Role): Observable<Role> {
    const url = `/api/Role`;
    return this.request<Role>('post', url, data);
  }

  /**
   * ⚠ 批量删除
   * @param ids string[]
   */
  batchDelete(ids: string[]): Observable<number> {
    const url = `/api/Role`;
    return this.request<number>('delete', url);
  }

  /**
   * ⚠更新
   * @param id string
   * @param data RoleUpdateDto
   */
  update(id: string, data: RoleUpdateDto): Observable<Role> {
    const url = `/api/Role/${id}`;
    return this.request<Role>('put', url, data);
  }

  /**
   * ⚠删除
   * @param id string
   */
  delete(id: string): Observable<boolean> {
    const url = `/api/Role/${id}`;
    return this.request<boolean>('delete', url);
  }

  /**
   * getDetail
   * @param id string
   */
  getDetail(id: string): Observable<Role> {
    const url = `/api/Role/${id}`;
    return this.request<Role>('get', url);
  }

}
