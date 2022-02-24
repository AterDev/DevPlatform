import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ComponentsModule } from './components/components.module';
import { HttpClientModule } from '@angular/common/http';
import { HomeModule } from './pages/home/home.module';
import { LayoutComponent } from './pages/layout/layout.component';
import { DocsModule } from './pages/docs/docs.module';
import { DocsCatalogModule } from './pages/docs-catalog/docs-catalog.module';

@NgModule({
  declarations: [
    AppComponent,
    LayoutComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ComponentsModule,
    HttpClientModule,
    HomeModule,
    DocsModule,
    DocsCatalogModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
