import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { Status } from 'src/app/share/models/status.model';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { CodeSnippetService } from 'src/app/services/code-snippet.service';
import { CodeSnippetAddDto } from 'src/app/share/models/code-snippet-add-dto.model';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {

  formGroup!: FormGroup;
  data = {} as CodeSnippetAddDto;
  isLoading = true;
  status = Status;
  constructor(
    private service: CodeSnippetService,
    public snb: MatSnackBar,
    private router: Router,
    // public dialogRef: MatDialogRef<AddComponent>,
    // @Inject(MAT_DIALOG_DATA) public dlgData: { id: '' }
  ) {

  }

  get name() { return this.formGroup.get('name'); }
  get description() { return this.formGroup.get('description'); }
  get content() { return this.formGroup.get('content'); }
  get updatedTime() { return this.formGroup.get('updatedTime'); }


  ngOnInit(): void {
    this.initForm();
    // TODO:获取其他相关数据
  }

  initForm(): void {
    this.formGroup = new FormGroup({
      name: new FormControl(null, [Validators.maxLength(100)]),
      description: new FormControl(null, [Validators.maxLength(500)]),
      content: new FormControl(null, [Validators.maxLength(4000)]),
      updatedTime: new FormControl(null, []),

    });
  }
  getValidatorMessage(type: string): string {
    switch (type) {
      case 'name':
        return this.name?.errors?.required ? 'Name必填' :
          this.name?.errors?.minlength ? 'Name长度最少位' :
            this.name?.errors?.maxlength ? 'Name长度最多100位' : '';
      case 'description':
        return this.description?.errors?.required ? 'Description必填' :
          this.description?.errors?.minlength ? 'Description长度最少位' :
            this.description?.errors?.maxlength ? 'Description长度最多500位' : '';
      case 'content':
        return this.content?.errors?.required ? 'Content必填' :
          this.content?.errors?.minlength ? 'Content长度最少位' :
            this.content?.errors?.maxlength ? 'Content长度最多4000位' : '';
      case 'updatedTime':
        return this.updatedTime?.errors?.required ? 'UpdatedTime必填' :
          this.updatedTime?.errors?.minlength ? 'UpdatedTime长度最少位' :
            this.updatedTime?.errors?.maxlength ? 'UpdatedTime长度最多位' : '';

      default:
        return '';
    }
  }

  add(): void {
    if (this.formGroup.valid) {
      const data = this.formGroup.value as CodeSnippetAddDto;
      this.data = { ...data, ...this.data };
      this.service.add(this.data)
        .subscribe(res => {
          this.snb.open('添加成功');
          // this.dialogRef.close(res);
          // this.router.navigateByUrl('/code-snippet/index');
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
              this.data.logoUrl = res.url;
            }, error => {
              this.snb.open(error?.detail);
            }); */
    } else {

    }
  }
}
