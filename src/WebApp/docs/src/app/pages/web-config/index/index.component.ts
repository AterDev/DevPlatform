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
    this.snb.open("??????????????????github????????????");
    if (this.githubPAT?.value) {
      this.service.getRepositories(this.githubPAT.value)
        .subscribe(res => {
          this.repositories = res;
          if (res && res.length > 0) {
            this.repositoryId?.setValue(res[0].repositoryId);
          }

          this.snb.open("??????????????????");

        });
    } else {
      this.snb.open("????????????PAT");
    }

  }
  getValidatorMessage(type: string): string {
    switch (type) {
      case 'webSiteName':
        return this.webSiteName?.errors?.['required'] ? 'WebSiteName??????' :
          this.webSiteName?.errors?.['minlength'] ? 'WebSiteName???????????????' :
            this.webSiteName?.errors?.['maxlength'] ? 'WebSiteName????????????60???' : '';
      case 'description':
        return this.description?.errors?.['required'] ? 'Description??????' :
          this.description?.errors?.['minlength'] ? 'Description???????????????' :
            this.description?.errors?.['maxlength'] ? 'Description????????????200???' : '';
      case 'githubPAT':
        return this.githubPAT?.errors?.['required'] ? 'GithubPAT??????' :
          this.githubPAT?.errors?.['minlength'] ? 'GithubPAT???????????????' :
            this.githubPAT?.errors?.['maxlength'] ? 'GithubPAT????????????100???' : '';
      case 'repositoryId':
        return this.repositoryId?.errors?.['required'] ? 'RepositoryId??????' :
          this.repositoryId?.errors?.['minlength'] ? 'RepositoryId???????????????' :
            this.repositoryId?.errors?.['maxlength'] ? 'RepositoryId???????????????' : '';
      default:
        return '';
    }
  }
  /**
   * ??????
   */
  save(): void {
    let data = this.formGroup.value as WebConfigAddDto;
    data.id = this.data?.id!;
    this.service.save(data)
      .subscribe(res => {
        if (res) {
          this.snb.open("????????????");
        }
      });
  }
  sync(): void {
    this.snb.open("????????????????????????");
    if (this.githubPAT?.value && this.repositoryId?.value) {
      this.service.sync()
        .subscribe(res => {
          if (res) {
            this.snb.open("????????????");
          } else {
            this.snb.open("????????????");
          }
        });
    } else {
      this.snb.open("????????????github PAT???????????????????????????");
    }



  }
}
