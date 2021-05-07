using BlazorMonaco;
using Core.Entity;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Pages.Portal
{
    public partial class Entity
    {
        public Language CodeLanguage { get; set; } = Language.Csharp;
        [Inject]
        protected IJSRuntime JsRuntime { get; set; }
        private MonacoEditor _editor1 { get; set; }
        private StandaloneEditorConstructionOptions options = new();

        protected override async Task OnInitializedAsync()
        {


        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {

            }
        }

        private StandaloneEditorConstructionOptions EditorConstructionOptions(MonacoEditor editor)
        {
            options.Theme = "vs-dark";
            options.Minimap = new EditorMinimapOptions
            {
                Enabled = false
            };
            options.Language = Enum.GetName(typeof(Language), CodeLanguage).ToLower();
            return options;
        }

        private async Task ChangeLanguage(Language value)
        {
            CodeLanguage = value;
            var language = Enum.GetName(typeof(Language), CodeLanguage).ToLower();

            var model = await _editor1.GetModel();
            await MonacoEditor.SetModelLanguage(model, language);
        }

        // 保存
        async Task Save()
        {
            var value = await _editor1.GetValue();
            // TODO:存储
        }

    }
}
