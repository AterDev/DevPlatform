import { Component, Input, OnInit } from '@angular/core';
import { MonacoEditorConstructionOptions, MonacoEditorLoaderService, MonacoStandaloneCodeEditor } from '@materia-ui/ngx-monaco-editor';
import { filter, take } from 'rxjs/operators';

@Component({
  selector: 'app-code-editor',
  templateUrl: './code-editor.component.html',
  styleUrls: ['./code-editor.component.css']
})
export class CodeEditorComponent implements OnInit {
  @Input() language = '';
  editorOptions: MonacoEditorConstructionOptions = {
    theme: 'vs-dark', language: 'csharp',
  };
  codeSnippet = 'function x() {\nconsole.log("Hello world!");\n}';
  constructor(
    private monacoLoader: MonacoEditorLoaderService
  ) {
    this.monacoLoader.isMonacoLoaded$.pipe(
      filter(isLoaded => isLoaded),
      take(1),
    ).subscribe(() => {
      // here, we retrieve monaco-editor instance

    });
  }

  ngOnInit(): void {
    if (this.language) {
      this.editorOptions.language = this.language;
    }
  }
  editorInit(editor: MonacoStandaloneCodeEditor): void {
    // Here you can access editor instance

  }
}
