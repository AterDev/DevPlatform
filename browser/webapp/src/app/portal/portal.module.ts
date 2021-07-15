import { NgModule } from '@angular/core';
import { PortalRoutingModule } from './portal-routing.module';
import { PortalLayoutComponent } from './portal-layout/portal-layout.component';
import { ShareModule } from '../share/share.module';
import { CodeSnippetModule } from './code-snippet/code-snippet.module';
import { IndexComponent } from './index/index.component';
import { ThinkModule } from './think/think.module';


@NgModule({
  declarations: [PortalLayoutComponent, IndexComponent],
  imports: [
    ShareModule,
    PortalRoutingModule,
    CodeSnippetModule,
    ThinkModule
  ]
})
export class PortalModule { }
