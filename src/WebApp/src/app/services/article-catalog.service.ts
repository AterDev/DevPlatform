import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { ArticleCatalogAddDto } from '../share/models/article-catalog-add-dto.model';
import { ArticleCatalogFilter } from '../share/models/article-catalog-filter.model';
import { ArticleCatalogUpdateDto } from '../share/models/article-catalog-update-dto.model';
import { ArticleCatalog } from '../share/models/article-catalog.model';
import { PageResultOfArticleCatalogDto } from '../share/models/page-result-of-article-catalog-dto.model';

/**
 * 文章目录
 */
@Injectable({ providedIn: 'root' })
export class ArticleCatalogService extends BaseService {

  /**
   * 添加ArticleCatalog
   * @param data ArticleCatalogAddDto
   */
  add(data: ArticleCatalogAddDto): Observable<ArticleCatalog> {
    const url = `/api/ArticleCatalog`;
    return this.request<ArticleCatalog>('post', url, data);
  }

  /**
   * 分页筛选ArticleCatalog
   * @param data ArticleCatalogFilter
   */
  filter(data: ArticleCatalogFilter): Observable<PageResultOfArticleCatalogDto> {
    const url = `/api/ArticleCatalog/filter`;
    return this.request<PageResultOfArticleCatalogDto>('post', url, data);
  }

  /**
   * 更新ArticleCatalog
   * @param id string
   * @param data ArticleCatalogUpdateDto
   */
  update(id: string, data: ArticleCatalogUpdateDto): Observable<ArticleCatalog> {
    const url = `/api/ArticleCatalog/${id}`;
    return this.request<ArticleCatalog>('put', url, data);
  }

  /**
   * 删除ArticleCatalog
   * @param id string
   */
  delete(id: string): Observable<ArticleCatalog> {
    const url = `/api/ArticleCatalog/${id}`;
    return this.request<ArticleCatalog>('delete', url);
  }

  /**
   * 获取ArticleCatalog详情
   * @param id string
   */
  getDetail(id: string): Observable<ArticleCatalog> {
    const url = `/api/ArticleCatalog/${id}`;
    return this.request<ArticleCatalog>('get', url);
  }



}
