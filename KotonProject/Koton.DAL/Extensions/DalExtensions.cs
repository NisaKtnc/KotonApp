using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Koton.DAL.Extensions
{
    public static class DataLayerExtensions
    {
        //Veri erişim katmanını genişletmek için kullandığım bir uzantı.
        public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query,params Expression<Func<T, object>>[] includes)
    where T : class, new()
        {
            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }

            return query;
        }

        public static IQueryable<T> IncludeMultiple2<T>(this IQueryable<T> query, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
   where T : class, new()
        {
            if (include != null)
            {
                query = include(query);
            }

            return query;
        }
    }
}
