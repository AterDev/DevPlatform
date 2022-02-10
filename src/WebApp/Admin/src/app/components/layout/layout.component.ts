import { isDataSource } from '@angular/cdk/collections';
import { Component, OnInit } from '@angular/core';
import { OidcSecurityService } from 'angular-auth-oidc-client';

@Component({
  selector: 'admin-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.css']
})
export class LayoutComponent implements OnInit {
  isLogin = false;
  username = '';
  constructor(
    private service: OidcSecurityService
  ) {
  }
  ngOnInit(): void {
    this.service.isAuthenticated$
      .subscribe(({ isAuthenticated }) => {

        this.isLogin = isAuthenticated;
        if (this.isLogin) {
          this.service.userData$
            .subscribe(res => {
              this.username = res.userData.email;
            });
        }

      })
  }
  login(): void {
    this.service.authorize();
  }

  logout(): void {
    this.service.logoffAndRevokeTokens()
      .subscribe((result) => console.log(result));
  }
}
