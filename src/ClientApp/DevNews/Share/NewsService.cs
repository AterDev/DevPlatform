using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using DevNews.Models;

namespace DevNews.Share
{
    public class NewsService
    {

        HttpClient httpClient;
        readonly static string BaseUrl = "http://39.104.70.89:9002/";
        //static readonly string BaseUrl = "http://localhost:5002/";
        public NewsService()
        {
            httpClient = new HttpClient();
        }


        public async Task<List<ThirdNews>> GetNewsAsync()
        {
            string url = BaseUrl + "api/ThirdNews/week";
            try
            {
                var response = await httpClient.GetFromJsonAsync<List<ThirdNews>>(url);
                response = response.GroupBy(n => n.Title).Select(n => n.FirstOrDefault()).ToList();
                return response;
            }
            catch (Exception)
            {
                return new List<ThirdNews>();
            }
        }

        /// <summary>
        /// 资讯分类
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="newsType"></param>
        /// <returns></returns>
        public async Task<bool> MoveNewsAsync(List<Guid> ids, TechType newsType)
        {
            string url = BaseUrl + "api/ThirdNews/type?newsType=" + newsType;
            try
            {
                var response = await httpClient.PutAsJsonAsync(url, ids);
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
                return false;
            }
        }

        /// <summary>
        /// 获取标签
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public async Task<bool> GetTagsAsync(string type)
        {
            string url = BaseUrl + "api/TagLibrary/filter";
            try
            {
                var response = await httpClient.PostAsJsonAsync(url, new { PageIndex = 0, PageSize = 100, Type = type });
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
                return false;
            }
        }

        /// <summary>
        /// 添加标签
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tags"></param>
        /// <returns></returns>
        public async Task<bool> SetTechTypeAsync(Guid id, List<NewsTagsAddDto> tags)
        {
            string url = BaseUrl + "api/ThirdNews/tags/" + id;
            try
            {
                var response = await httpClient.PostAsJsonAsync(url, tags);
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
                return false;
            }
        }

        /// <summary>
        /// 删除标签
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteTagAsync(Guid id)
        {
            string url = BaseUrl + "api/ThirdNews/tags" + id;
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
                return false;
            }
        }

        /// <summary>
        /// 批量设置为已删除状态
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public async Task<bool> SetAsDelteAsync(List<Guid> ids)
        {
            string url = BaseUrl + "api/ThirdNews/deleted";
            try
            {
                var response = await httpClient.PutAsJsonAsync(url, ids);
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
