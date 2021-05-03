using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Models.Common
{
    /// <summary>
    /// 本地用户信息
    /// </summary>
    public class LocalUserInfo
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public LocalUserInfo(string username, string email, string avatar = null)
        {

            Username = username;
            Email = email;
            Avatar = avatar;
        }
    }
}
