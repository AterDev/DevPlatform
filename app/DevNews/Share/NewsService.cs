using DevNews.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace DevNews.Share
{
    public class NewsService
    {

        HttpClient httpClient;
        static readonly string BaseUrl = "http://localhost:5002/";
        public NewsService()
        {
            httpClient = new HttpClient();
        }


        public async Task<List<ThirdNews>> GetNewsAsync()
        {
            string url = BaseUrl + "api/ThirdNews/week";
            var response = await httpClient.GetFromJsonAsync<List<ThirdNews>>(url);
            return response;
        }

    }
}
