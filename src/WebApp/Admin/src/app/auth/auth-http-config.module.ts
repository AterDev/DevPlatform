import { NgModule } from '@angular/core';
import { AuthModule, StsConfigHttpLoader, LogLevel } from 'angular-auth-oidc-client';
import { environment } from 'src/environments/environment';

@NgModule({
  imports: [
    AuthModule.forRoot({
      config: {
        authority: environment.authority,
        redirectUrl: environment.redirectUrl,
        postLogoutRedirectUri: environment.redirectUrl,
        clientId: 'webapp_admin',
        scope: 'openid profile email offline_access',
        responseType: 'code',
        silentRenew: true,
        renewTimeBeforeTokenExpiresInSeconds: 10,
        useRefreshToken: true,
        logLevel: LogLevel.Debug,
      },
    }),
  ],
  exports: [AuthModule],
})
export class AuthHttpConfigModule {}
