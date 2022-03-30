import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { ArticleExtendUpdateDto } from '../models/article-extend/article-extend-update-dto.model';
import { ArticleExtendFilter } from '../models/article-extend/article-extend-filter.model';
import { ArticleExtend } from '../models/article-extend/article-extend.model';
import { BatchUpdateOfArticleExtendUpdateDto } from '../models/article-extend/batch-update-of-article-extend-update-dto.model';
import { PageResultOfArticleExtendItemDto } from '../models/article-extend/page-result-of-article-extend-item-dto.model';

/**
 * 文章扩展
 */
@Injectable({ providedIn: 'root' })
export class ArticleExtendService extends BaseService {
  /**
   * 关联添加
   * @param id 所属对象id
   * @param data []
   */
  addIn(id: string, data: []): Observable<number> {
    const url = `/api/ArticleExtend/${id}`;
    return this.request<number>('post', url, data);
  }

  /**
   * ⚠更新
   * @param id string
   * @param data ArticleExtendUpdateDto
   */
  update(id: string, data: ArticleExtendUpdateDto): Observable<ArticleExtend> {
    const url = `/api/ArticleExtend/${id}`;
    return this.request<ArticleExtend>('put', url, data);
  }

  /**
   * ⚠删除
   * @param id string
   */
  delete(id: string): Observable<boolean> {
    const url = `/api/ArticleExtend/${id}`;
    return this.request<boolean>('delete', url);
  }

  /**
   * 详情
   * @param id string
   */
  getDetail(id: string): Observable<ArticleExtend> {
    const url = `/api/ArticleExtend/${id}`;
    return this.request<ArticleExtend>('get', url);
  }

  /**
   * 分页筛选
   * @param data ArticleExtendFilter
   */
  filter(data: ArticleExtendFilter): Observable<PageResultOfArticleExtendItemDto> {
    const url = `/api/ArticleExtend/filter`;
    return this.request<PageResultOfArticleExtendItemDto>('post', url, data);
  }

  /**
   * 添加
   * @param data ArticleExtend
   */
  add(data: ArticleExtend): Observable<ArticleExtend> {
    const url = `/api/ArticleExtend`;
    return this.request<ArticleExtend>('post', url, data);
  }

  /**
   * ⚠ 批量删除
   * @param data string[]
   */
  batchDelete(data: string[]): Observable<number> {
    const url = `/api/ArticleExtend`;
    return this.request<number>('delete', url, data);
  }

  /**
   * 批量更新
   * @param data BatchUpdateOfArticleExtendUpdateDto
   */
  batchUpdate(data: BatchUpdateOfArticleExtendUpdateDto): Observable<number> {
    const url = `/api/ArticleExtend`;
    return this.request<number>('put', url, data);
  }

}
