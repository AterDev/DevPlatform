import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { LibraryCatalogUpdateDto } from '../models/library-catalog/library-catalog-update-dto.model';
import { LibraryCatalogFilter } from '../models/library-catalog/library-catalog-filter.model';
import { LibraryCatalog } from '../models/library-catalog/library-catalog.model';
import { BatchUpdateOfLibraryCatalogUpdateDto } from '../models/library-catalog/batch-update-of-library-catalog-update-dto.model';
import { PageResultOfLibraryCatalogItemDto } from '../models/library-catalog/page-result-of-library-catalog-item-dto.model';

/**
 * 目录/文件目录 / 自引用
 */
@Injectable({ providedIn: 'root' })
export class LibraryCatalogService extends BaseService {
  /**
   * 关联添加
   * @param id 所属对象id
   * @param data []
   */
  add(id: string, data: []): Observable<number> {
    const url = `/api/LibraryCatalog/${id}`;
    return this.request<number>('post', url, data);
  }

  /**
   * ⚠更新
   * @param id string
   * @param data LibraryCatalogUpdateDto
   */
  update(id: string, data: LibraryCatalogUpdateDto): Observable<LibraryCatalog> {
    const url = `/api/LibraryCatalog/${id}`;
    return this.request<LibraryCatalog>('put', url, data);
  }

  /**
   * ⚠删除
   * @param id string
   */
  delete(id: string): Observable<boolean> {
    const url = `/api/LibraryCatalog/${id}`;
    return this.request<boolean>('delete', url);
  }

  /**
   * 详情
   * @param id string
   */
  getDetail(id: string): Observable<LibraryCatalog> {
    const url = `/api/LibraryCatalog/${id}`;
    return this.request<LibraryCatalog>('get', url);
  }

  /**
   * 分页筛选
   * @param data LibraryCatalogFilter
   */
  filter(data: LibraryCatalogFilter): Observable<PageResultOfLibraryCatalogItemDto> {
    const url = `/api/LibraryCatalog/filter`;
    return this.request<PageResultOfLibraryCatalogItemDto>('post', url, data);
  }

  /**
   * 添加
   * @param data LibraryCatalog
   */
  add2(data: LibraryCatalog): Observable<LibraryCatalog> {
    const url = `/api/LibraryCatalog`;
    return this.request<LibraryCatalog>('post', url, data);
  }

  /**
   * ⚠ 批量删除
   * @param data string[]
   */
  batchDelete(data: string[]): Observable<number> {
    const url = `/api/LibraryCatalog`;
    return this.request<number>('delete', url, data);
  }

  /**
   * 批量更新
   * @param data BatchUpdateOfLibraryCatalogUpdateDto
   */
  batchUpdate(data: BatchUpdateOfLibraryCatalogUpdateDto): Observable<number> {
    const url = `/api/LibraryCatalog`;
    return this.request<number>('put', url, data);
  }

}
