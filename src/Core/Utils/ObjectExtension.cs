using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utils;

public static class ObjectExtension
{
    /// <summary>
    /// set source property value as merge type value,ignore null property
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TMerge"></typeparam>
    /// <param name="source"></param>
    /// <param name="merge"></param>
    /// <returns></returns>
    public static TSource Merge<TSource, TMerge>(this TSource source, TMerge merge)
    {
        // get merge properties(not null) and values
        var mergeProps = typeof(TMerge).GetProperties().ToList();
        mergeProps = mergeProps
            .Where(p => p.GetValue(merge) != null)
            .ToList();
        // set source properties's value
        mergeProps.ForEach(p =>
        {
            var sourceProp = typeof(TSource).GetProperty(p.Name);
            if (sourceProp != null)
                sourceProp.SetValue(source, p.GetValue(merge), null);
        });
        return source;
    }
}
