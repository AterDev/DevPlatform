import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { ArticleCatalogUpdateDto } from '../models/article-catalog/article-catalog-update-dto.model';
import { ArticleCatalogFilter } from '../models/article-catalog/article-catalog-filter.model';
import { ArticleCatalog } from '../models/article-catalog/article-catalog.model';
import { BatchUpdateOfArticleCatalogUpdateDto } from '../models/article-catalog/batch-update-of-article-catalog-update-dto.model';
import { PageResultOfArticleCatalogItemDto } from '../models/article-catalog/page-result-of-article-catalog-item-dto.model';

/**
 * ArticleCatalog
 */
@Injectable({ providedIn: 'root' })
export class ArticleCatalogService extends BaseService {
  /**
   * 关联添加
   * @param id 所属对象id
   * @param data []
   */
  add(id: string, data: []): Observable<number> {
    const url = `/api/ArticleCatalog/${id}`;
    return this.request<number>('post', url, data);
  }

  /**
   * ⚠更新
   * @param id string
   * @param data ArticleCatalogUpdateDto
   */
  update(id: string, data: ArticleCatalogUpdateDto): Observable<ArticleCatalog> {
    const url = `/api/ArticleCatalog/${id}`;
    return this.request<ArticleCatalog>('put', url, data);
  }

  /**
   * ⚠删除
   * @param id string
   */
  delete(id: string): Observable<boolean> {
    const url = `/api/ArticleCatalog/${id}`;
    return this.request<boolean>('delete', url);
  }

  /**
   * 详情
   * @param id string
   */
  getDetail(id: string): Observable<ArticleCatalog> {
    const url = `/api/ArticleCatalog/${id}`;
    return this.request<ArticleCatalog>('get', url);
  }

  /**
   * 分页筛选
   * @param data ArticleCatalogFilter
   */
  filter(data: ArticleCatalogFilter): Observable<PageResultOfArticleCatalogItemDto> {
    const url = `/api/ArticleCatalog/filter`;
    return this.request<PageResultOfArticleCatalogItemDto>('post', url, data);
  }

  /**
   * 添加
   * @param data ArticleCatalog
   */
  add2(data: ArticleCatalog): Observable<ArticleCatalog> {
    const url = `/api/ArticleCatalog`;
    return this.request<ArticleCatalog>('post', url, data);
  }

  /**
   * ⚠ 批量删除
   * @param data string[]
   */
  batchDelete(data: string[]): Observable<number> {
    const url = `/api/ArticleCatalog`;
    return this.request<number>('delete', url, data);
  }

  /**
   * 批量更新
   * @param data BatchUpdateOfArticleCatalogUpdateDto
   */
  batchUpdate(data: BatchUpdateOfArticleCatalogUpdateDto): Observable<number> {
    const url = `/api/ArticleCatalog`;
    return this.request<number>('put', url, data);
  }

}
