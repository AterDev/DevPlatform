import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ArticleDto } from 'src/app/share/models/article-dto.model';
import { ArticleService } from 'src/app/services/article.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ArticleUpdateDto } from 'src/app/share/models/article-update-dto.model';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Location } from '@angular/common';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  id!: string;
  isLoading = true;
  data = {} as Article;
  updateData = {} as ArticleUpdateDto;
  formGroup!: FormGroup;
  constructor(
    private service: ArticleService,
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

    get title() { return this.formGroup.get('title'); }
    get summary() { return this.formGroup.get('summary'); }
    get authorName() { return this.formGroup.get('authorName'); }
    get tags() { return this.formGroup.get('tags'); }
    get isPrivate() { return this.formGroup.get('isPrivate'); }
    get accountId() { return this.formGroup.get('accountId'); }


  ngOnInit(): void {
    this.getDetail();
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
      title: new FormControl(title, [Validators.maxLength(100)]),
      summary: new FormControl(summary, [Validators.maxLength(500)]),
      authorName: new FormControl(authorName, [Validators.maxLength(100)]),
      tags: new FormControl(tags, [Validators.maxLength(100)]),
      isPrivate: new FormControl(isPrivate, []),
      accountId: new FormControl(accountId, []),

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
  edit(): void {
    if(this.formGroup.valid) {
      this.updateData = this.formGroup.value as ArticleUpdateDto;
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
