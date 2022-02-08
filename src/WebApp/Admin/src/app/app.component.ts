import { Component } from '@angular/core';
import { EventTypes, OidcSecurityService, PublicEventsService } from 'angular-auth-oidc-client';
import { filter, Observable, of } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'admin';
  userData$: Observable<any> = of({});
  isAuthenticated = false;

  constructor(
    private oidcSecurityService: OidcSecurityService
  ) {

    console.log('AppComponent STARTING');
  }
  ngOnInit(): void {
    this.userData$ = this.oidcSecurityService.userData$;
    this.oidcSecurityService.checkAuth()
      .subscribe(res => {
        this.isAuthenticated = res.isAuthenticated;
        console.log('app authenticated', res.isAuthenticated);
      });
  }
}
