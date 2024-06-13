using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace Koton.DAL.Extensions
{
    public static class DataLayerExtensions
    {
        //Veri erişim katmanını genişletmek için kullandığım bir uzantı.
        public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes)
    where T : class,new()
        {
            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }

            return query;
        }
    }
}
