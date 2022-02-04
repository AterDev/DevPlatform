import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TestService {
  private headers: HttpHeaders = new HttpHeaders();
  constructor(private http: HttpClient, private securityService: OidcSecurityService) {
  }


  private setHeaders(): any {
    this.headers = new HttpHeaders();
    this.headers = this.headers.set('Content-Type', 'application/json');
    this.headers = this.headers.set('Accept', 'application/json');

    const token = this.securityService.getAccessToken();
    if (token !== '') {
      const tokenValue = 'Bearer ' + token;
      this.headers = this.headers.append('Authorization', tokenValue);
    }
  }

  getWeekNews(): void {
    this.setHeaders();
    this.http.get(environment.apiBase + 'ThirdNews/week', { headers: this.headers })
      .subscribe(res => {
        console.log(res);
      });
  }
}
