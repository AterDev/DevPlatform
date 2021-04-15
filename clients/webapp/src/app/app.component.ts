import { Component, OnInit } from '@angular/core';
// import { OAuthService, AuthConfig } from 'angular-oauth2-oidc';

// export const authCodeFlowConfig: AuthConfig = {
//   issuer: 'https://localhost:5001',
//   redirectUri: window.location.origin + '/signin-oidc',
//   clientId: 'webapp',
//   responseType: 'code',
//   tokenEndpoint: 'https://localhost:5001/connect/token',
//   postLogoutRedirectUri: window.location.origin + '/signout-callback-oidc',
//   scope: 'openid profile webapp offline_access'
// };

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'webapp';
  constructor(
    // private oauthService: OAuthService
  ) {

    // this.oauthService.configure(authCodeFlowConfig);
    // this.oauthService.setupAutomaticSilentRefresh();
    // this.oauthService.loadDiscoveryDocumentAndTryLogin();
  }
  ngOnInit(): void {
  }
}
