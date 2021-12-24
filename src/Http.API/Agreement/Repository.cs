﻿using Infrastructure.Data.Models;

namespace App.Api.Agreement;

public class Repository<TContext, TEntity, TAddForm, TUpdateForm, TFilter, TDto, T>
    where TContext : DbContext
    where TEntity : BaseDB
    where TFilter : FilterBase
{
}