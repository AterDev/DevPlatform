import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DocsCatalog } from 'src/app/share/models/docs-catalog/docs-catalog.model';
import { DocsCatalogService } from 'src/app/share/services/docs-catalog.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DocsCatalogUpdateDto } from 'src/app/share/models/docs-catalog/docs-catalog-update-dto.model';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Location } from '@angular/common';
import { DocsCatalogItemDto } from 'src/app/share/models/docs-catalog/docs-catalog-item-dto.model';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {

  id!: string;
  isLoading = true;
  data = {} as DocsCatalog;
  updateData = {} as DocsCatalogUpdateDto;
  catalogs = [] as DocsCatalogItemDto[];
  formGroup!: FormGroup;
  constructor(
    private service: DocsCatalogService,
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

  get name() { return this.formGroup.get('name'); }
  get sort() { return this.formGroup.get('sort'); }
  get parentId() { return this.formGroup.get('parentId'); }

  ngOnInit(): void {
    this.getDetail();
  }

  getDetail(): void {
    this.service.getDetail(this.id)
      .subscribe(res => {
        this.data = res;
        this.initForm();
        this.getCatalogs();
      }, error => {
        this.snb.open(error);
      })
  }
  getCatalogs(): void {
    this.service.filter({ pageIndex: 1, pageSize: 100 })
      .subscribe(res => {
        if (res.data) {
          this.catalogs = res.data;
        }
        this.isLoading = false;
      });
  }
  initForm(): void {
    this.formGroup = new FormGroup({
      name: new FormControl(this.data.name, [Validators.minLength(3), Validators.maxLength(20)]),
      sort: new FormControl(this.data.sort, []),
      parentId: new FormControl(this.data.parent?.id),
    });
  }

  getValidatorMessage(type: string): string {
    switch (type) {
      case 'name':
        return this.name?.errors?.['required'] ? 'Name必填' :
          this.name?.errors?.['minlength'] ? 'Name长度最少3位' :
            this.name?.errors?.['maxlength'] ? 'Name长度最多20位' : '';
      case 'sort':
        return this.sort?.errors?.['required'] ? 'Sort必填' :
          this.sort?.errors?.['minlength'] ? 'Sort长度最少位' :
            this.sort?.errors?.['maxlength'] ? 'Sort长度最多位' : '';

      default:
        return '';
    }
  }
  edit(): void {
    if (this.formGroup.valid) {
      this.updateData = this.formGroup.value as DocsCatalogUpdateDto;
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
