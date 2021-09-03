using DevNews.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace DevNews.Share
{
    public class NewsService
    {

        HttpClient httpClient;
        static readonly string BaseUrl = "http://39.104.70.89:9002/";
        public NewsService()
        {
            httpClient = new HttpClient();
        }


        public async Task<List<ThirdNews>> GetNewsAsync()
        {
            string url = BaseUrl + "api/ThirdNews/week";
            try
            {
                var response = await httpClient.GetFromJsonAsync<List<ThirdNews>>(url); return response;
            }
            catch (Exception)
            {
                return default;
            }
        }


        public async Task<bool> DeleteAsync(Guid id)
        {
            string url = BaseUrl + "api/ThirdNews/" + id;
            try
            {
                var response = await httpClient.DeleteAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch (Exception)
            {
                return default;
            }
        }
    }
}
