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
using NSwag.Annotations;
using Services.Agreement;

namespace App.Api.Controllers
{
    /// <summary>
    /// 评论
    /// </summary>
    [OpenApiTag("Comment",Description ="评论")]
    public class CommentController : ApiController<CommentRepository, Comment, CommentAddDto, CommentUpdateDto, CommentFilter, CommentDto>
    {
        public CommentController(
            ILogger<CommentController> logger,
            CommentRepository repository,
             IUserContext accessor) : base(logger, repository, accessor)
        {
        }

        /// <summary>
        /// 添加Comment
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public override async Task<ActionResult<Comment>> AddAsync([FromBody] CommentAddDto form)
        {
            // if (_repos.Any(e => e.Name == form.Name))
            // {
            //     return Conflict();
            // }
            return await _repos.AddAsync(form);
        }

        /// <summary>
        /// 分页筛选Comment
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpPost("filter")]
        public override async Task<ActionResult<PageResult<CommentDto>>> FilterAsync(CommentFilter filter)
        {
            return await _repos.GetListWithPageAsync(filter);
        }

        /// <summary>
        /// 更新Comment
        /// </summary>
        /// <param name="id"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public override async Task<ActionResult<Comment>> UpdateAsync([FromRoute] Guid id, [FromBody] CommentUpdateDto form)
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
        /// 删除Comment
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public override Task<ActionResult<Comment>> DeleteAsync([FromRoute] Guid id)
        {
            return base.DeleteAsync(id);
        }

        /// <summary>
        /// 获取Comment详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public override Task<ActionResult<Comment>> GetDetailAsync([FromRoute] Guid id)
        {
            return base.GetDetailAsync(id);
        }
    }
}