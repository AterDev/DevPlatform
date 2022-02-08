import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MarkdownModule } from 'ngx-markdown';
import { EnumPipe } from './pipe/enum.pipe';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule,
    ReactiveFormsModule,
    FormsModule,
    MarkdownModule.forRoot(),
    EnumPipe
  ],
  exports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    EnumPipe
  ]
})
export class ShareModule { }
