import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { WebConfigFilterDto } from '../models/web-config/web-config-filter-dto.model';
import { WebConfig } from '../models/web-config/web-config.model';
import { BatchUpdateOfWebConfigUpdateDto } from '../models/web-config/batch-update-of-web-config-update-dto.model';
import { WebConfigAddDto } from '../models/web-config/web-config-add-dto.model';
import { WebConfigUpdateDto } from '../models/web-config/web-config-update-dto.model';
import { PageResultOfWebConfigItemDto } from '../models/web-config/page-result-of-web-config-item-dto.model';
import { RepositoryItemDto } from '../models/repository/repository-item-dto.model';

/**
 * 网站配置
 */
@Injectable({ providedIn: 'root' })
export class WebConfigService extends BaseService {
  /**
   * 分页筛选
   * @param data WebConfigFilterDto
   */
  filter(data: WebConfigFilterDto): Observable<PageResultOfWebConfigItemDto> {
    const url = `/api/WebConfig/filter`;
    return this.request<PageResultOfWebConfigItemDto>('post', url, data);
  }

  /**
   * 添加
   * @param data WebConfig
   */
  add(data: WebConfig): Observable<WebConfig> {
    const url = `/api/WebConfig`;
    return this.request<WebConfig>('post', url, data);
  }

  /**
   * 同步文档
   */
  sync(): Observable<FormData> {
    const url = `/api/WebConfig`;
    return this.request<FormData>('get', url);
  }

  /**
   * ⚠ 批量删除
   * @param data string[]
   */
  batchDelete(data: string[]): Observable<number> {
    const url = `/api/WebConfig`;
    return this.request<number>('delete', url, data);
  }

  /**
   * 批量更新
   * @param data BatchUpdateOfWebConfigUpdateDto
   */
  batchUpdate(data: BatchUpdateOfWebConfigUpdateDto): Observable<number> {
    const url = `/api/WebConfig`;
    return this.request<number>('put', url, data);
  }

  /**
   * 网站配置
   * @param data WebConfigAddDto
   */
  save(data: WebConfigAddDto): Observable<WebConfig> {
    const url = `/api/WebConfig/save`;
    return this.request<WebConfig>('put', url, data);
  }

  /**
   * 获取仓库
   * @param pat string
   */
  getRepositories(pat: string): Observable<RepositoryItemDto[]> {
    const url = `/api/WebConfig/repositories?pat=${pat}`;
    return this.request<RepositoryItemDto[]>('get', url);
  }

  /**
   * ⚠更新
   * @param id string
   * @param data WebConfigUpdateDto
   */
  update(id: string, data: WebConfigUpdateDto): Observable<WebConfig> {
    const url = `/api/WebConfig/${id}`;
    return this.request<WebConfig>('put', url, data);
  }

  /**
   * ⚠删除
   * @param id string
   */
  delete(id: string): Observable<boolean> {
    const url = `/api/WebConfig/${id}`;
    return this.request<boolean>('delete', url);
  }

  /**
   * 详情
   * @param id string
   */
  getDetail(id: string): Observable<WebConfig> {
    const url = `/api/WebConfig/${id}`;
    return this.request<WebConfig>('get', url);
  }

}
