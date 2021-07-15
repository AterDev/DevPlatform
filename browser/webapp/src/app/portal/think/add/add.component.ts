import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { CKEditor5 } from '@ckeditor/ckeditor5-angular';
import * as DecoupledEditor from '@ckeditor/ckeditor5-build-decoupled-document';
import { ArticleService } from 'src/app/services/article.service';
import { ArticleAddDto } from 'src/app/share/models/article-add-dto.model';
import { Status } from 'src/app/share/models/status.model';
import { environment } from 'src/environments/environment';

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
  public editorConfig!: CKEditor5.Config;
  public editor: CKEditor5.EditorConstructor = DecoupledEditor;
  constructor(
    private service: ArticleService,
    public snb: MatSnackBar,
    private router: Router,
    // public dialogRef: MatDialogRef<AddComponent>,
    // @Inject(MAT_DIALOG_DATA) public dlgData: { id: '' }
  ) {

  }

  get title() { return this.formGroup.get('title'); }
  get summary() { return this.formGroup.get('summary'); }
  get tags() { return this.formGroup.get('tags'); }
  get content() { return this.formGroup.get('content'); }
  get accountId() { return this.formGroup.get('accountId'); }
  get catalogId() { return this.formGroup.get('catalogId'); }


  ngOnInit(): void {
    this.initForm();
    // TODO:获取其他相关数据
  }

  initForm(): void {
    this.formGroup = new FormGroup({
      title: new FormControl(null, [Validators.maxLength(100)]),
      summary: new FormControl(null, [Validators.maxLength(500)]),
      tags: new FormControl(null, [Validators.maxLength(100)]),
      content: new FormControl(null, []),
      accountId: new FormControl(null, []),
      catalogId: new FormControl(null, []),

    });
    this.editorConfig = {
      // placeholder: '请添加图文信息提供证据，也可以直接从Word文档中复制',
      simpleUpload: {
        uploadUrl: environment.api_daemon + '/api/CourseProduct/UploadEditorFile',
        headers: {
          Authorization: 'Bearer ' + localStorage.getItem('token')
        }
      },
      height: '600px',
      language: 'zh-cn'
    };
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
      case 'tags':
        return this.tags?.errors?.required ? 'Tags必填' :
          this.tags?.errors?.minlength ? 'Tags长度最少位' :
            this.tags?.errors?.maxlength ? 'Tags长度最多100位' : '';
      case 'content':
        return this.content?.errors?.required ? 'Content必填' :
          this.content?.errors?.minlength ? 'Content长度最少位' :
            this.content?.errors?.maxlength ? 'Content长度最多位' : '';
      case 'accountId':
        return this.accountId?.errors?.required ? 'AccountId必填' :
          this.accountId?.errors?.minlength ? 'AccountId长度最少位' :
            this.accountId?.errors?.maxlength ? 'AccountId长度最多位' : '';
      case 'catalogId':
        return this.catalogId?.errors?.required ? 'CatalogId必填' :
          this.catalogId?.errors?.minlength ? 'CatalogId长度最少位' :
            this.catalogId?.errors?.maxlength ? 'CatalogId长度最多位' : '';

      default:
        return '';
    }
  }
  public onReady(editor: any) {
    editor.ui.getEditableElement().parentElement.insertBefore(
      editor.ui.view.toolbar.element,
      editor.ui.getEditableElement()
    );
  }
  add(): void {
    if (this.formGroup.valid) {
      const data = this.formGroup.value as ArticleAddDto;
      this.data = { ...data, ...this.data };
      this.service.add(this.data)
        .subscribe(res => {
          this.snb.open('添加成功');
          // this.dialogRef.close(res);
          // this.router.navigateByUrl('/article/index');
        });
    }
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
