
namespace App.Api.Controllers
{
    /// <summary>
    /// ThirdNews
    /// </summary>
    public class ThirdNewsController : ApiController<ThirdNewsRepository, ThirdNews, ThirdNewsAddDto, ThirdNewsUpdateDto, ThirdNewsFilter, ThirdNewsDto>
    {
        public ThirdNewsController(
            ILogger<ThirdNewsController> logger,
            ThirdNewsRepository repository, IUserContext userContext) : base(logger, repository, userContext)
        {
        }

        /// <summary>
        /// 添加ThirdNews
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public override async Task<ActionResult<ThirdNews>> AddAsync([FromBody] ThirdNewsAddDto form)
        {
            // if (_repos.Any(e => e.Name == form.Name))
            // {
            //     return Conflict();
            // }
            return await _repos.AddAsync(form);
        }

        /// <summary>
        /// 分页筛选ThirdNews
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpPost("filter")]
        public override async Task<ActionResult<PageResult<ThirdNewsDto>>> FilterAsync(ThirdNewsFilter filter)
        {
            return await _repos.GetListWithPageAsync(filter);
        }

        /// <summary>
        /// 更新ThirdNews
        /// </summary>
        /// <param name="id"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public override async Task<ActionResult<ThirdNews>> UpdateAsync([FromRoute] Guid id, [FromBody] ThirdNewsUpdateDto form)
        {
            if (_repos.Any(e => e.Id == id))
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
        /// 删除ThirdNews
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public override Task<ActionResult<ThirdNews>> DeleteAsync([FromRoute] Guid id)
        {
            return base.DeleteAsync(id);
        }

        /// <summary>
        /// 获取ThirdNews详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public override Task<ActionResult<ThirdNews>> GetDetailAsync([FromRoute] Guid id)
        {
            return base.GetDetailAsync(id);
        }
    }
}