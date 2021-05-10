import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { LibraryCatalogService } from 'src/app/services/library-catalog.service';
import { LibraryCatalogAddDto } from 'src/app/share/models/library-catalog-add-dto.model';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { Status } from 'src/app/share/models/status.model';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {

  formGroup!: FormGroup;
  data = {} as LibraryCatalogAddDto;
  isLoading = true;
  status = Status;
  constructor(
    private service: LibraryCatalogService,
    public snb: MatSnackBar,
    private router: Router,
    // public dialogRef: MatDialogRef<AddComponent>,
    // @Inject(MAT_DIALOG_DATA) public dlgData: { id: '' }
  ) {

  }

    get name() { return this.formGroup.get('name'); }
    get type() { return this.formGroup.get('type'); }
    get sort() { return this.formGroup.get('sort'); }
    get level() { return this.formGroup.get('level'); }
    get accountId() { return this.formGroup.get('accountId'); }
    get updatedTime() { return this.formGroup.get('updatedTime'); }


  ngOnInit(): void {
    this.initForm();
    // TODO:获取其他相关数据
  }

  initForm(): void {
    this.formGroup = new FormGroup({
      name: new FormControl(null, [Validators.maxLength(50)]),
      type: new FormControl(null, [Validators.maxLength(50)]),
      sort: new FormControl(null, []),
      level: new FormControl(null, []),
      accountId: new FormControl(null, []),
      updatedTime: new FormControl(null, []),

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
      case 'accountId':
        return this.accountId?.errors?.required ? 'AccountId必填' :
          this.accountId?.errors?.minlength ? 'AccountId长度最少位' :
            this.accountId?.errors?.maxlength ? 'AccountId长度最多位' : '';
      case 'updatedTime':
        return this.updatedTime?.errors?.required ? 'UpdatedTime必填' :
          this.updatedTime?.errors?.minlength ? 'UpdatedTime长度最少位' :
            this.updatedTime?.errors?.maxlength ? 'UpdatedTime长度最多位' : '';

      default:
        return '';
    }
  }

  add(): void {
    if(this.formGroup.valid) {
      const data = this.formGroup.value as LibraryCatalogAddDto;
      this.data = {...data, ...this.data};
      this.service.add(this.data)
        .subscribe(res => {
          this.snb.open('添加成功');
          // this.dialogRef.close(res);
          // this.router.navigateByUrl('/library-catalog/index');
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
          this.data.logoUrl = res.url;
        }, error => {
          this.snb.open(error?.detail);
        }); */
    } else {

    }
  }
}
