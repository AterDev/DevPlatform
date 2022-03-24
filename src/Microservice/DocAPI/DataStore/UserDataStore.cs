using System.Security.Cryptography;
using System.Text;
using DocAPI.Models.UserDtos;
namespace DocAPI.DataStore;
public class UserDataStore : DataStoreBase<DocsContext, User, UserUpdateDto, UserFilter, UserItemDto>
{
    public UserDataStore(DocsContext context, IUserContext userContext, ILogger<UserDataStore> logger) : base(context, userContext, logger)
    {
    }

    /// <summary>
    /// 登录
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public async Task<User?> LoginAsync(UserLogin user)
    {
        var password = Md5Hash(user.Password);
        var result = await _db.Where(d => d.UserName.Equals(user.UserName)
            && d.Password == password).SingleOrDefaultAsync();
        return result;
    }

    /// <summary>
    /// 初始化管理员用户
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public async Task<User> InitAdminUserAsync(string username, string password)
    {
        var user = new User
        {
            UserName = username,
            Password = Md5Hash( password)
        };
        return await base.AddAsync(user);
    }

    private static string Md5Hash(string str)
    {
        using var md5 = MD5.Create();
        var data = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
        var sBuilder = new StringBuilder();
        for (var i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }
        return sBuilder.ToString();
    }
    public override Task<List<UserItemDto>> FindAsync(UserFilter filter)
    {
        return base.FindAsync(filter);
    }

    public override Task<PageResult<UserItemDto>> FindWithPageAsync(UserFilter filter)
    {
        return base.FindWithPageAsync(filter);
    }
    public override Task<User> AddAsync(User data) => base.AddAsync(data);
    public override Task<User?> UpdateAsync(Guid id, UserUpdateDto dto) => base.UpdateAsync(id, dto);
    public override Task<bool> DeleteAsync(Guid id) => base.DeleteAsync(id);
}
