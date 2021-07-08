import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { Status } from 'src/app/share/models/status.model';
import { CodeSnippetService } from 'src/app/services/code-snippet.service';
import { CodeSnippetAddDto } from 'src/app/share/models/code-snippet-add-dto.model';
import { Language } from 'src/app/share/models/language.model';
import { CodeType } from 'src/app/share/models/code-type.model';
import { KeyValue, Util } from 'src/app/share/util';
import { MonacoEditorConstructionOptions } from '@materia-ui/ngx-monaco-editor';
import { MatSelectChange } from '@angular/material/select';

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

  languageSelection: KeyValue<number>[];
  codeTypeSelection: KeyValue<number>[];
  editorOptions: MonacoEditorConstructionOptions = {
    theme: 'vs-dark', language: 'csharp',
  };

  constructor(
    private service: CodeSnippetService,
    public snb: MatSnackBar,
    private router: Router,
    // public dialogRef: MatDialogRef<AddComponent>,
    // @Inject(MAT_DIALOG_DATA) public dlgData: { id: '' }
  ) {
    this.languageSelection = Util.enumToArray<number>(Language);
    this.codeTypeSelection = Util.enumToArray<number>(Language);
  }

  get name() { return this.formGroup.get('name'); }
  get description() { return this.formGroup.get('description'); }
  get language() { return this.formGroup.get('language'); }
  get codeType() { return this.formGroup.get('codeType'); }
  get content() { return this.formGroup.get('content'); }

  ngOnInit(): void {
    this.initForm();
    // 获取其他相关数据

  }

  initForm(): void {
    this.formGroup = new FormGroup({
      name: new FormControl(null, [Validators.maxLength(100)]),
      description: new FormControl(null, [Validators.maxLength(500)]),
      language: new FormControl(Language.Csharp, [Validators.required]),
      codeType: new FormControl(CodeType.Entity, [Validators.required]),
      content: new FormControl('', [Validators.required]),
    });
  }
  changeLanguage(event: MatSelectChange): void {
    console.log(event);
    console.log(Language[event.value]);

    this.editorOptions.language = Language[event.value];

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
