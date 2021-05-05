using Core.Entity;
using Data.Context;
using Share.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    /// <summary>
    ///  站点维护
    /// </summary>
    public class WebService
    {
        ContextBase _context;
        public WebService(ContextBase context)
        {
            _context = context;
        }

        /// <summary>
        /// 初始化管理员账号
        /// </summary>
        public async Task<Account> InitAdminUserAccountAsync(string username, string password)
        {
            var salt = HashCrypto.BuildSalt();
            var user = new Account
            {
                Username = username ?? "admin",
                HashSalt = salt,
                Password = HashCrypto.Create(password ?? "$admin1234.", salt),

            };
            var role = new Role
            {
                Name = "Admin"
            };
            user.Roles = new List<Role> { role };
            await _context.AddAsync(role);
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
