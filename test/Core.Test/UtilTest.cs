using System.Linq;
using Core.Test.Data;
using Core.Utils;
using Xunit;

namespace Core.Test;

public class UtilTest
{
    [Fact]
    public void Should_object_merge_dto()
    {
        var user = new User()
        {
            Age = 30,
            CreatedTime = System.DateTimeOffset.Now,
            Email = "asdf@adfa.com",
            Id = System.Guid.NewGuid(),
            Male = true,
            Name = "niltor",
            Password = "adsafdf",
            Status = Status.Default
        };
        var userDto = new UserDto()
        {
            Male = false,
        };

        user.Merge(userDto);
        Assert.Equal(false, user.Male);
        Assert.Equal(Status.Default, user.Status);

        var userDto2 = new UserDto()
        {
            Name = null,
            Age = null,
            Male = null,
            Status = null,
            Email = null,
            Password = "111111"
        };
        user.Merge(userDto2);
        Assert.Equal("111111", user.Password);
        Assert.Equal("niltor", user.Name);
        Assert.Equal(30, user.Age);
        Assert.Equal(Status.Default, user.Status);

        var userDto3 = new UserDto() { Status = Status.Deleted };
        user.Merge(userDto3);
        Assert.Equal("niltor", user.Name);
        Assert.Equal(30, user.Age);
        Assert.Equal(Status.Deleted, user.Status);
    }


    [Fact]
    public void Should_select_fields_by_Type()
    {
        var user = new User();
        var users = user.GetTestUsers(12);

        var _query = users.AsQueryable();
        var items = _query.Select<User, UserItem>();
        var res = items.ToList();
        Assert.Equal(12, res.Count);
    }


}
