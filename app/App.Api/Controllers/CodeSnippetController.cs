using Entity;
using Share.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services;
using Services.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace App.Api.Controllers
{
    /// <summary>
    /// 代码片段
    /// </summary>
    public class CodeSnippetController : ApiController<CodeSnippetRepository, CodeSnippet, CodeSnippetAddDto, CodeSnippetUpdateDto, CodeSnippetFilter, CodeSnippetDto>
    {
        public CodeSnippetController(
            ILogger<CodeSnippetController> logger,
            CodeSnippetRepository repository,
             IHttpContextAccessor accessor) : base(logger, repository, accessor)
        {
        }

        /// <summary>
        /// 添加CodeSnippet
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public override async Task<ActionResult<CodeSnippet>> AddAsync([FromBody] CodeSnippetAddDto form)
        {
            if (_repos.Any(_userId, form.Name, form.CodeType, form.Language))
            {
                return Conflict();
            }
            return await _repos.AddAsync(form);
        }

        /// <summary>
        /// 分页筛选CodeSnippet
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpPost("filter")]
        public override async Task<ActionResult<PageResult<CodeSnippetDto>>> FilterAsync(CodeSnippetFilter filter)
        {
            return await _repos.GetListWithPageAsync(filter);
        }

        /// <summary>
        /// 更新CodeSnippet
        /// </summary>
        /// <param name="id"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public override async Task<ActionResult<CodeSnippet>> UpdateAsync([FromRoute] Guid id, [FromBody] CodeSnippetUpdateDto form)
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

        [HttpGet("exist")]
        public ActionResult<bool> ExistAsync([FromQuery] CodeSnippetUnique dto)
        {
            return _repos.Exist(dto);
        }
    }
}