import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { DocsService } from 'src/app/share/services/docs.service';
import { Docs } from 'src/app/share/models/docs/docs.model';
import { DocsUpdateDto } from 'src/app/share/models/docs/docs-update-dto.model';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Location } from '@angular/common';
import * as ClassicEditor from 'ng-ckeditor5-classic';
import { environment } from 'src/environments/environment';
import { DocsCatalogService } from 'src/app/share/services/docs-catalog.service';
import { DocsCatalogItemDto } from 'src/app/share/models/docs-catalog/docs-catalog-item-dto.model';
import { resetFakeAsyncZone } from '@angular/core/testing';
// import { OidcSecurityService } from 'angular-auth-oidc-client';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {
  formGroup!: FormGroup;
  data = {} as DocsUpdateDto;
  catalogs = [] as DocsCatalogItemDto[];
  isLoading = true;
  constructor(
    // private authService: OidcSecurityService,
    private service: DocsService,
    private catalogSrv: DocsCatalogService,
    public snb: MatSnackBar,
    private router: Router,
    private route: ActivatedRoute,
    private location: Location
    // public dialogRef: MatDialogRef<AddComponent>,
    // @Inject(MAT_DIALOG_DATA) public dlgData: { id: '' }
  ) {

  }

  get name() { return this.formGroup.get('name'); }
  get content() { return this.formGroup.get('content'); }
  get catalogId() { return this.formGroup.get('catalogId'); }

  ngOnInit(): void {
    this.initForm();
    // 获取其他相关数据后设置加载状态
    this.getCatalogs();
  }

  getCatalogs(): void {
    this.catalogSrv.filter({ pageIndex: 1, pageSize: 100 })
      .subscribe(res => {
        if (res.data) {
          this.catalogs = res.data;
        }
        this.isLoading = false;
      });
  }
  initForm(): void {
    this.formGroup = new FormGroup({
      name: new FormControl(null, [Validators.minLength(3), Validators.maxLength(100)]),
      content: new FormControl(null, [Validators.maxLength(10000)]),
      catalogId: new FormControl(null, [Validators.required])
    });
  }
  getValidatorMessage(type: string): string {
    switch (type) {
      case 'name':
        return this.name?.errors?.['required'] ? 'Name必填' :
          this.name?.errors?.['minlength'] ? 'Name长度最少3位' :
            this.name?.errors?.['maxlength'] ? 'Name长度最多100位' : '';
      case 'content':
        return this.content?.errors?.['required'] ? 'Content必填' :
          this.content?.errors?.['minlength'] ? 'Content长度最少位' :
            this.content?.errors?.['maxlength'] ? 'Content长度最多10000位' : '';
      case 'catalogId':
        return this.catalogId?.errors?.['required'] ? '必须选择一个目录' : '';
      default:
        return '';
    }
  }

  add(): void {
    if (this.formGroup.valid) {
      const data = this.formGroup.value as DocsUpdateDto;
      this.data = { ...data, ...this.data };

      let docs = [] as DocsUpdateDto[];
      docs.push(this.data);
      this.service.addIn(this.catalogId?.value, docs)
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
