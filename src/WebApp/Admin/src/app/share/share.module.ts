import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MarkdownModule } from 'ngx-markdown';
import { EnumPipe } from './pipe/enum.pipe';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';

@NgModule({
  declarations: [EnumPipe],
  imports: [
    CommonModule,
    RouterModule,
    ReactiveFormsModule,
    FormsModule,
    CKEditorModule,
    MarkdownModule.forRoot(),
  ],
  exports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    CKEditorModule,
    EnumPipe
  ]
})
export class ShareModule { }
