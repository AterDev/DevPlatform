using AutoMapper;
using Core.Agreement;
using Share.Models;
using Entity;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkCore;
using Share.Models.Common;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Assist.Utils;
using Services.Repositories;
using Microsoft.Extensions.Logging;
using Services.Agreement;

namespace Services.Repositories
{
    public class AccountRepository : Repository<Account, AccountAddDto, AccountUpdateDto, AccountFilter, AccountDto>
    {

        public AccountRepository(ContextBase context, ILogger<AccountRepository> logger, IUserContext userContext, IMapper mapper) : base(context, logger, userContext, mapper)
        {

        }

        public override Task<PageResult<AccountDto>> GetListWithPageAsync(AccountFilter filter)
        {
            _query = _query.OrderByDescending(q => q.CreatedTime);
            return base.GetListWithPageAsync(filter);
        }

        /// <summary>
        /// 添加账号
        /// </summary>
        /// <param name="form"></param>
        /// <param name="sendEmail"></param>
        /// <returns></returns>
        public async Task<Account> AddAsync(AccountAddDto form, bool sendEmail = true)
        {
            var salt = HashCrypto.BuildSalt();
            var account = _mapper.Map<Account>(form);
            account.HashSalt = salt;
            account.Password = HashCrypto.Create(form.Password, salt);
            account.EmailConfirm = false;
            // 处理角色
            var role = _context.Roles.Where(r => r.Name.ToLower().Equals("user"))
                .SingleOrDefault();
            if (role == null)
            {
                role = new Role { Name = "User" };
                await _context.AddAsync(role);
            }
            account.Roles = new List<Role> { role };
            await _context.AddAsync(account);
            await _context.SaveChangesAsync();
            return account;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public Account SignIn(SignInForm dto)
        {
            var user = _db.Where(u => u.Email.Equals(dto.Username)
                || u.Username.Equals(dto.Username))
                .Include(u => u.Roles)
                .FirstOrDefault();
            if (user == null) return default;
            if (HashCrypto.Validate(dto.Password, user.HashSalt, user.Password))
            {
                return user;
            }
            return default;
        }

        public override Task<Account> UpdateAsync(Guid id, AccountUpdateDto form)
        {
            var account = _db.Find(id);
            if (!string.IsNullOrEmpty(form.Password))
            {
                form.Password = HashCrypto.Create(form.Password, account.HashSalt);
            }

            return base.UpdateAsync(id, form);
        }
    }
}
