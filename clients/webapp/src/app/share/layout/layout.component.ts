import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
// import { OAuthService } from 'angular-oauth2-oidc';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.css']
})
export class LayoutComponent implements OnInit {
  isLogin = false;
  username = '';
  constructor(
    private service: AuthService,
    // private oauthService: OAuthService,
    private router: Router
  ) { }

  ngOnInit(): void {
    // this.isLogin = this.service.hasValidAccessToken();
    // const claims = this.oauthService.getIdentityClaims() as Record<string, string>;
    // this.username = claims?.name ?? '';
  }

  login(): void {
    // this.oauthService.initCodeFlow();
    this.router.navigateByUrl('/login');
  }

  logout(): void {
    // this.oauthService.logOut();
    this.router.navigateByUrl('/index');
  }

}
