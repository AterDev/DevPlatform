import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CodeSnippetDto } from 'src/app/share/models/code-snippet-dto.model';
import { CodeSnippetService } from 'src/app/services/code-snippet.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CodeSnippetUpdateDto } from 'src/app/share/models/code-snippet-update-dto.model';
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
  // data = {} as CodeSnippet;
  updateData = {} as CodeSnippetUpdateDto;
  formGroup!: FormGroup;
  constructor(
    private service: CodeSnippetService,
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
    get description() { return this.formGroup.get('description'); }
    get content() { return this.formGroup.get('content'); }
    get updatedTime() { return this.formGroup.get('updatedTime'); }


  ngOnInit(): void {
    this.getDetail();
  }

  getDetail(): void {
    this.service.getDetail(this.id)
      .subscribe(res => {
        this.updateData = res as CodeSnippetUpdateDto;
        this.initForm();
        this.isLoading = false;
      }, error => {
        this.snb.open(error);
      })
  }

  initForm(): void {
    this.formGroup = new FormGroup({
      name: new FormControl(this.updateData.name, [Validators.maxLength(100)]),
      description: new FormControl(this.updateData.description, [Validators.maxLength(500)]),
      content: new FormControl(this.updateData.content, [Validators.maxLength(4000)]),
      updatedTime: new FormControl(this.updateData.updatedTime, []),

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
  edit(): void {
    if(this.formGroup.valid) {
      const data = this.formGroup.value as CodeSnippetUpdateDto;
      this.updateData = {...this.updateData,...data};
      this.service.update(this.id, this.updateData)
        .subscribe(res => {
          this.snb.open('修改成功');
           // this.dialogRef.close(res);
          // this.router.navigateByUrl('/code-snippet/index');
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
