import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { WebConfig } from 'src/app/share/models/web-config/web-config.model';
import { WebConfigService } from 'src/app/share/services/web-config.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { WebConfigUpdateDto } from 'src/app/share/models/web-config/web-config-update-dto.model';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Location } from '@angular/common';
import { Status } from 'src/app/share/models/enum/status.model';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  Status = Status;

  id!: string;
  isLoading = true;
  data = {} as WebConfig;
  updateData = {} as WebConfigUpdateDto;
  formGroup!: FormGroup;
    constructor(
    
    private service: WebConfigService,
    private snb: MatSnackBar,
    private router: Router,
    private route: ActivatedRoute,
    private location: Location
    // public dialogRef: MatDialogRef<EditComponent>,
    // @Inject(MAT_DIALOG_DATA) public dlgData: { id: '' }
  ) {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.id = id;
    } else {
      // TODO: id为空
    }
  }

    get webSiteName() { return this.formGroup.get('webSiteName'); }
    get description() { return this.formGroup.get('description'); }
    get githubUser() { return this.formGroup.get('githubUser'); }
    get githubPAT() { return this.formGroup.get('githubPAT'); }
    get repositoryId() { return this.formGroup.get('repositoryId'); }
    get status() { return this.formGroup.get('status'); }


  ngOnInit(): void {
    this.getDetail();
    
    // TODO:获取其他相关数据后设置加载状态
    // this.isLoading = false;
  }
  
  getDetail(): void {
    this.service.getDetail(this.id)
      .subscribe(res => {
        this.data = res;
        this.initForm();
        this.isLoading = false;
      }, error => {
        this.snb.open(error);
      })
  }

  initForm(): void {
    this.formGroup = new FormGroup({
      webSiteName: new FormControl(this.data.webSiteName, [Validators.maxLength(60)]),
      description: new FormControl(this.data.description, [Validators.maxLength(200)]),
      githubUser: new FormControl(this.data.githubUser, [Validators.maxLength(100)]),
      githubPAT: new FormControl(this.data.githubPAT, [Validators.maxLength(100)]),
      repositoryId: new FormControl(this.data.repositoryId, []),
      status: new FormControl(this.data.status, []),

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
  edit(): void {
    if(this.formGroup.valid) {
      this.updateData = this.formGroup.value as WebConfigUpdateDto;
      this.service.update(this.id, this.updateData)
        .subscribe(res => {
          this.snb.open('修改成功');
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
            this.updateData.logoUrl = res.url;
          }, error => {
            this.snb.open(error?.detail);
          }); */
    } else {

    }
  }

}
