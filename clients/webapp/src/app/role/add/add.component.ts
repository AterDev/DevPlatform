import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { RoleService } from '../../services/role.service';
import { RoleAddDto } from '../../share/models/role-add-dto.model';
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
  data = {} as RoleAddDto;
  isLoading = true;
  status = Status;
  constructor(
    private service: RoleService,
    public snb: MatSnackBar,
    private router: Router,
    // public dialogRef: MatDialogRef<AddComponent>,
    // @Inject(MAT_DIALOG_DATA) public dlgData: { id: '' }
  ) {

  }

    get name() { return this.formGroup.get('name'); }
    get icon() { return this.formGroup.get('icon'); }


  ngOnInit(): void {
    this.initForm();
    // TODO:获取其他相关数据
  }

  initForm(): void {
    this.formGroup = new FormGroup({
      name: new FormControl(null, [Validators.maxLength(50)]),
      icon: new FormControl(null, [Validators.maxLength(30)]),

    });
  }
  getValidatorMessage(type: string): string {
    switch (type) {
      case 'name':
        return this.name?.errors?.required ? 'Name必填' :
          this.name?.errors?.minlength ? 'Name长度最少位' :
            this.name?.errors?.maxlength ? 'Name长度最多50位' : '';
      case 'icon':
        return this.icon?.errors?.required ? 'Icon必填' :
          this.icon?.errors?.minlength ? 'Icon长度最少位' :
            this.icon?.errors?.maxlength ? 'Icon长度最多30位' : '';

      default:
        return '';
    }
  }

  add(): void {
    if(this.formGroup.valid) {
      const data = this.formGroup.value as RoleAddDto;
      this.data = {...data, ...this.data};
      this.service.add(this.data)
        .subscribe(res => {
          this.snb.open('添加成功');
          // this.dialogRef.close(res);
          // this.router.navigateByUrl('/role/index');
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
