import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { LibraryUpdateDto } from '../models/library/library-update-dto.model';
import { LibraryFilter } from '../models/library/library-filter.model';
import { Library } from '../models/library/library.model';
import { BatchUpdateOfLibraryUpdateDto } from '../models/library/batch-update-of-library-update-dto.model';
import { PageResultOfLibraryItemDto } from '../models/library/page-result-of-library-item-dto.model';

/**
 * 模型库
 */
@Injectable({ providedIn: 'root' })
export class LibraryService extends BaseService {
  /**
   * 关联添加
   * @param id 所属对象id
   * @param data []
   */
  addIn(id: string, data: []): Observable<number> {
    const url = `/api/Library/${id}`;
    return this.request<number>('post', url, data);
  }

  /**
   * ⚠更新
   * @param id string
   * @param data LibraryUpdateDto
   */
  update(id: string, data: LibraryUpdateDto): Observable<Library> {
    const url = `/api/Library/${id}`;
    return this.request<Library>('put', url, data);
  }

  /**
   * ⚠删除
   * @param id string
   */
  delete(id: string): Observable<boolean> {
    const url = `/api/Library/${id}`;
    return this.request<boolean>('delete', url);
  }

  /**
   * 详情
   * @param id string
   */
  getDetail(id: string): Observable<Library> {
    const url = `/api/Library/${id}`;
    return this.request<Library>('get', url);
  }

  /**
   * 分页筛选
   * @param data LibraryFilter
   */
  filter(data: LibraryFilter): Observable<PageResultOfLibraryItemDto> {
    const url = `/api/Library/filter`;
    return this.request<PageResultOfLibraryItemDto>('post', url, data);
  }

  /**
   * 添加
   * @param data Library
   */
  add(data: Library): Observable<Library> {
    const url = `/api/Library`;
    return this.request<Library>('post', url, data);
  }

  /**
   * ⚠ 批量删除
   * @param data string[]
   */
  batchDelete(data: string[]): Observable<number> {
    const url = `/api/Library`;
    return this.request<number>('delete', url, data);
  }

  /**
   * 批量更新
   * @param data BatchUpdateOfLibraryUpdateDto
   */
  batchUpdate(data: BatchUpdateOfLibraryUpdateDto): Observable<number> {
    const url = `/api/Library`;
    return this.request<number>('put', url, data);
  }

}
