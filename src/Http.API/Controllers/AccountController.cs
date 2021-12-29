using Http.Application;
using Http.Application.Interface;
using Http.Application.Repositories;
using Share.Models.AccountDtos;
using Share.Models.CommonDtos;

namespace Http.API.Controllers;

/// <summary>
/// 用户账号
/// </summary>
public class AccountController : ApiController<AccountRepository, Account, AccountAddDto, AccountUpdateDto, AccountFilter, AccountDto>
{
    IConfiguration _config;
    WebService webService;
    public AccountController(
        ILogger<AccountController> logger,
        AccountRepository repository,
        WebService service,
        IConfiguration configuration,
         IUserContext userContext) : base(logger, repository, userContext)
    {
        _config = configuration;
        webService = service;
    }

    /// <summary>
    /// 注册账号
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPost]
    public async override Task<ActionResult<Account>> AddAsync([FromBody] AccountAddDto form)
    {
        if (_repos._db.Any(e => e.Email == form.Email
            || e.Username == form.Username))
        {
            return Conflict();
        }
        return await _repos.AddAsync(form);
    }

    /// <summary>
    /// 分页筛选Account
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    [HttpPost("filter")]
    public async override Task<ActionResult<PageResult<AccountDto>>> FilterAsync(AccountFilter filter)
    {
        return await _repos.GetListWithPageAsync(filter);
    }

    /// <summary>
    /// 更新Account
    /// </summary>
    /// <param name="id"></param>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async override Task<ActionResult<Account>> UpdateAsync([FromRoute] Guid id, [FromBody] AccountUpdateDto form)
    {
        if (_repos._db.Any(e => e.Id == id))
        {
            // 名称不可以修改成其他已经存在的名称
            // if (_repos.Any(e => e.Name == form.Name && e.Id != id))
            // {
            //    return Conflict();
            // }
            return await _repos.UpdateAsync(id, form);
        }
        return NotFound();
    }

    /// <summary>
    /// 登录
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpPost("signIn")]
    public ActionResult<SignInDto> SignUp([FromBody] SignInForm dto)
    {
        var user = _repos.SignIn(dto);
        if (user == null)
        {
            return NotFound("邮箱不存在或密码错误");
        }
        var jwt = new JwtService();
        var issuerSign = _config.GetSection("Jwt")["Sign"];
        var issuer = _config.GetSection("Jwt")["Issuer"];
        var audience = _config.GetSection("Jwt")["Audience"];

        var roles = string.Join(";", user.Roles.Select(r => r.Name).ToList());
        var token = jwt.BuildToken(user, roles, issuerSign, audience, issuer);
        var result = new SignInDto
        {
            Username = user.Username,
            Email = user.Email,
            Avatar = user.Avatar,
            CreatedTime = user.CreatedTime,
            Id = user.Id,
            Token = token,
            RoleName = roles
        };

        return result;
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public override Task<ActionResult<Account>> DeleteAsync([FromRoute] Guid id)
    {
        return base.DeleteAsync(id);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public override Task<ActionResult<Account>> GetDetailAsync([FromRoute] Guid id)
    {
        return base.GetDetailAsync(id);
    }

    /// <summary>
    /// 初始化管理员账号
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    [HttpPost("initAdminUser")]
    [AllowAnonymous]
    public async Task<ActionResult<Account>> InitAdminUserAsync(string username, string password)
    {
        return await webService.InitAdminUserAccountAsync(username, password);
    }

}
