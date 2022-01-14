using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using EntityFramework;
using Http.API.Test.Helper;
using Http.Application.DataStore;
using Share.Models.NewsTagsDtos;

namespace Http.API.Test;

public class DataStoreTest
{
    NewsTagsDataStore _store;
    public DataStoreTest()
    {
        _store = DI.GetService<NewsTagsDataStore>();
    }

    [Fact]
    public async Task Should_add_dataAsync()
    {
        var res = await _store.AddAsync(new NewsTags
        {
            Name = "test",
            ThirdNews = new ThirdNews()
            {
                Title = "test"
            }
        });

        Assert.NotNull(res);
        Assert.Equal("test", res.Name);
    }

    [Fact]
    public async Task Should_get_listAsync()
    {
        var tags = await _store.FindAsync(new NewsTagsFilter
        {
            PageIndex = 1,
            PageSize = 10,
        });
        var exist = tags.Where(t => t.Name.Equals("test"))
            .ToList();
        Assert.NotNull(exist);
    }

    [Fact]
    public async void Should_find_and_update_data()
    {
        var id = new Guid("1273c21d-3c6a-4634-9332-1289a7c45673");
        var tag = await _store.FindAsync(id);
        var updateDto = new NewsTagsUpdateDto
        {
            Name = "update_test",
            Color = "white",
            Status = Status.Valid
        };
        var res = await _store.UpdateAsync(tag!.Id, updateDto);
        Assert.Equal("update_test", res?.Name);
        Assert.Equal("white", res?.Color);
        Assert.Equal(Status.Valid, res?.Status);

        updateDto = new NewsTagsUpdateDto
        {
            Name = "update_test2"
        };
        res = await _store.UpdateAsync(tag!.Id, updateDto);
        Assert.Equal("update_test2", res?.Name);
        Assert.Equal("white", res?.Color);
        Assert.Equal(Status.Valid, res?.Status);
    }
}
