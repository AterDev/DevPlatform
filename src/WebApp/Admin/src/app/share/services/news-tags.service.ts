import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { NewsTagsUpdateDto } from '../models/news-tags/news-tags-update-dto.model';
import { NewsTagsFilter } from '../models/news-tags/news-tags-filter.model';
import { NewsTags } from '../models/news-tags/news-tags.model';
import { BatchUpdateOfNewsTagsUpdateDto } from '../models/news-tags/batch-update-of-news-tags-update-dto.model';
import { PageResultOfNewsTagsItemDto } from '../models/news-tags/page-result-of-news-tags-item-dto.model';

/**
 * 新闻标签
 */
@Injectable({ providedIn: 'root' })
export class NewsTagsService extends BaseService {
  /**
   * 关联添加
   * @param id 所属对象id
   * @param data []
   */
  add(id: string, data: []): Observable<number> {
    const url = `/api/NewsTags/${id}`;
    return this.request<number>('post', url, data);
  }

  /**
   * ⚠更新
   * @param id string
   * @param data NewsTagsUpdateDto
   */
  update(id: string, data: NewsTagsUpdateDto): Observable<NewsTags> {
    const url = `/api/NewsTags/${id}`;
    return this.request<NewsTags>('put', url, data);
  }

  /**
   * ⚠删除
   * @param id string
   */
  delete(id: string): Observable<boolean> {
    const url = `/api/NewsTags/${id}`;
    return this.request<boolean>('delete', url);
  }

  /**
   * 详情
   * @param id string
   */
  getDetail(id: string): Observable<NewsTags> {
    const url = `/api/NewsTags/${id}`;
    return this.request<NewsTags>('get', url);
  }

  /**
   * 分页筛选
   * @param data NewsTagsFilter
   */
  filter(data: NewsTagsFilter): Observable<PageResultOfNewsTagsItemDto> {
    const url = `/api/NewsTags/filter`;
    return this.request<PageResultOfNewsTagsItemDto>('post', url, data);
  }

  /**
   * 添加
   * @param data NewsTags
   */
  add2(data: NewsTags): Observable<NewsTags> {
    const url = `/api/NewsTags`;
    return this.request<NewsTags>('post', url, data);
  }

  /**
   * ⚠ 批量删除
   * @param data string[]
   */
  batchDelete(data: string[]): Observable<number> {
    const url = `/api/NewsTags`;
    return this.request<number>('delete', url, data);
  }

  /**
   * 批量更新
   * @param data BatchUpdateOfNewsTagsUpdateDto
   */
  batchUpdate(data: BatchUpdateOfNewsTagsUpdateDto): Observable<number> {
    const url = `/api/NewsTags`;
    return this.request<number>('put', url, data);
  }

}
