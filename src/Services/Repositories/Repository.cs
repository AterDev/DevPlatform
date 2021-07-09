using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Agreement;
using Share.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Data.Common;

namespace Services.Repositories
{
    /// <summary>
    /// Guid为主键的仓储实现，包含了列表查询基础实现
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TAddForm"></typeparam>
    /// <typeparam name="TUpdatedForm"></typeparam>
    /// <typeparam name="TFilter"></typeparam>
    /// <typeparam name="TDto"></typeparam>
    public class Repository<TEntity, TAddForm, TUpdatedForm, TFilter, TDto> :
        RepositoryBase<ContextBase, TEntity, TAddForm, TUpdatedForm, TFilter, TDto, Guid>
        where TEntity : BaseDB
        where TFilter : FilterBase
    {
        public Repository(ContextBase context, IMapper mapper) : base(context, mapper)
        {
        }

        /// <summary>
        /// 默认添加
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public override async Task<TEntity> AddAsync(TAddForm form)
        {
            var data = _mapper.Map<TAddForm, TEntity>(form);
            _db.Add(data);
            await _context.SaveChangesAsync();
            return data;
        }

        /// <summary>
        /// 删除，有关联的重写该方法
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override async Task<TEntity> DeleteAsync(Guid id)
        {
            var data = await _db.FindAsync(id);
            _db.Remove(data);
            await _context.SaveChangesAsync();
            return data;
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Exist<TUnique>(TUnique entity)
        {
            Expression body = null;
            var type = typeof(TUnique);
            var notNullProps = type.GetProperties()
                .Where(p => p.GetValue(entity) != null)
                .ToList();

            var parameter = Expression.Parameter(type, "debug");

            notNullProps.ForEach(prop =>
            {
                var memberExpression = Expression.Property(parameter, prop.Name);
                var equalValue = Expression.Constant(prop.GetValue(entity));

                var equal = Expression.Equal(equalValue, memberExpression);
                body = body == null ? equal : Expression.AndAlso(body, equal);
            });
            if (body != null)
            {
                var conditions = Expression.Lambda<Func<TEntity, bool>>(body, new[] { parameter });
                return _db.Any(conditions);
            }
            return false;
        }

        public override async Task<TEntity> GetDetailAsync(Guid id)
        {
            var data = await _db.FindAsync(id);
            return data;
        }

        public override async Task<List<TDto>> GetListAsync(TFilter filter)
        {
            return await _query.OrderByDescending(d => d.CreatedTime)
              .Skip((filter.PageIndex - 1) * filter.PageSize)
              .Take(filter.PageSize)
              .ProjectTo<TDto>(_mapper.ConfigurationProvider)
              .ToListAsync();
        }

        /// <summary>
        /// 分页,筛选功能需重写实现
        /// </summary>
        /// <param name="filter">筛选模型</param>
        /// <returns></returns>
        public override async Task<PageResult<TDto>> GetListWithPageAsync(TFilter filter)
        {
            var count = _query.Count();
            if (filter.PageIndex < 1) filter.PageIndex = 1;
            if (filter.PageSize < 0) filter.PageSize = 0;
            var data = await _query.Skip((filter.PageIndex - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ProjectTo<TDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
            return new PageResult<TDto>
            {
                Count = count,
                Data = data,
                PageIndex = filter.PageIndex
            };
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="id"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        public override async Task<TEntity> UpdateAsync(Guid id, TUpdatedForm form)
        {
            var currentData = await _db.FindAsync(id);
            _mapper.Map(form, currentData);
            await _context.SaveChangesAsync();
            return currentData;
        }
    }
}
