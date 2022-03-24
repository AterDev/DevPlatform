using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DocAPI.Models.UserDtos;
using Microsoft.IdentityModel.Tokens;

namespace DocAPI.Controllers;

/// <summary>
/// 用户
/// </summary>
public class UserController : RestApiBase<UserDataStore, User, UserUpdateDto, UserFilter, UserItemDto>
{

    IConfiguration _config;
    public UserController(IUserContext user, ILogger<UserController> logger, UserDataStore store, IConfiguration configuration) : base(user, logger, store)
    {
        _config = configuration;
    }

    /// <summary>
    /// 登录
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<ActionResult<LoginResult>> LoginAsync([FromBody] UserLogin user)
    {
        var res = await _store.LoginAsync(user);
        if (res == null)
        {
            return Problem("用户名或密码错误");
        }

        var issuerSign = _config.GetSection("Jwt")["Sign"];
        var issuer = _config.GetSection("Jwt")["Issuer"];
        var audience = _config.GetSection("Jwt")["Audience"];
        var token = BuildToken(res.Id.ToString(), issuerSign, audience, issuer);
        return new LoginResult(res.Id, res.UserName, token);
    }

    /// <summary>
    /// 生成jwt token
    /// </summary>
    /// <param name="id"></param>
    /// <param name="sign"></param>
    /// <param name="audience"></param>
    /// <param name="issuer"></param>
    /// <returns></returns>
    [NonAction]
    private string BuildToken(string id, string sign, string audience, string issuer)
    {
        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(sign));
        var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
        var claims = new Claim[]
        {
            // 此处自定义claims
            new Claim(ClaimTypes.NameIdentifier, id),
        };
        var jwt = new JwtSecurityToken(issuer, audience, claims, signingCredentials: signingCredentials);
        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
        return encodedJwt;
    }

    /// <summary>
    /// 分页筛选
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    public override Task<ActionResult<PageResult<UserItemDto>>> FilterAsync(UserFilter filter)
    {
        return base.FilterAsync(filter);
    }

    /// <summary>
    /// 添加
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    public override Task<ActionResult<User>> AddAsync(User form) => base.AddAsync(form);

    /// <summary>
    /// ⚠更新
    /// </summary>
    /// <param name="id"></param>
    /// <param name="form"></param>
    /// <returns></returns>
    public override Task<ActionResult<User?>> UpdateAsync([FromRoute] Guid id, UserUpdateDto form)
        => base.UpdateAsync(id, form);

    /// <summary>
    /// ⚠删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public override Task<ActionResult<bool>> DeleteAsync([FromRoute] Guid id)
    {
        return base.DeleteAsync(id);
    }

    /// <summary>
    /// ⚠ 批量删除
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    public override async Task<ActionResult<int>> BatchDeleteAsync(List<Guid> ids)
    {
        // 危险操作，请确保该方法的执行权限
        //return base.BatchDeleteAsync(ids);
        return await Task.FromResult(0);
    }
}
