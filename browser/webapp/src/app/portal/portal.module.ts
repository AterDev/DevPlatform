import { NgModule } from '@angular/core';
import { PortalRoutingModule } from './portal-routing.module';
import { PortalLayoutComponent } from './portal-layout/portal-layout.component';
import { ShareModule } from '../share/share.module';
import { CodeSnippetModule } from './code-snippet/code-snippet.module';


@NgModule({
  declarations: [PortalLayoutComponent],
  imports: [
    ShareModule,
    PortalRoutingModule,
    CodeSnippetModule
  ]
})
export class PortalModule { }
