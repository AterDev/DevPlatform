using Core.Entity;
using GT.Agreement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSwag.Annotations;
using Core.Services;
using Core.Services.Models;
using Core.Services.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace App.Api.Controllers
{
    /// <summary>
    /// Lib
    /// </summary>
    [OpenApiTag("Lib", Description = "Lib")]
    public class LibController : ApiController<LibRepository, Lib, LibAddDto, LibUpdateDto, LibFilter, LibDto>
    {
        public LibController(
            ILogger<LibController> logger,
            LibRepository repository) : base(logger, repository)
        {
        }

        /// <summary>
        /// 添加Lib
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public override async Task<ActionResult<Lib>> AddAsync([FromBody] LibAddDto form)
        {
            // if (_repos.Any(e => e.Name == form.Name))
            // {
            //     return Conflict();
            // }
            return await _repos.AddAsync(form);
        }

        /// <summary>
        /// 分页筛选Lib
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpPost("filter")]
        public override async Task<ActionResult<PageResult<LibDto>>> FilterAsync(LibFilter filter)
        {
            return await _repos.GetListWithPageAsync(filter);
        }

        /// <summary>
        /// 更新Lib
        /// </summary>
        /// <param name="id"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public override async Task<ActionResult<Lib>> UpdateAsync([FromRoute] Guid id, [FromBody] LibUpdateDto form)
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
    }
}