import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { ArticleAddDto } from '../share/models/article-add-dto.model';
import { ArticleFilter } from '../share/models/article-filter.model';
import { ArticleUpdateDto } from '../share/models/article-update-dto.model';
import { Article } from '../share/models/article.model';
import { PageResultOfArticleDto } from '../share/models/page-result-of-article-dto.model';

/**
 * 文章
 */
@Injectable({ providedIn: 'root' })
export class ArticleService extends BaseService {

  /**
   * 添加Article
   * @param data ArticleAddDto
   */
  add(data: ArticleAddDto): Observable<Article> {
    const url = `/api/Article`;
    return this.request<Article>('post', url, data);
  }

  /**
   * 分页筛选Article
   * @param data ArticleFilter
   */
  filter(data: ArticleFilter): Observable<PageResultOfArticleDto> {
    const url = `/api/Article/filter`;
    return this.request<PageResultOfArticleDto>('post', url, data);
  }

  /**
   * 更新Article
   * @param id string
   * @param data ArticleUpdateDto
   */
  update(id: string, data: ArticleUpdateDto): Observable<Article> {
    const url = `/api/Article/${id}`;
    return this.request<Article>('put', url, data);
  }

  /**
   * 删除Article
   * @param id string
   */
  delete(id: string): Observable<Article> {
    const url = `/api/Article/${id}`;
    return this.request<Article>('delete', url);
  }

  /**
   * 获取Article详情
   * @param id string
   */
  getDetail(id: string): Observable<Article> {
    const url = `/api/Article/${id}`;
    return this.request<Article>('get', url);
  }



}
