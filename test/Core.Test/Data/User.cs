using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Test.Data;

public class User
{
    public Guid Id { get; set; }
    public DateTimeOffset CreatedTime { get; set; }
    public DateTimeOffset UpdatedTime { get; set; } = DateTimeOffset.Now;
    public string Name { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string? Email { get; set; }
    public int Age { get; set; }
    public bool Male { get; set; }
    public Status Status { get; set; }
}


public enum Status
{
    Default,
    Deleted
}
public class UserDto
{
    public DateTimeOffset UpdatedTime { get; set; } = default;
    public string? Name { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public int? Age { get; set; }
    public bool? Male { get; set; }
    public Status? Status { get; set; }
}
