using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.Json;
using AntDesign;
using Microsoft.AspNetCore.Components;

namespace CodeSnippet.Pages
{
    public partial class SignIn
    {
        private Model model = new Model();

        [Inject]
        public MessageService message { get; set; }

        public SignIn()
        {
        }

        private void OnFinish(EditContext editContext)
        {
            if (model.Username == "niltor" && model.Password == "11100916")
            {
                message.Success("login success!");
            }
            else
            {
                message.Error("login failed");
            }
        }

        private void OnFinishFailed(EditContext editContext)
        {

            Console.WriteLine($"Failed:{JsonSerializer.Serialize(model)}");
        }
    }
    public class Model
    {
        [Required, DisplayName("UserName")]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
