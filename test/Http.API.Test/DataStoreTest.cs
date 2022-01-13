using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using Http.API.Test.Helper;
using Http.Application.DataStore;

namespace Http.API.Test;

public class DataStoreTest
{

    [Fact]
    public async Task Should_add_dataAsync()
    {
        var store = DI.GetService<NewsTagsDataStore>();
        var res = await store.AddAsync(new NewsTags
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
}
