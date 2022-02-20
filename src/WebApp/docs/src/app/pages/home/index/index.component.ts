import { Component, Input, OnInit } from '@angular/core';
import { Docs } from 'src/app/share/models/docs/docs.model';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {

  @Input()
  docs = {} as Docs;
  constructor() { }
  ngOnInit(): void {
    
  }
}
