using System;
using System.Collections.Generic;

namespace Core.Test.Data;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTimeOffset CreatedTime { get; set; }
    public DateTimeOffset UpdatedTime { get; set; } = DateTimeOffset.Now;
    public string Name { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string? Email { get; set; }
    public int Age { get; set; }
    public bool Male { get; set; }
    public Status Status { get; set; }


    public List<User> GetTestUsers(int number)
    {
        var users = new List<User>();
        for (var i = 0; i < number; i++)
        {
            var user = new User()
            {
                Name = "Name" + i,
                Age = i / 5 + 10,
                Email = "Email" + i * 2,
                Status = Status.Deleted
            };
            users.Add(user);
        }
        return users;
    }
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
public class UserItem
{
    public string Name { get; set; }
    public string? Email { get; set; }
    public int Age { get; set; }
    public bool Male { get; set; }
    public Status Status { get; set; }
}
