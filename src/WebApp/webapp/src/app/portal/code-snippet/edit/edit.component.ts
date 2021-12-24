import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CodeSnippetDto } from 'src/app/share/models/code-snippet-dto.model';
import { CodeSnippetService } from 'src/app/services/code-snippet.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CodeSnippetUpdateDto } from 'src/app/share/models/code-snippet-update-dto.model';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MonacoEditorConstructionOptions, MonacoStandaloneCodeEditor } from '@materia-ui/ngx-monaco-editor';
import { CodeType } from 'src/app/share/models/code-type.model';
import { Language } from 'src/app/share/models/language.model';
import { KeyValue, Util } from 'src/app/share/util';
import { MatSelectChange } from '@angular/material/select';

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
  languageSelection: KeyValue<number>[];
  codeTypeSelection: KeyValue<number>[];

  editorOptions: MonacoEditorConstructionOptions = {
    theme: 'vs-dark', language: 'csharp',
  };
  editor: MonacoStandaloneCodeEditor | null = null;
  formGroup!: FormGroup;
  constructor(
    private service: CodeSnippetService,
    private snb: MatSnackBar,
    private router: Router,
    private route: ActivatedRoute,
    // public dialogRef: MatDialogRef<EditComponent>,
    // @Inject(MAT_DIALOG_DATA) public dlgData: { id: '' }
  ) {
    this.languageSelection = Util.enumToArray<number>(Language);
    this.codeTypeSelection = Util.enumToArray<number>(CodeType);
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.id = id;
    } else {
      // TODO: id为空
    }
  }

  get name() { return this.formGroup.get('name'); }
  get description() { return this.formGroup.get('description'); }
  get language() { return this.formGroup.get('language'); }
  get codeType() { return this.formGroup.get('codeType'); }
  get content() { return this.formGroup.get('content'); }


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
      language: new FormControl(this.updateData.language, [Validators.required]),
      codeType: new FormControl(this.updateData.codeType, [Validators.required]),
      content: new FormControl(this.updateData.content, [Validators.required]),

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

      default:
        return '';
    }
  }
  changeLanguage(event: MatSelectChange): void {
    if (this.editor) {
      monaco.editor.setModelLanguage(this.editor.getModel()!, Language[event.value].toLowerCase());
    }
    this.editorOptions.language = Language[event.value];
  }
  editorInit(editor: MonacoStandaloneCodeEditor): void {
    this.editor = editor;
  }
  edit(): void {
    if (this.formGroup.valid) {
      const data = this.formGroup.value as CodeSnippetUpdateDto;
      this.updateData = { ...this.updateData, ...data };
      this.service.update(this.id, this.updateData)
        .subscribe(res => {
          this.snb.open('修改成功');
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
              this.updateData.logoUrl = res.url;
            }, error => {
              this.snb.open(error?.detail);
            }); */
    } else {

    }
  }

}
