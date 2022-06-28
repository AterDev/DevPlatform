import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { WebConfigService } from 'src/app/share/services/web-config.service';
import { WebConfig } from 'src/app/share/models/web-config/web-config.model';
import { WebConfigUpdateDto } from 'src/app/share/models/web-config/web-config-update-dto.model';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Location } from '@angular/common';
import { Status } from 'src/app/share/models/enum/status.model';

@Component({
    selector: 'app-add',
    templateUrl: './add.component.html',
    styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {
    Status = Status;
    formGroup!: FormGroup;
    data = {} as WebConfigUpdateDto;
    isLoading = true;
    constructor(

        private service: WebConfigService,
        public snb: MatSnackBar,
        private router: Router,
        private route: ActivatedRoute,
        private location: Location
        // public dialogRef: MatDialogRef<AddComponent>,
        // @Inject(MAT_DIALOG_DATA) public dlgData: { id: '' }
    ) {

    }

    get webSiteName() { return this.formGroup.get('webSiteName'); }
    get description() { return this.formGroup.get('description'); }
    get githubUser() { return this.formGroup.get('githubUser'); }
    get githubPAT() { return this.formGroup.get('githubPAT'); }
    get repositoryId() { return this.formGroup.get('repositoryId'); }
    get status() { return this.formGroup.get('status'); }


  ngOnInit(): void {
    this.initForm();

    // TODO:获取其他相关数据后设置加载状态
    this.isLoading = false;
  }

  initForm(): void {
    this.formGroup = new FormGroup({
      webSiteName: new FormControl(null, [Validators.maxLength(60)]),
      description: new FormControl(null, [Validators.maxLength(200)]),
      githubUser: new FormControl(null, [Validators.maxLength(100)]),
      githubPAT: new FormControl(null, [Validators.maxLength(100)]),
      repositoryId: new FormControl(null, []),
      status: new FormControl(null, []),

    });
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
      case 'githubUser':
        return this.githubUser?.errors?.['required'] ? 'GithubUser必填' :
          this.githubUser?.errors?.['minlength'] ? 'GithubUser长度最少位' :
            this.githubUser?.errors?.['maxlength'] ? 'GithubUser长度最多100位' : '';
      case 'githubPAT':
        return this.githubPAT?.errors?.['required'] ? 'GithubPAT必填' :
          this.githubPAT?.errors?.['minlength'] ? 'GithubPAT长度最少位' :
            this.githubPAT?.errors?.['maxlength'] ? 'GithubPAT长度最多100位' : '';
      case 'repositoryId':
        return this.repositoryId?.errors?.['required'] ? 'RepositoryId必填' :
          this.repositoryId?.errors?.['minlength'] ? 'RepositoryId长度最少位' :
            this.repositoryId?.errors?.['maxlength'] ? 'RepositoryId长度最多位' : '';
      case 'status':
        return this.status?.errors?.['required'] ? 'Status必填' :
          this.status?.errors?.['minlength'] ? 'Status长度最少位' :
            this.status?.errors?.['maxlength'] ? 'Status长度最多位' : '';

      default:
    return '';
    }
  }

  add(): void {
    if(this.formGroup.valid) {
    const data = this.formGroup.value as WebConfigUpdateDto;
    this.data = { ...data, ...this.data };
    this.service.add(this.data as WebConfig)
        .subscribe(res => {
            this.snb.open('添加成功');
            // this.dialogRef.close(res);
            // this.router.navigate(['../index'],{relativeTo: this.route});
        });
    }
  }
  back(): void {
    this.location.back();
  }
  upload(event: any, type ?: string): void {
    const files = event.target.files;
    if(files[0]) {
      const formdata = new FormData();
      formdata.append('file', files[0]);
    /*    this.service.uploadFile('agent-info' + type, formdata)
          .subscribe(res => {
            this.data.logoUrl = res.url;
          }, error => {
            this.snb.open(error?.detail);
          }); */
    } else {

    }
  }
}
