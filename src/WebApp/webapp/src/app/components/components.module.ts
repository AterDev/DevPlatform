import { NgModule } from '@angular/core';
import { MonacoEditorModule } from '@materia-ui/ngx-monaco-editor';
import { ShareModule } from '../share/share.module';
import { CodeEditorComponent } from './code-editor/code-editor.component';

@NgModule({
  declarations: [CodeEditorComponent],
  imports: [
    ShareModule,
    MonacoEditorModule
  ],
  exports: [
    MonacoEditorModule,
    CodeEditorComponent
  ]
})
export class ComponentsModule { }
