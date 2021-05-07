using Blazorise.RichTextEdit;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Pages.Portal
{
    public partial class Blog
    {

        

        [Inject]
        protected IJSRuntime JsRuntime { get; set; }

        protected override Task OnInitializedAsync()
        {

            return base.OnInitializedAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            
        }


 
    }
}
