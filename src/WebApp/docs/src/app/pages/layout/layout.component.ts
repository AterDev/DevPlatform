import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'admin-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.css']
})
export class LayoutComponent implements OnInit {

  events: string[] = [];
  isLoading = false;

  opened = true;
  constructor() { }

  ngOnInit(): void {
  }
  toggle(): void {
    this.opened = !this.opened;
  }
}
