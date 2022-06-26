import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { StripHtmlPipe } from './pipe/strip-html.pipe';
import { ToKeyValuePipe } from './pipe/to-key-value.pipe';

@NgModule({
  declarations: [
    StripHtmlPipe,
    ToKeyValuePipe
  ],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [
    CommonModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    StripHtmlPipe,
    ToKeyValuePipe
  ]
})
export class ShareModule { }
