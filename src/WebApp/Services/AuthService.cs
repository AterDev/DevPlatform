using Blazored.LocalStorage;
using Share.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace WebApp.Services
{
    /// <summary>
    /// 授权验证
    /// </summary>
    public class AuthService
    {
        public bool IsLogin { get; set; } = false;
        public string Username { get; set; }
        public string Role { get; set; }
        public Guid Id { get; set; }

        ILocalStorageService _localStorage;
        HttpClient _http;
        public AuthService(ILocalStorageService localStorage,
            HttpClient http)
        {
            _localStorage = localStorage;
            _http = http;
        }


        public async Task Initialize()
        {
            var info = await _localStorage.GetItemAsync<LocalUserInfo>("userinfo");
            if (info != null && !string.IsNullOrEmpty(info.Username))
            {
                IsLogin = true;
                Username = info.Username;
                Role = info.Role;
                Id = info.Id;
            }
        }

        /// <summary>
        /// 更新状态
        /// </summary>
        /// <param name="userinfo"></param>
        /// <returns></returns>
        public async Task<LocalUserInfo> UpdateStateAsync(LocalUserInfo userinfo = null)
        {
            if (userinfo != null)
            {
                Username = userinfo.Username;
                await _localStorage.SetItemAsync("userinfo", userinfo);
                IsLogin = true;
                return userinfo;
            }
            var info = await _localStorage.GetItemAsync<LocalUserInfo>("userinfo");
            if (!string.IsNullOrEmpty(info.Username))
            {
                IsLogin = true;
                Username = info.Username;
                Role = info.Role;
                Id = info.Id;
            }
            return info;
        }

        /// <summary>
        /// 更新token
        /// </summary>
        /// <param name="token"></param>
        public void UpdateToken(string token)
        {
            _http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

        }

        public async Task ClearAsync()
        {
            await _localStorage.ClearAsync();
            Username = null;
            IsLogin = false;
        }

    }
}
