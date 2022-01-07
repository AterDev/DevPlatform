using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Microsoft.AspNetCore.Components.Forms;

namespace CodeSnippet.Pages;

public partial class SignIn
{
    private Model model = new();

    public SignIn()
    {
    }

    private void OnFinish(EditContext editContext)
    {
        if (model.Username == "niltor" && model.Password == "11100916")
        {
            //message.Success("login success!");
        }
        else
        {
            //message.Error("login failed");
        }
    }

    private void OnFinishFailed(EditContext editContext) => Console.WriteLine($"Failed:{JsonSerializer.Serialize(model)}");
}
public class Model
{
    [Required, DisplayName("UserName")]
    public string? Username { get; set; }
    [Required]
    public string? Password { get; set; }
}
