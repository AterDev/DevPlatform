import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ArticleService } from 'src/app/share/services/article.service';
import { Article } from 'src/app/share/models/article/article.model';
import { ArticleUpdateDto } from 'src/app/share/models/article/article-update-dto.model';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Location } from '@angular/common';
import * as ClassicEditor from 'ng-ckeditor5-classic';
import { environment } from 'src/environments/environment';
import { CKEditor5 } from '@ckeditor/ckeditor5-angular';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { ArticleType } from 'src/app/share/models/enum/article-type.model';
import { Status } from 'src/app/share/models/enum/status.model';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {
  public editorConfig!: CKEditor5.Config;
  public editor: CKEditor5.EditorConstructor = ClassicEditor;
  ArticleType = ArticleType;
  Status = Status;

  formGroup!: FormGroup;
  data = {} as ArticleUpdateDto;
  isLoading = true;
  constructor(

    private authService: OidcSecurityService,
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
  get content() { return this.formGroup.get('content'); }
  get tags() { return this.formGroup.get('tags'); }
  get articleType() { return this.formGroup.get('articleType'); }
  get isPrivate() { return this.formGroup.get('isPrivate'); }
  get status() { return this.formGroup.get('status'); }


  ngOnInit(): void {

    this.initForm();
    this.initEditor();
    // TODO:?????????????????????????????????????????????
    this.isLoading = false;
  }
  initEditor(): void {
    this.editorConfig = {
      // placeholder: '??????????????????????????????????????????????????????Word???????????????',
      simpleUpload: {
        uploadUrl: environment.uploadEditorFileUrl,
        headers: {
          Authorization: 'Bearer ' + this.authService.getAccessToken()
        }
      },
      language: 'zh-cn'
    };
  }
  onReady(editor: any) {
    editor.ui.getEditableElement().parentElement.insertBefore(
      editor.ui.view.toolbar.element,
      editor.ui.getEditableElement()
    );
  }
  initForm(): void {
    this.formGroup = new FormGroup({
      title: new FormControl(null, [Validators.required, Validators.maxLength(100)]),
      summary: new FormControl(null, [Validators.maxLength(500)]),
      authorName: new FormControl(null, [Validators.maxLength(100)]),
      content: new FormControl(null, [Validators.minLength(100)]),
      tags: new FormControl(null, [Validators.maxLength(100)]),
      articleType: new FormControl(null, []),
      isPrivate: new FormControl(null, []),
      status: new FormControl(null, []),

    });
  }
  getValidatorMessage(type: string): string {
    switch (type) {
      case 'title':
        return this.title?.errors?.['required'] ? 'Title??????' :
          this.title?.errors?.['minlength'] ? 'Title???????????????' :
            this.title?.errors?.['maxlength'] ? 'Title????????????100???' : '';
      case 'summary':
        return this.summary?.errors?.['required'] ? 'Summary??????' :
          this.summary?.errors?.['minlength'] ? 'Summary???????????????' :
            this.summary?.errors?.['maxlength'] ? 'Summary????????????500???' : '';
      case 'authorName':
        return this.authorName?.errors?.['required'] ? 'AuthorName??????' :
          this.authorName?.errors?.['minlength'] ? 'AuthorName???????????????' :
            this.authorName?.errors?.['maxlength'] ? 'AuthorName????????????100???' : '';
      case 'content':
        return this.content?.errors?.['required'] ? 'Content??????' :
          this.content?.errors?.['minlength'] ? 'Content????????????100???' :
            this.content?.errors?.['maxlength'] ? 'Content???????????????' : '';
      case 'tags':
        return this.tags?.errors?.['required'] ? 'Tags??????' :
          this.tags?.errors?.['minlength'] ? 'Tags???????????????' :
            this.tags?.errors?.['maxlength'] ? 'Tags????????????100???' : '';
      case 'articleType':
        return this.articleType?.errors?.['required'] ? 'ArticleType??????' :
          this.articleType?.errors?.['minlength'] ? 'ArticleType???????????????' :
            this.articleType?.errors?.['maxlength'] ? 'ArticleType???????????????' : '';
      case 'isPrivate':
        return this.isPrivate?.errors?.['required'] ? 'IsPrivate??????' :
          this.isPrivate?.errors?.['minlength'] ? 'IsPrivate???????????????' :
            this.isPrivate?.errors?.['maxlength'] ? 'IsPrivate???????????????' : '';
      case 'status':
        return this.status?.errors?.['required'] ? 'Status??????' :
          this.status?.errors?.['minlength'] ? 'Status???????????????' :
            this.status?.errors?.['maxlength'] ? 'Status???????????????' : '';

      default:
        return '';
    }
  }

  add(): void {
    console.log(this.formGroup.value);
    console.log(this.formGroup.valid);

    if (this.formGroup.valid) {
      const data = this.formGroup.value as ArticleUpdateDto;
      this.data = { ...data, ...this.data };
      this.service.addWithContent(this.data)
        .subscribe(res => {
          this.snb.open('????????????');
          // this.dialogRef.close(res);
          // this.router.navigate(['../index'],{relativeTo: this.route});
        });
    }
  }
  back(): void {
    this.location.back();
  }
  upload(event: any, type?: string): void {
    const files = event.target.files;
    if (files[0]) {
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
