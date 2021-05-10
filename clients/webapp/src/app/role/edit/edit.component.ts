import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RoleDto } from 'src/app/share/models/role-dto.model';
import { RoleService } from 'src/app/services/role.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { RoleUpdateDto } from 'src/app/share/models/role-update-dto.model';
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
  // data = {} as Role;
  updateData = {} as RoleUpdateDto;
  formGroup!: FormGroup;
  constructor(
    private service: RoleService,
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
    get icon() { return this.formGroup.get('icon'); }
    get updatedTime() { return this.formGroup.get('updatedTime'); }


  ngOnInit(): void {
    this.getDetail();
  }

  getDetail(): void {
    this.service.getDetail(this.id)
      .subscribe(res => {
        this.updateData = res as RoleUpdateDto;
        this.initForm();
        this.isLoading = false;
      }, error => {
        this.snb.open(error);
      })
  }

  initForm(): void {
    this.formGroup = new FormGroup({
      name: new FormControl(this.updateData.name, [Validators.maxLength(50)]),
      icon: new FormControl(this.updateData.icon, [Validators.maxLength(30)]),
      updatedTime: new FormControl(this.updateData.updatedTime, []),

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
      const data = this.formGroup.value as RoleUpdateDto;
      this.updateData = {...this.updateData,...data};
      this.service.update(this.id, this.updateData)
        .subscribe(res => {
          this.snb.open('修改成功');
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
            this.updateData.logoUrl = res.url;
          }, error => {
            this.snb.open(error?.detail);
          }); */
    } else {

    }
  }

}
