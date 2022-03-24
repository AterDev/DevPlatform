import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { ThirdNewsFilter } from '../models/third-news/third-news-filter.model';
import { ThirdNews } from '../models/third-news/third-news.model';
import { BatchUpdateOfThirdNewsUpdateDto } from '../models/third-news/batch-update-of-third-news-update-dto.model';
import { ThirdNewsUpdateDto } from '../models/third-news/third-news-update-dto.model';
import { PageResultOfThirdNewsItemDto } from '../models/third-news/page-result-of-third-news-item-dto.model';

/**
 * ThirdNews
 */
@Injectable({ providedIn: 'root' })
export class ThirdNewsService extends BaseService {
  /**
   * 分页筛选
   * @param data ThirdNewsFilter
   */
  filter(data: ThirdNewsFilter): Observable<PageResultOfThirdNewsItemDto> {
    const url = `/api/ThirdNews/filter`;
    return this.request<PageResultOfThirdNewsItemDto>('post', url, data);
  }

  /**
   * getWeekNews
   */
  getWeekNews(): Observable<[]> {
    const url = `/api/ThirdNews/week`;
    return this.request<[]>('get', url);
  }

  /**
   * 添加
   * @param data ThirdNews
   */
  add(data: ThirdNews): Observable<ThirdNews> {
    const url = `/api/ThirdNews`;
    return this.request<ThirdNews>('post', url, data);
  }

  /**
   * ⚠ 批量删除
   * @param data string[]
   */
  batchDelete(data: string[]): Observable<number> {
    const url = `/api/ThirdNews`;
    return this.request<number>('delete', url, data);
  }

  /**
   * 批量更新
   * @param data BatchUpdateOfThirdNewsUpdateDto
   */
  batchUpdate(data: BatchUpdateOfThirdNewsUpdateDto): Observable<number> {
    const url = `/api/ThirdNews`;
    return this.request<number>('put', url, data);
  }

  /**
   * ⚠更新
   * @param id string
   * @param data ThirdNewsUpdateDto
   */
  update(id: string, data: ThirdNewsUpdateDto): Observable<ThirdNews> {
    const url = `/api/ThirdNews/${id}`;
    return this.request<ThirdNews>('put', url, data);
  }

  /**
   * ⚠删除
   * @param id string
   */
  delete(id: string): Observable<boolean> {
    const url = `/api/ThirdNews/${id}`;
    return this.request<boolean>('delete', url);
  }

  /**
   * 详情
   * @param id string
   */
  getDetail(id: string): Observable<ThirdNews> {
    const url = `/api/ThirdNews/${id}`;
    return this.request<ThirdNews>('get', url);
  }

}
