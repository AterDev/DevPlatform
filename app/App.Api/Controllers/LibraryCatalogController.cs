using Entity;
using Share.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services;
using Services.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;
using App.Agreement;
using Microsoft.AspNetCore.Http;

namespace App.Api.Controllers
{
    /// <summary>
    /// LibraryCatalog
    /// </summary>
    public class LibraryCatalogController : ApiController<LibraryCatalogRepository, LibraryCatalog, LibraryCatalogAddDto, LibraryCatalogUpdateDto, LibraryCatalogFilter, LibraryCatalogDto>
    {
        public LibraryCatalogController(
            ILogger<LibraryCatalogController> logger,
            LibraryCatalogRepository repository,
             IHttpContextAccessor accessor) : base(logger, repository, accessor)
        {
        }

        /// <summary>
        /// 添加LibraryCatalog
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public override async Task<ActionResult<LibraryCatalog>> AddAsync([FromBody] LibraryCatalogAddDto form)
        {
            // if (_repos.Any(e => e.Name == form.Name))
            // {
            //     return Conflict();
            // }
            return await _repos.AddAsync(form);
        }

        /// <summary>
        /// 分页筛选LibraryCatalog
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpPost("filter")]
        public override async Task<ActionResult<PageResult<LibraryCatalogDto>>> FilterAsync(LibraryCatalogFilter filter)
        {
            return await _repos.GetListWithPageAsync(filter);
        }

        /// <summary>
        /// 更新LibraryCatalog
        /// </summary>
        /// <param name="id"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public override async Task<ActionResult<LibraryCatalog>> UpdateAsync([FromRoute] Guid id, [FromBody] LibraryCatalogUpdateDto form)
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
        /// 删除LibraryCatalog
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public override Task<ActionResult<LibraryCatalog>> DeleteAsync([FromRoute] Guid id)
        {
            return base.DeleteAsync(id);
        }

        /// <summary>
        /// 获取LibraryCatalog详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public override Task<ActionResult<LibraryCatalog>> GetDetailAsync([FromRoute] Guid id)
        {
            return base.GetDetailAsync(id);
        }
    }
}