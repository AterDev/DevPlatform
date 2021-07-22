import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ArticleDto } from 'src/app/share/models/article-dto.model';
import { ArticleService } from 'src/app/services/article.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ArticleUpdateDto } from 'src/app/share/models/article-update-dto.model';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { CKEditor5 } from '@ckeditor/ckeditor5-angular';
import * as DecoupledEditor from '@ckeditor/ckeditor5-build-decoupled-document';
import { environment } from 'src/environments/environment';
import { Article } from 'src/app/share/models/article.model';

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
  public editorConfig!: CKEditor5.Config;
  public editor: CKEditor5.EditorConstructor = DecoupledEditor;
  constructor(
    private service: ArticleService,
    private snb: MatSnackBar,
    private router: Router,
    private route: ActivatedRoute,
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
  get tags() { return this.formGroup.get('tags'); }

  get content() { return this.formGroup.get('content'); }
  get catalogId() { return this.formGroup.get('catalogId'); }


  ngOnInit(): void {
    this.getDetail();
  }

  getDetail(): void {
    this.service.getDetail(this.id)
      .subscribe(res => {
        this.data = res;
        this.updateData.content = res.extend?.content;
        this.initForm();
        this.isLoading = false;
      }, error => {
        this.snb.open(error);
      });
  }

  initForm(): void {
    this.formGroup = new FormGroup({
      title: new FormControl(this.data.title, [Validators.maxLength(100)]),
      summary: new FormControl(this.data.summary, [Validators.maxLength(500)]),
      tags: new FormControl(this.data.tags, [Validators.maxLength(100)]),
      content: new FormControl(this.data.extend?.content, [Validators.required]),
    });

    this.editorConfig = {
      // placeholder: '请添加图文信息提供证据，也可以直接从Word文档中复制',
      simpleUpload: {
        uploadUrl: environment.api_daemon + '/api/Article/UploadEditorFile',
        headers: {
          Authorization: 'Bearer ' + localStorage.getItem('token')
        }
      },
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
  edit(): void {
    if (this.formGroup.valid) {
      const data = this.formGroup.value as ArticleUpdateDto;
      this.updateData = { ...this.updateData, ...data };
      this.service.update(this.id, this.updateData)
        .subscribe(res => {
          this.snb.open('修改成功');
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
              this.updateData.logoUrl = res.url;
            }, error => {
              this.snb.open(error?.detail);
            }); */
    } else {

    }
  }

}
