import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LibraryDto } from 'src/app/share/models/library-dto.model';
import { LibraryService } from 'src/app/services/library.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { LibraryUpdateDto } from 'src/app/share/models/library-update-dto.model';
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
  // data = {} as Library;
  updateData = {} as LibraryUpdateDto;
  formGroup!: FormGroup;
  constructor(
    private service: LibraryService,
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

    get namespace() { return this.formGroup.get('namespace'); }
    get description() { return this.formGroup.get('description'); }
    get language() { return this.formGroup.get('language'); }
    get isValid() { return this.formGroup.get('isValid'); }
    get isPublic() { return this.formGroup.get('isPublic'); }
    get updatedTime() { return this.formGroup.get('updatedTime'); }


  ngOnInit(): void {
    this.getDetail();
  }

  getDetail(): void {
    this.service.getDetail(this.id)
      .subscribe(res => {
        this.updateData = res as LibraryUpdateDto;
        this.initForm();
        this.isLoading = false;
      }, error => {
        this.snb.open(error);
      })
  }

  initForm(): void {
    this.formGroup = new FormGroup({
      namespace: new FormControl(this.updateData.namespace, [Validators.maxLength(100)]),
      description: new FormControl(this.updateData.description, [Validators.maxLength(500)]),
      language: new FormControl(this.updateData.language, [Validators.maxLength(100)]),
      isValid: new FormControl(this.updateData.isValid, []),
      isPublic: new FormControl(this.updateData.isPublic, []),
      updatedTime: new FormControl(this.updateData.updatedTime, []),

    });
  }
  getValidatorMessage(type: string): string {
    switch (type) {
      case 'namespace':
        return this.namespace?.errors?.required ? 'Namespace必填' :
          this.namespace?.errors?.minlength ? 'Namespace长度最少位' :
            this.namespace?.errors?.maxlength ? 'Namespace长度最多100位' : '';
      case 'description':
        return this.description?.errors?.required ? 'Description必填' :
          this.description?.errors?.minlength ? 'Description长度最少位' :
            this.description?.errors?.maxlength ? 'Description长度最多500位' : '';
      case 'language':
        return this.language?.errors?.required ? 'Language必填' :
          this.language?.errors?.minlength ? 'Language长度最少位' :
            this.language?.errors?.maxlength ? 'Language长度最多100位' : '';
      case 'isValid':
        return this.isValid?.errors?.required ? 'IsValid必填' :
          this.isValid?.errors?.minlength ? 'IsValid长度最少位' :
            this.isValid?.errors?.maxlength ? 'IsValid长度最多位' : '';
      case 'isPublic':
        return this.isPublic?.errors?.required ? 'IsPublic必填' :
          this.isPublic?.errors?.minlength ? 'IsPublic长度最少位' :
            this.isPublic?.errors?.maxlength ? 'IsPublic长度最多位' : '';
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
      const data = this.formGroup.value as LibraryUpdateDto;
      this.updateData = {...this.updateData,...data};
      this.service.update(this.id, this.updateData)
        .subscribe(res => {
          this.snb.open('修改成功');
           // this.dialogRef.close(res);
          // this.router.navigateByUrl('/library/index');
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
