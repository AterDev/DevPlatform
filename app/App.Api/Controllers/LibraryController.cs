namespace App.Api.Controllers
{
    /// <summary>
    /// Library
    /// </summary>
    public class LibraryController : ApiController<LibraryRepository, Library, LibraryAddDto, LibraryUpdateDto, LibraryFilter, LibraryDto>
    {
        public LibraryController(
            ILogger<LibraryController> logger,
            LibraryRepository repository,
             IUserContext accessor) : base(logger, repository, accessor)
        {
        }

        /// <summary>
        /// 添加Library
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public override async Task<ActionResult<Library>> AddAsync([FromBody] LibraryAddDto form)
        {
            // if (_repos.Any(e => e.Name == form.Name))
            // {
            //     return Conflict();
            // }
            return await _repos.AddAsync(form);
        }

        /// <summary>
        /// 分页筛选Library
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpPost("filter")]
        public override async Task<ActionResult<PageResult<LibraryDto>>> FilterAsync(LibraryFilter filter)
        {
            return await _repos.GetListWithPageAsync(filter);
        }

        /// <summary>
        /// 更新Library
        /// </summary>
        /// <param name="id"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public override async Task<ActionResult<Library>> UpdateAsync([FromRoute] Guid id, [FromBody] LibraryUpdateDto form)
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
    }
}