import { DOCUMENT } from '@angular/common';
import { Component, Inject, Input, OnInit, ViewEncapsulation } from '@angular/core';
import { Docs } from 'src/app/share/models/docs/docs.model';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class IndexComponent implements OnInit {

  @Input()
  docs = {} as Docs;
  headings: any;
  constructor(
    @Inject(DOCUMENT) private document: Document
  ) { }
  ngOnInit(): void {

  }
  onReady(): void {
    setTimeout(() => {
      this.headings = this.document
        .querySelector('markdown')!
        .querySelectorAll('h1, h2, h3');

      console.log(this.headings);

    });
  }
}
