import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { TagLibraryFilter } from '../models/tag-library/tag-library-filter.model';
import { TagLibrary } from '../models/tag-library/tag-library.model';
import { BatchUpdateOfTagLibraryUpdateDto } from '../models/tag-library/batch-update-of-tag-library-update-dto.model';
import { TagLibraryUpdateDto } from '../models/tag-library/tag-library-update-dto.model';
import { PageResultOfTagLibraryItemDto } from '../models/tag-library/page-result-of-tag-library-item-dto.model';

/**
 * 标签库
 */
@Injectable({ providedIn: 'root' })
export class TagLibraryService extends BaseService {
  /**
   * 分页筛选
   * @param data TagLibraryFilter
   */
  filter(data: TagLibraryFilter): Observable<PageResultOfTagLibraryItemDto> {
    const url = `/api/TagLibrary/filter`;
    return this.request<PageResultOfTagLibraryItemDto>('post', url, data);
  }

  /**
   * 添加
   * @param data TagLibrary
   */
  add(data: TagLibrary): Observable<TagLibrary> {
    const url = `/api/TagLibrary`;
    return this.request<TagLibrary>('post', url, data);
  }

  /**
   * ⚠ 批量删除
   * @param data string[]
   */
  batchDelete(data: string[]): Observable<number> {
    const url = `/api/TagLibrary`;
    return this.request<number>('delete', url, data);
  }

  /**
   * 批量更新
   * @param data BatchUpdateOfTagLibraryUpdateDto
   */
  batchUpdate(data: BatchUpdateOfTagLibraryUpdateDto): Observable<number> {
    const url = `/api/TagLibrary`;
    return this.request<number>('put', url, data);
  }

  /**
   * ⚠更新
   * @param id string
   * @param data TagLibraryUpdateDto
   */
  update(id: string, data: TagLibraryUpdateDto): Observable<TagLibrary> {
    const url = `/api/TagLibrary/${id}`;
    return this.request<TagLibrary>('put', url, data);
  }

  /**
   * ⚠删除
   * @param id string
   */
  delete(id: string): Observable<boolean> {
    const url = `/api/TagLibrary/${id}`;
    return this.request<boolean>('delete', url);
  }

  /**
   * 详情
   * @param id string
   */
  getDetail(id: string): Observable<TagLibrary> {
    const url = `/api/TagLibrary/${id}`;
    return this.request<TagLibrary>('get', url);
  }

}
