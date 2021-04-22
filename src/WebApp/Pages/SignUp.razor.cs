using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Share.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace WebApp.Pages
{
    public partial class SignUp
    {
        [Inject]
        public HttpClient Http { get; set; }

        public SignInForm Model = new SignInForm();
        private ValidateForm Form { get; set; }

        async Task OnValidSubmit(EditContext context)
        {
            if (context.Validate())
            {
                var res = await Http.PostAsJsonAsync("/api/account/signIn", Model);
                if (res.IsSuccessStatusCode)
                {
                    var json = await res.Content.ReadFromJsonAsync<SignInDto>();
                }
                else
                {
                    System.Console.WriteLine(await res.Content.ReadAsStringAsync());
                }
            }
            else
            {

            }
        }
    }
}
