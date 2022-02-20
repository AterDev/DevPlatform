import { NestedTreeControl } from '@angular/cdk/tree';
import { Component, OnInit } from '@angular/core';
import { MatTreeNestedDataSource } from '@angular/material/tree';
import { DocsCatalogTreeItemDto } from 'src/app/share/models/docs-catalog-tree/docs-catalog-tree-item-dto.model';
import { DocsCatalogItemDto } from 'src/app/share/models/docs-catalog/docs-catalog-item-dto.model';
import { Docs } from 'src/app/share/models/docs/docs.model';
import { DocsCatalogService } from 'src/app/share/services/docs-catalog.service';
import { DocsService } from 'src/app/share/services/docs.service';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.css']
})
export class LayoutComponent implements OnInit {
  events: string[] = [];
  isLoading = true;
  opened = true;
  catalogs: DocsCatalogTreeItemDto[] | null = [];
  docs = {} as Docs;
  treeControl = new NestedTreeControl<DocsCatalogTreeItemDto>(node => node.children);
  dataSource = new MatTreeNestedDataSource<DocsCatalogTreeItemDto>();
  constructor(
    private service: DocsCatalogService,
    private docsService: DocsService

  ) { }

  hasChild = (_: number, node: DocsCatalogTreeItemDto) => !!node.children && node.children.length > 0;
  ngOnInit(): void {
    // 获取文档目录
    this.getList();
  }

  getList(): void {
    this.service.getTree()
      .subscribe(res => {
        if (res) {
          this.catalogs = res;
          this.dataSource.data = this.catalogs;
          this.isLoading = false;
        }
      });
  }
  toggle(): void {
    this.opened = !this.opened;
  }

  loadContent(node: DocsCatalogTreeItemDto): void {
    if (node.isDoc) {
      // 获取文档内容
      this.docsService.getDetail(node.id)
        .subscribe(res => {
          if (res) {
            this.docs = res;
          }
        });
    }
  }
}
