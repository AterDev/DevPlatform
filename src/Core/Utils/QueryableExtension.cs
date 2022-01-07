using System.Linq.Expressions;

namespace Core.Utils;

public static class QueryableExtension
{

    /// <summary>
    /// select dto properties
    /// important: dto and entity property(name & type) must same
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"></exception>
    public static IQueryable<TResult> Select<TSource, TResult>(this IQueryable<TSource> source)
    {
        var sourceType = typeof(TSource);
        var resultType = typeof(TResult);
        var parameter = Expression.Parameter(sourceType, "e");

        var props = resultType.GetProperties().ToList();
        var bindings = props.Select(p =>
             Expression.Bind(p, Expression.PropertyOrField(parameter, p.Name))
        ).ToList();
        var body = Expression.MemberInit(Expression.New(resultType), bindings);
        var selector = Expression.Lambda(body, parameter);
        return source.Provider.CreateQuery<TResult>(
            Expression.Call(typeof(Queryable), "Select", new Type[] { sourceType, resultType },
                source.Expression, Expression.Quote(selector)));

    }

}
