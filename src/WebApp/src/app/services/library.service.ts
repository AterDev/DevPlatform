import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { LibraryAddDto } from '../share/models/library-add-dto.model';
import { LibraryFilter } from '../share/models/library-filter.model';
import { LibraryUpdateDto } from '../share/models/library-update-dto.model';
import { Library } from '../share/models/library.model';
import { PageResultOfLibraryDto } from '../share/models/page-result-of-library-dto.model';

/**
 * Library
 */
@Injectable({ providedIn: 'root' })
export class LibraryService extends BaseService {

  /**
   * 添加Library
   * @param data LibraryAddDto
   */
  add(data: LibraryAddDto): Observable<Library> {
    const url = `/api/Library`;
    return this.request<Library>('post', url, data);
  }

  /**
   * 分页筛选Library
   * @param data LibraryFilter
   */
  filter(data: LibraryFilter): Observable<PageResultOfLibraryDto> {
    const url = `/api/Library/filter`;
    return this.request<PageResultOfLibraryDto>('post', url, data);
  }

  /**
   * 更新Library
   * @param id string
   * @param data LibraryUpdateDto
   */
  update(id: string, data: LibraryUpdateDto): Observable<Library> {
    const url = `/api/Library/${id}`;
    return this.request<Library>('put', url, data);
  }

  /**
   * delete
   * @param id string
   */
  delete(id: string): Observable<Library> {
    const url = `/api/Library/${id}`;
    return this.request<Library>('delete', url);
  }

  /**
   * getDetail
   * @param id string
   */
  getDetail(id: string): Observable<Library> {
    const url = `/api/Library/${id}`;
    return this.request<Library>('get', url);
  }



}
