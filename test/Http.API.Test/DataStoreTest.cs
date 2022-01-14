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

    [Fact]
    public async void Should_batch_success()
    {
        var tagName = "batch_test_3";
        var news = new ThirdNews() { Title = "TestNews", Status = Status.Deleted };
        var newTags = new List<NewsTags>()
        {
            new NewsTags{Name = tagName,ThirdNews = news},
            new NewsTags{Name = tagName,ThirdNews = news},
            new NewsTags{Name = tagName,ThirdNews = news},
        };

        // batch add 
        var res = await _store.BatchAddAsync(newTags);
        Assert.True(res == 4);// 3tags + 1news
        var tags = _store.Db.Where(t => t.Name == tagName).ToList();
        Assert.Equal(3, tags.Count);

        // batch update
        var ids = tags.Select(t => t.Id).ToList();
        var updateTag = new NewsTagsUpdateDto
        {
            Name = "batch_update_test1",
            Status = Status.Deleted
        };
        await _store.BatchUpdateAsync(ids, updateTag);

        tags = _store.Db
            .Where(t => t.Name == "batch_update_test1"
                && t.Status == Status.Deleted)
            .ToList();
        Assert.Equal(3, tags.Count);
        // batch delete
        await _store.BatchDeleteAsync(ids);
        tags = _store.Db.Where(t => ids.Contains(t.Id)).ToList();
        Assert.Empty(tags);
    }
}
