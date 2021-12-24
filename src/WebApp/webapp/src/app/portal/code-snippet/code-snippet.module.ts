import { NgModule } from '@angular/core';
import { CodeSnippetRoutingModule } from './code-snippet-routing.module';
import { IndexComponent } from './index/index.component';
import { DetailComponent } from './detail/detail.component';
import { LayoutComponent } from './layout/layout.component';
import { AddComponent } from './add/add.component';
import { EditComponent } from './edit/edit.component';
import { ShareModule } from 'src/app/share/share.module';
import { MonacoEditorModule } from '@materia-ui/ngx-monaco-editor';

@NgModule({
  declarations: [IndexComponent, DetailComponent, LayoutComponent, AddComponent, EditComponent],
  imports: [
    ShareModule,
    MonacoEditorModule,
    CodeSnippetRoutingModule
  ]
})
export class CodeSnippetModule { }