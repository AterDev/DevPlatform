import { Component, OnInit, ViewChild } from '@angular/core';
import { WebConfigService } from 'src/app/share/services/web-config.service';
import { Router } from '@angular/router';
import { ConfirmDialogComponent } from 'src/app/components/confirm-dialog/confirm-dialog.component';
import { WebConfigItemDto } from 'src/app/share/models/web-config/web-config-item-dto.model';
import { WebConfigFilterDto } from 'src/app/share/models/web-config/web-config-filter-dto.model';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';
import { WebConfig } from 'src/app/share/models/web-config/web-config.model';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { WebConfigAddDto } from 'src/app/share/models/web-config/web-config-add-dto.model';
import { Repository } from 'src/app/share/models/repository.model';
import { RepositoryItemDto } from 'src/app/share/models/repository/repository-item-dto.model';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {
  @ViewChild(MatPaginator, { static: true }) paginator!: MatPaginator;
  isLoading = true;
  total = 0;
  data?= {} as WebConfig;
  repositories = [] as RepositoryItemDto[] || null;
  columns: string[] = ['webSiteName', 'description', 'githubUser', 'actions'];
  dataSource!: MatTableDataSource<WebConfigItemDto>;
  filter: WebConfigFilterDto;
  formGroup!: FormGroup;
  constructor(
    private service: WebConfigService,
    private snb: MatSnackBar,
    private dialog: MatDialog,
    private router: Router,
  ) {

    this.filter = {
      pageIndex: 1,
      pageSize: 1
    };
  }
  get webSiteName() { return this.formGroup.get('webSiteName'); }
  get description() { return this.formGroup.get('description'); }
  get githubPAT() { return this.formGroup.get('githubPAT'); }
  get repositoryId() { return this.formGroup.get('repositoryId'); }
  ngOnInit(): void {
    this.getList();
  }
  initForm(): void {
    this.formGroup = new FormGroup({
      webSiteName: new FormControl(this.data?.webSiteName, [Validators.maxLength(60)]),
      description: new FormControl(this.data?.description, [Validators.maxLength(200)]),
      githubPAT: new FormControl(this.data?.githubPAT, [Validators.maxLength(100)]),
      repositoryId: new FormControl(this.data?.repositoryId, []),
    });
  }
  getList(): void {
    this.service.filter(this.filter)
      .subscribe(res => {
        if (res.data) {
          console.log(res.data);

          this.data = res.data[0];
          this.total = res.count;
          this.initForm();
        }
        this.isLoading = false;
      });
  }

  choseRepos(): void {
    this.snb.open("正在获取您的github仓库列表");
    if (this.githubPAT?.value) {
      this.service.getRepositories(this.githubPAT.value)
        .subscribe(res => {
          this.repositories = res;
          if (res && res.length > 0) {
            this.repositoryId?.setValue(res[0].repositoryId);
          }

          this.snb.open("获取仓库成功");

        });
    } else {
      this.snb.open("请先设置PAT");
    }

  }
  getValidatorMessage(type: string): string {
    switch (type) {
      case 'webSiteName':
        return this.webSiteName?.errors?.['required'] ? 'WebSiteName必填' :
          this.webSiteName?.errors?.['minlength'] ? 'WebSiteName长度最少位' :
            this.webSiteName?.errors?.['maxlength'] ? 'WebSiteName长度最多60位' : '';
      case 'description':
        return this.description?.errors?.['required'] ? 'Description必填' :
          this.description?.errors?.['minlength'] ? 'Description长度最少位' :
            this.description?.errors?.['maxlength'] ? 'Description长度最多200位' : '';
      case 'githubPAT':
        return this.githubPAT?.errors?.['required'] ? 'GithubPAT必填' :
          this.githubPAT?.errors?.['minlength'] ? 'GithubPAT长度最少位' :
            this.githubPAT?.errors?.['maxlength'] ? 'GithubPAT长度最多100位' : '';
      case 'repositoryId':
        return this.repositoryId?.errors?.['required'] ? 'RepositoryId必填' :
          this.repositoryId?.errors?.['minlength'] ? 'RepositoryId长度最少位' :
            this.repositoryId?.errors?.['maxlength'] ? 'RepositoryId长度最多位' : '';
      default:
        return '';
    }
  }
  /**
   * 编辑
   */
  save(): void {
    let data = this.formGroup.value as WebConfigAddDto;
    data.id = this.data?.id!;
    this.service.save(data)
      .subscribe(res => {
        if (res) {
          this.snb.open("保存成功");
        }
      });
  }
  sync(): void {
    this.snb.open("开始同步，请稍等");
    if (this.githubPAT?.value && this.repositoryId?.value) {
      this.service.sync()
        .subscribe(res => {
          if (res) {
            this.snb.open("同步成功");
          } else {
            this.snb.open("同步失败");
          }
        });
    } else {
      this.snb.open("请先配置github PAT并选择要同步的仓库");
    }



  }
}
