import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { OpenIddictApplicationDescriptor } from '../models/open-id-application/open-iddict-application-descriptor.model';
import { any } from '../models/open-id-application/any.model';

/**
 * OpenIdApplication
 */
@Injectable({ providedIn: 'root' })
export class OpenIdApplicationService extends BaseService {
  /**
   * getDetail
   * @param id string
   */
  getDetail(id: string): Observable<OpenIddictApplicationDescriptor> {
    const url = `/api/OpenIdApplication/${id}`;
    return this.request<OpenIddictApplicationDescriptor>('get', url);
  }

  /**
   * ⚠更新
   * @param id string
   * @param ClientId Gets or sets the client identifier associated with the application.
   * @param ClientSecret Gets or sets the client secret associated with the application.
Note: depending on the application manager used when creating it,
this property may be hashed or encrypted for security reasons.
   * @param ConsentType Gets or sets the consent type associated with the application.
   * @param DisplayName Gets or sets the display name associated with the application.
   * @param DisplayNames Gets the localized display names associated with the application.
   * @param Permissions Gets the permissions associated with the application.
   * @param PostLogoutRedirectUris Gets the logout callback URLs associated with the application.
   * @param Properties Gets the additional properties associated with the application.
   * @param RedirectUris Gets the callback URLs associated with the application.
   * @param Requirements Gets the requirements associated with the application.
   * @param Type Gets or sets the application type associated with the application.
   */
  update(ClientId: string, ClientSecret: string, ConsentType: string, DisplayName: string, DisplayNames: any, Permissions: string[], PostLogoutRedirectUris: string[], Properties: any, RedirectUris: string[], Requirements: string[], Type: string, id: string): Observable<OpenIddictApplicationDescriptor> {
    const url = `/api/OpenIdApplication/${id}?ClientId=${ClientId}&ClientSecret=${ClientSecret}&ConsentType=${ConsentType}&DisplayName=${DisplayName}&DisplayNames=${DisplayNames}&Permissions=${Permissions}&PostLogoutRedirectUris=${PostLogoutRedirectUris}&Properties=${Properties}&RedirectUris=${RedirectUris}&Requirements=${Requirements}&Type=${Type}`;
    return this.request<OpenIddictApplicationDescriptor>('put', url);
  }

  /**
   * ⚠删除
   * @param id string
   */
  delete(id: string): Observable<FormData> {
    const url = `/api/OpenIdApplication/${id}`;
    return this.request<FormData>('delete', url);
  }

  /**
   * 分页筛选
   * @param PageIndex number
   * @param PageSize number
   * @param TenantId string
   * @param MinCreatedTime string
   * @param MaxCreatedTime string
   */
  filter(PageIndex: number, PageSize: number, TenantId: string, MinCreatedTime: string, MaxCreatedTime: string): Observable<[]> {
    const url = `/api/OpenIdApplication?PageIndex=${PageIndex}&PageSize=${PageSize}&TenantId=${TenantId}&MinCreatedTime=${MinCreatedTime}&MaxCreatedTime=${MaxCreatedTime}`;
    return this.request<[]>('get', url);
  }

  /**
   * 添加
   * @param ClientId Gets or sets the client identifier associated with the application.
   * @param ClientSecret Gets or sets the client secret associated with the application.
Note: depending on the application manager used when creating it,
this property may be hashed or encrypted for security reasons.
   * @param ConsentType Gets or sets the consent type associated with the application.
   * @param DisplayName Gets or sets the display name associated with the application.
   * @param DisplayNames Gets the localized display names associated with the application.
   * @param Permissions Gets the permissions associated with the application.
   * @param PostLogoutRedirectUris Gets the logout callback URLs associated with the application.
   * @param Properties Gets the additional properties associated with the application.
   * @param RedirectUris Gets the callback URLs associated with the application.
   * @param Requirements Gets the requirements associated with the application.
   * @param Type Gets or sets the application type associated with the application.
   */
  add(ClientId: string, ClientSecret: string, ConsentType: string, DisplayName: string, DisplayNames: any, Permissions: string[], PostLogoutRedirectUris: string[], Properties: any, RedirectUris: string[], Requirements: string[], Type: string): Observable<OpenIddictApplicationDescriptor> {
    const url = `/api/OpenIdApplication?ClientId=${ClientId}&ClientSecret=${ClientSecret}&ConsentType=${ConsentType}&DisplayName=${DisplayName}&DisplayNames=${DisplayNames}&Permissions=${Permissions}&PostLogoutRedirectUris=${PostLogoutRedirectUris}&Properties=${Properties}&RedirectUris=${RedirectUris}&Requirements=${Requirements}&Type=${Type}`;
    return this.request<OpenIddictApplicationDescriptor>('post', url);
  }

  /**
   * ⚠ 批量删除
   * @param ids string[]
   */
  batchDelete(ids: string[]): Observable<number> {
    const url = `/api/OpenIdApplication`;
    return this.request<number>('delete', url);
  }

}
