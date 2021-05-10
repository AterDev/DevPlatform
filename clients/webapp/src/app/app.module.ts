import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ShareModule } from './share/share.module';
import { HomeModule } from './home/home.module';
import { MAT_SNACK_BAR_DEFAULT_OPTIONS } from '@angular/material/snack-bar';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { CustomerHttpInterceptor } from './customer-http.interceptor';
import { ArticleModule } from './article/article.module';
import { CodeSnippetModule } from './code-snippet/code-snippet.module';
import { LibraryModule } from './library/library.module';
import { RoleModule } from './role/role.module';
// import { OAuthModule } from 'angular-oauth2-oidc';

const appModules = [
  HomeModule,
  ArticleModule,
  CodeSnippetModule,
  LibraryModule,
  RoleModule
];

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    ShareModule,
    ...appModules
  ],
  providers: [
    { provide: MAT_SNACK_BAR_DEFAULT_OPTIONS, useValue: { duration: 2500 } },
    { provide: HTTP_INTERCEPTORS, useClass: CustomerHttpInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

