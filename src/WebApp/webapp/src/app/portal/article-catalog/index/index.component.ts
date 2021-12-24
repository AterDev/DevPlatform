import { Component, OnInit, ViewChild } from '@angular/core';
import { ArticleCatalogService } from 'src/app/services/article-catalog.service';
import { Router } from '@angular/router';
import { ConfirmDialogComponent } from 'src/app/share/confirm-dialog/confirm-dialog.component';
import { ArticleCatalogDto } from '../../share/models/article-catalog-dto.model';
import { ArticleCatalogFilter } from '../../share/models/article-catalog-filter.model';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {
  @ViewChild(MatPaginator, { static: true }) paginator!: MatPaginator;
  isLoading = true;
  total = 0;
  data: ArticleCatalogDto[] = [];
  columns: string[] = ['name',　'type',　'sort',　'actions'];
  dataSource!: MatTableDataSource<ArticleCatalogDto>;
  filter: ArticleCatalogFilter;
  pageSizeOption = [12, 20, 50];
  constructor(
    private service: ArticleCatalogService,
    private snb: MatSnackBar,
    private dialog: MatDialog,
    private router: Router,
  ) {

    this.filter = {
      pageIndex: 1,
      pageSize: 12
    };
  }

  ngOnInit(): void {
    this.getList();
  }

  getList(event?: PageEvent): void {
    if(event) {
      this.filter.pageIndex = event.pageIndex + 1;
      this.filter.pageSize = event.pageSize;
    }
    this.service.filter(this.filter)
      .subscribe(res => {
        if (res.data) {
          this.data = res.data;
          this.total = res.count;
          this.dataSource = new MatTableDataSource<ArticleCatalogDto>(this.data);
        }
      });
  }

  deleteConfirm(item: ArticleCatalogDto): void {
    const ref = this.dialog.open(ConfirmDialogComponent, {
      hasBackdrop: true,
      disableClose: false,
      data: {
        title: '删除',
        content: '是否确定删除?'
      }
    });

    ref.afterClosed().subscribe(res => {
      if (res) {
        this.delete(item);
      }
    });
  }
  delete(item: ArticleCatalogDto): void {
    this.service.delete(item.id)
      .subscribe(res => {
        this.data = this.data.filter(_ => _.id !== res.id);
        this.dataSource.data = this.data;
        this.snb.open('删除成功');
      });
}

/*
openAddDialog(): void {
  const ref = this.dialog.open(AddComponent, {
    hasBackdrop: true,
    disableClose: false,
    data: {
    }
  });
  ref.afterClosed().subscribe(res => {
    if (res) {
      this.snb.open('添加成功');
      this.getList();
    }
  });
}
openDetailDialog(id: string): void {
  const ref = this.dialog.open(DetailComponent, {
    hasBackdrop: true,
    disableClose: false,
    data: { id }
  });
  ref.afterClosed().subscribe(res => {
    if (res) { }
  });
}

openEditDialog(id: string): void {
  const ref = this.dialog.open(EditComponent, {
    hasBackdrop: true,
    disableClose: false,
    data: { id }
  });
  ref.afterClosed().subscribe(res => {
    if (res) {
      this.snb.open('修改成功');
      this.getList();
    }
  });
}*/

  /**
   * 编辑
   */
  edit(id: string): void {
    console.log(id);
    this.router.navigateByUrl('/article-catalog/edit/' + id);
  }

}
