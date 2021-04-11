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
    /// EntityModel
    /// </summary>
    [OpenApiTag("EntityModel", Description = "EntityModel")]
    public class EntityModelController : ApiController<EntityModelRepository, EntityModel, EntityModelAddDto, EntityModelUpdateDto, EntityModelFilter, EntityModelDto>
    {
        public EntityModelController(
            ILogger<EntityModelController> logger,
            EntityModelRepository repository) : base(logger, repository)
        {
        }

        /// <summary>
        /// 添加EntityModel
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public override async Task<ActionResult<EntityModel>> AddAsync([FromBody] EntityModelAddDto form)
        {
            // if (_repos.Any(e => e.Name == form.Name))
            // {
            //     return Conflict();
            // }
            return await _repos.AddAsync(form);
        }

        /// <summary>
        /// 分页筛选EntityModel
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpPost("filter")]
        public override async Task<ActionResult<PageResult<EntityModelDto>>> FilterAsync(EntityModelFilter filter)
        {
            return await _repos.GetListWithPageAsync(filter);
        }

        /// <summary>
        /// 更新EntityModel
        /// </summary>
        /// <param name="id"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public override async Task<ActionResult<EntityModel>> UpdateAsync([FromRoute] Guid id, [FromBody] EntityModelUpdateDto form)
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