using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListPager
{
    public static class QueryableExtensions
    {
        public static PagedList<T> ToPagedList<T>(this IQueryable<T> query, int pageNumber, int pageSize)
        {
            return PagedList<T>.ToPagedList(query, pageSize, pageNumber); // Corrected parameter order
        }

        // Extension method for IEnumerable<T>
        public static PagedList<T> ToPagedList<T>(this IEnumerable<T> enumerable, int pageNumber, int pageSize)
        {
            return PagedList<T>.ToPagedList(enumerable.AsQueryable(), pageSize, pageNumber); // Corrected parameter order
        }
    }
}
