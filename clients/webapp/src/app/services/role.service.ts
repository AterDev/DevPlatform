import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { RoleAddDto } from '../share/models/role-add-dto.model';
import { RoleFilter } from '../share/models/role-filter.model';
import { RoleUpdateDto } from '../share/models/role-update-dto.model';
import { Role } from '../share/models/role.model';
import { PageResultOfRoleDto } from '../share/models/page-result-of-role-dto.model';

/**
 * 角色
 */
@Injectable({ providedIn: 'root' })
export class RoleService extends BaseService {

  /**
   * 添加Role
   * @param data RoleAddDto
   */
  add(data: RoleAddDto): Observable<Role> {
    const url = `/api/Role`;
    return this.request<Role>('post', url, data);
  }

  /**
   * 分页筛选Role
   * @param data RoleFilter
   */
  filter(data: RoleFilter): Observable<PageResultOfRoleDto> {
    const url = `/api/Role/filter`;
    return this.request<PageResultOfRoleDto>('post', url, data);
  }

  /**
   * 更新Role
   * @param id string
   * @param data RoleUpdateDto
   */
  update(id: string, data: RoleUpdateDto): Observable<Role> {
    const url = `/api/Role/${id}`;
    return this.request<Role>('put', url, data);
  }

  /**
   * delete
   * @param id string
   */
  delete(id: string): Observable<Role> {
    const url = `/api/Role/${id}`;
    return this.request<Role>('delete', url);
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
