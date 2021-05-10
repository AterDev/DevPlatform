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
    this.isLogin = this.service.isLogin;
    this.username = this.service.username;
  }

  login(): void {
    // this.oauthService.initCodeFlow();
    this.router.navigateByUrl('/login');
  }

  logout(): void {
    this.service.logout();
    this.router.navigateByUrl('/index');
  }

}
