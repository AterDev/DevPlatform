import { NgModule } from '@angular/core';
import { ShareModule } from '../share/share.module';
import { CodeEditorComponent } from './code-editor/code-editor.component';



@NgModule({
  declarations: [CodeEditorComponent],
  imports: [
    ShareModule
  ]
})
export class ComponentsModule { }
