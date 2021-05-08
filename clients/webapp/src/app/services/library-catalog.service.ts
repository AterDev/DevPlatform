import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { LibraryCatalogAddDto } from '../share/models/library-catalog-add-dto.model';
import { LibraryCatalogFilter } from '../share/models/library-catalog-filter.model';
import { LibraryCatalogUpdateDto } from '../share/models/library-catalog-update-dto.model';
import { LibraryCatalog } from '../share/models/library-catalog.model';
import { PageResultOfLibraryCatalogDto } from '../share/models/page-result-of-library-catalog-dto.model';

/**
 * LibraryCatalog
 */
@Injectable({ providedIn: 'root' })
export class LibraryCatalogService extends BaseService {

  /**
   * 添加LibraryCatalog
   * @param data LibraryCatalogAddDto
   */
  add(data: LibraryCatalogAddDto): Observable<LibraryCatalog> {
    const url = `/api/LibraryCatalog`;
    return this.request<LibraryCatalog>('post', url, data);
  }

  /**
   * 分页筛选LibraryCatalog
   * @param data LibraryCatalogFilter
   */
  filter(data: LibraryCatalogFilter): Observable<PageResultOfLibraryCatalogDto> {
    const url = `/api/LibraryCatalog/filter`;
    return this.request<PageResultOfLibraryCatalogDto>('post', url, data);
  }

  /**
   * 更新LibraryCatalog
   * @param id string
   * @param data LibraryCatalogUpdateDto
   */
  update(id: string, data: LibraryCatalogUpdateDto): Observable<LibraryCatalog> {
    const url = `/api/LibraryCatalog/${id}`;
    return this.request<LibraryCatalog>('put', url, data);
  }

  /**
   * 删除LibraryCatalog
   * @param id string
   */
  delete(id: string): Observable<LibraryCatalog> {
    const url = `/api/LibraryCatalog/${id}`;
    return this.request<LibraryCatalog>('delete', url);
  }

  /**
   * 获取LibraryCatalog详情
   * @param id string
   */
  getDetail(id: string): Observable<LibraryCatalog> {
    const url = `/api/LibraryCatalog/${id}`;
    return this.request<LibraryCatalog>('get', url);
  }



}
