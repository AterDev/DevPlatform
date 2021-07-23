using Entity;
using Microsoft.EntityFrameworkCore;
using Share.Models;

namespace App.Agreement
{
    public class Repository<TContext, TEntity, TAddForm, TUpdateForm, TFilter, TDto, T>
        where TContext : DbContext
        where TEntity : BaseDB
        where TFilter : FilterBase
    {
    }
}