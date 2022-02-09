import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ArticleService } from 'src/app/services/article.service';
import { ArticleAddDto } from 'src/app/share/models/article-add-dto.model';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Status } from 'src/app/share/models/status.model';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Location } from '@angular/common';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {

  formGroup!: FormGroup;
  data = {} as ArticleAddDto;
  isLoading = true;
  status = Status;
  constructor(
    private service: ArticleService,
    public snb: MatSnackBar,
    private router: Router,
    private route: ActivatedRoute,
    private location: Location
    // public dialogRef: MatDialogRef<AddComponent>,
    // @Inject(MAT_DIALOG_DATA) public dlgData: { id: '' }
  ) {

  }

    get title() { return this.formGroup.get('title'); }
    get summary() { return this.formGroup.get('summary'); }
    get authorName() { return this.formGroup.get('authorName'); }
    get tags() { return this.formGroup.get('tags'); }
    get isPrivate() { return this.formGroup.get('isPrivate'); }
    get accountId() { return this.formGroup.get('accountId'); }


  ngOnInit(): void {
    this.initForm();
    // TODO:获取其他相关数据
  }

  initForm(): void {
    this.formGroup = new FormGroup({
      title: new FormControl(null, [Validators.maxLength(100)]),
      summary: new FormControl(null, [Validators.maxLength(500)]),
      authorName: new FormControl(null, [Validators.maxLength(100)]),
      tags: new FormControl(null, [Validators.maxLength(100)]),
      isPrivate: new FormControl(null, []),
      accountId: new FormControl(null, []),

    });
  }
  getValidatorMessage(type: string): string {
    switch (type) {
      case 'title':
        return this.title?.errors?.required ? 'Title必填' :
          this.title?.errors?.minlength ? 'Title长度最少位' :
            this.title?.errors?.maxlength ? 'Title长度最多100位' : '';
      case 'summary':
        return this.summary?.errors?.required ? 'Summary必填' :
          this.summary?.errors?.minlength ? 'Summary长度最少位' :
            this.summary?.errors?.maxlength ? 'Summary长度最多500位' : '';
      case 'authorName':
        return this.authorName?.errors?.required ? 'AuthorName必填' :
          this.authorName?.errors?.minlength ? 'AuthorName长度最少位' :
            this.authorName?.errors?.maxlength ? 'AuthorName长度最多100位' : '';
      case 'tags':
        return this.tags?.errors?.required ? 'Tags必填' :
          this.tags?.errors?.minlength ? 'Tags长度最少位' :
            this.tags?.errors?.maxlength ? 'Tags长度最多100位' : '';
      case 'isPrivate':
        return this.isPrivate?.errors?.required ? 'IsPrivate必填' :
          this.isPrivate?.errors?.minlength ? 'IsPrivate长度最少位' :
            this.isPrivate?.errors?.maxlength ? 'IsPrivate长度最多位' : '';
      case 'accountId':
        return this.accountId?.errors?.required ? 'AccountId必填' :
          this.accountId?.errors?.minlength ? 'AccountId长度最少位' :
            this.accountId?.errors?.maxlength ? 'AccountId长度最多位' : '';

      default:
        return '';
    }
  }

  add(): void {
    if(this.formGroup.valid) {
      const data = this.formGroup.value as ArticleAddDto;
      this.data = {...data, ...this.data};
      this.service.add(this.data)
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
