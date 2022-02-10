import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { ArticleUpdateDto } from '../models/article/article-update-dto.model';
import { ArticleFilter } from '../models/article/article-filter.model';
import { Article } from '../models/article/article.model';
import { BatchUpdateOfArticleUpdateDto } from '../models/article/batch-update-of-article-update-dto.model';
import { PageResultOfArticleItemDto } from '../models/article/page-result-of-article-item-dto.model';

/**
 * 文章内容
 */
@Injectable({ providedIn: 'root' })
export class ArticleService extends BaseService {
  /**
   * 关联添加
   * @param id 所属对象id
   * @param data []
   */
  addIn(id: string, data: []): Observable<number> {
    const url = `/api/Article/${id}`;
    return this.request<number>('post', url, data);
  }

  /**
   * ⚠更新
   * @param id string
   * @param data ArticleUpdateDto
   */
  update(id: string, data: ArticleUpdateDto): Observable<Article> {
    const url = `/api/Article/${id}`;
    return this.request<Article>('put', url, data);
  }

  /**
   * ⚠删除
   * @param id string
   */
  delete(id: string): Observable<boolean> {
    const url = `/api/Article/${id}`;
    return this.request<boolean>('delete', url);
  }

  /**
   * 详情
   * @param id string
   */
  getDetail(id: string): Observable<Article> {
    const url = `/api/Article/${id}`;
    return this.request<Article>('get', url);
  }

  /**
   * 分页筛选
   * @param data ArticleFilter
   */
  filter(data: ArticleFilter): Observable<PageResultOfArticleItemDto> {
    const url = `/api/Article/filter`;
    return this.request<PageResultOfArticleItemDto>('post', url, data);
  }

  /**
   * 添加
   * @param data Article
   */
  add(data: Article): Observable<Article> {
    const url = `/api/Article`;
    return this.request<Article>('post', url, data);
  }

  /**
   * ⚠ 批量删除
   * @param data string[]
   */
  batchDelete(data: string[]): Observable<number> {
    const url = `/api/Article`;
    return this.request<number>('delete', url, data);
  }

  /**
   * 批量更新
   * @param data BatchUpdateOfArticleUpdateDto
   */
  batchUpdate(data: BatchUpdateOfArticleUpdateDto): Observable<number> {
    const url = `/api/Article`;
    return this.request<number>('put', url, data);
  }

}
