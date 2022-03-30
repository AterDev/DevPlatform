import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { DocsCatalogService } from 'src/app/share/services/docs-catalog.service';
import { DocsCatalog } from 'src/app/share/models/docs-catalog/docs-catalog.model';
import { DocsCatalogUpdateDto } from 'src/app/share/models/docs-catalog/docs-catalog-update-dto.model';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Location } from '@angular/common';
import { DocsCatalogItemDto } from 'src/app/share/models/docs-catalog/docs-catalog-item-dto.model';
import { DocsCatalogAddDto } from 'src/app/share/models/docs-catalog/docs-catalog-add-dto.model';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {

  formGroup!: FormGroup;
  data = {} as DocsCatalogUpdateDto;
  catalogs = [] as DocsCatalogItemDto[];
  isLoading = true;
  constructor(

    private service: DocsCatalogService,
    public snb: MatSnackBar,
    private router: Router,
    private route: ActivatedRoute,
    private location: Location
    // public dialogRef: MatDialogRef<AddComponent>,
    // @Inject(MAT_DIALOG_DATA) public dlgData: { id: '' }
  ) {

  }

  get name() { return this.formGroup.get('name'); }
  get sort() { return this.formGroup.get('sort'); }
  get parentId() { return this.formGroup.get('parentId'); }

  ngOnInit(): void {
    this.initForm();
    this.getCatalogs();
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
      name: new FormControl(null, [Validators.minLength(3), Validators.maxLength(20)]),
      sort: new FormControl(0, []),
      parentId: new FormControl(null)

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

  add(): void {
    if (this.formGroup.valid) {
      const data = this.formGroup.value as DocsCatalogAddDto;
      this.data = { ...data, ...this.data };
      this.service.addIn(this.data)
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
