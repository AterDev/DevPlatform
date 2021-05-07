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



        void Save()
        {

        }

        void ChangeLanguage()
        {

        }

    }
}
