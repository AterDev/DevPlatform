import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Article } from 'src/app/share/models/article/article.model';
import { ArticleService } from 'src/app/share/services/article.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ArticleUpdateDto } from 'src/app/share/models/article/article-update-dto.model';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Location } from '@angular/common';
import * as ClassicEditor from 'ng-ckeditor5-classic';
import { environment } from 'src/environments/environment';
import { CKEditor5 } from '@ckeditor/ckeditor5-angular';
import { OidcSecurityService } from 'angular-auth-oidc-client';
@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  public editorConfig!: CKEditor5.Config;
  public editor: CKEditor5.EditorConstructor = ClassicEditor;
  id!: string;
  isLoading = true;
  data = {} as Article;
  updateData = {} as ArticleUpdateDto;
  formGroup!: FormGroup;
    constructor(
    
    private authService: OidcSecurityService,
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
    get content() { return this.formGroup.get('content'); }
    get tags() { return this.formGroup.get('tags'); }
    get isPrivate() { return this.formGroup.get('isPrivate'); }


  ngOnInit(): void {
    this.getDetail();
    this.initEditor();
    // TODO:获取其他相关数据后设置加载状态
    this.isLoading = false;
  }
    initEditor(): void {
    this.editorConfig = {
      // placeholder: '请添加图文信息提供证据，也可以直接从Word文档中复制',
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
      title: new FormControl(this.title?.value, [Validators.maxLength(100)]),
      summary: new FormControl(this.summary?.value, [Validators.maxLength(500)]),
      authorName: new FormControl(this.authorName?.value, [Validators.maxLength(100)]),
      content: new FormControl(this.content?.value, [Validators.minLength(100)]),
      tags: new FormControl(this.tags?.value, [Validators.maxLength(100)]),
      isPrivate: new FormControl(this.isPrivate?.value, []),

    });
  }
  getValidatorMessage(type: string): string {
    switch (type) {
      case 'title':
        return this.title?.errors?.['required'] ? 'Title必填' :
          this.title?.errors?.['minlength'] ? 'Title长度最少位' :
            this.title?.errors?.['maxlength'] ? 'Title长度最多100位' : '';
      case 'summary':
        return this.summary?.errors?.['required'] ? 'Summary必填' :
          this.summary?.errors?.['minlength'] ? 'Summary长度最少位' :
            this.summary?.errors?.['maxlength'] ? 'Summary长度最多500位' : '';
      case 'authorName':
        return this.authorName?.errors?.['required'] ? 'AuthorName必填' :
          this.authorName?.errors?.['minlength'] ? 'AuthorName长度最少位' :
            this.authorName?.errors?.['maxlength'] ? 'AuthorName长度最多100位' : '';
      case 'content':
        return this.content?.errors?.['required'] ? 'Content必填' :
          this.content?.errors?.['minlength'] ? 'Content长度最少100位' :
            this.content?.errors?.['maxlength'] ? 'Content长度最多位' : '';
      case 'tags':
        return this.tags?.errors?.['required'] ? 'Tags必填' :
          this.tags?.errors?.['minlength'] ? 'Tags长度最少位' :
            this.tags?.errors?.['maxlength'] ? 'Tags长度最多100位' : '';
      case 'isPrivate':
        return this.isPrivate?.errors?.['required'] ? 'IsPrivate必填' :
          this.isPrivate?.errors?.['minlength'] ? 'IsPrivate长度最少位' :
            this.isPrivate?.errors?.['maxlength'] ? 'IsPrivate长度最多位' : '';

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
