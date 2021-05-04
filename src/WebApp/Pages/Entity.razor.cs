using BlazorMonaco;
using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Pages
{
    public partial class Entity
    {
        public Language CodeLanguage { get; set; } = Language.Csharp;
        private MonacoEditor _editor { get; set; }
        private StandaloneEditorConstructionOptions options = new();
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
            Console.WriteLine(language);

            var model = await _editor.GetModel();
            await MonacoEditor.SetModelLanguage(model, language);
        }

        // 保存
        async Task Save()
        {
            var value = await _editor.GetValue();
            // TODO:存储
        }

    }
}
