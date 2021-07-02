import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ArticleCatalogDto } from 'src/app/share/models/article-catalog-dto.model';
import { ArticleCatalogService } from 'src/app/services/article-catalog.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ArticleCatalogUpdateDto } from 'src/app/share/models/article-catalog-update-dto.model';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  id!: string;
  isLoading = true;
  // data = {} as ArticleCatalog;
  updateData = {} as ArticleCatalogUpdateDto;
  formGroup!: FormGroup;
  constructor(
    private service: ArticleCatalogService,
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

    get name() { return this.formGroup.get('name'); }
    get type() { return this.formGroup.get('type'); }
    get sort() { return this.formGroup.get('sort'); }
    get level() { return this.formGroup.get('level'); }
    get parentId() { return this.formGroup.get('parentId'); }
    get updatedTime() { return this.formGroup.get('updatedTime'); }


  ngOnInit(): void {
    this.getDetail();
  }

  getDetail(): void {
    this.service.getDetail(this.id)
      .subscribe(res => {
        this.updateData = res as ArticleCatalogUpdateDto;
        this.initForm();
        this.isLoading = false;
      }, error => {
        this.snb.open(error);
      })
  }

  initForm(): void {
    this.formGroup = new FormGroup({
      name: new FormControl(this.updateData.name, [Validators.maxLength(50)]),
      type: new FormControl(this.updateData.type, [Validators.maxLength(50)]),
      sort: new FormControl(this.updateData.sort, []),
      level: new FormControl(this.updateData.level, []),
      parentId: new FormControl(this.updateData.parentId, []),
      updatedTime: new FormControl(this.updateData.updatedTime, []),

    });
  }
  getValidatorMessage(type: string): string {
    switch (type) {
      case 'name':
        return this.name?.errors?.required ? 'Name必填' :
          this.name?.errors?.minlength ? 'Name长度最少位' :
            this.name?.errors?.maxlength ? 'Name长度最多50位' : '';
      case 'type':
        return this.type?.errors?.required ? 'Type必填' :
          this.type?.errors?.minlength ? 'Type长度最少位' :
            this.type?.errors?.maxlength ? 'Type长度最多50位' : '';
      case 'sort':
        return this.sort?.errors?.required ? 'Sort必填' :
          this.sort?.errors?.minlength ? 'Sort长度最少位' :
            this.sort?.errors?.maxlength ? 'Sort长度最多位' : '';
      case 'level':
        return this.level?.errors?.required ? 'Level必填' :
          this.level?.errors?.minlength ? 'Level长度最少位' :
            this.level?.errors?.maxlength ? 'Level长度最多位' : '';
      case 'parentId':
        return this.parentId?.errors?.required ? 'ParentId必填' :
          this.parentId?.errors?.minlength ? 'ParentId长度最少位' :
            this.parentId?.errors?.maxlength ? 'ParentId长度最多位' : '';
      case 'updatedTime':
        return this.updatedTime?.errors?.required ? 'UpdatedTime必填' :
          this.updatedTime?.errors?.minlength ? 'UpdatedTime长度最少位' :
            this.updatedTime?.errors?.maxlength ? 'UpdatedTime长度最多位' : '';

      default:
        return '';
    }
  }
  edit(): void {
    if(this.formGroup.valid) {
      const data = this.formGroup.value as ArticleCatalogUpdateDto;
      this.updateData = {...this.updateData,...data};
      this.service.update(this.id, this.updateData)
        .subscribe(res => {
          this.snb.open('修改成功');
           // this.dialogRef.close(res);
          // this.router.navigateByUrl('/article-catalog/index');
        });
    }
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
