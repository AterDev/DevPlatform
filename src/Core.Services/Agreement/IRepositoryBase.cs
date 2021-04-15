using Share.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Agreement
{
    /// <summary>
    /// 仓储接口
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TAddForm">实体添加时对象</typeparam>
    /// <typeparam name="TUpdateForm">实体更新时对象</typeparam>
    /// <typeparam name="TFilter">筛选对象</typeparam>
    /// <typeparam name="TDto">返回信息对象</typeparam>
    /// <typeparam name="Tkey">主键类型</typeparam>
    public interface IRepositoryBase<TEntity, TAddForm, TUpdateForm, TFilter, TDto, Tkey>
    {
        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> GetDetailAsync(Tkey id);
        /// <summary>
        /// 列表筛选
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<List<TDto>> GetListAsync(TFilter filter);
        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<PageResult<TDto>> GetListWithPageAsync(TFilter filter);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> DeleteAsync(Tkey id);
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        Task<TEntity> AddAsync(TAddForm form);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        Task<TEntity> UpdateAsync(Tkey id, TUpdateForm form);
        /// <summary>
        /// 判断实体是否存在
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        Task<TEntity> Exist(object o);

    }
}
