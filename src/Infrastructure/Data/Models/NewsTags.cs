namespace Infrastructure.Data.Models;

public class NewsTags : BaseDB
{
    [MaxLength(40)]
    public string? Name { get; set; }
    [MaxLength(20)]
    public string? Color { get; set; }
    public ThirdNews ThirdNews { get; set; }

}
