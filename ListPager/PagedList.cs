using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListPager
{
    public class PagedList<T>
    {
        public List<T>? Items { get; private set; }
        public int TotalCount{ get; private set; }
        public int PageNumber { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages { get; private set; }

        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            Items = items;
            TotalCount = count; 
            PageNumber = pageNumber; 
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }

        public bool HasPreviousPage => PageNumber > 1; 
        public bool HasNextPage => PageNumber < TotalCount;

        public static PagedList<T> ToPagedList(IQueryable<T> source , int pageSize ,  int pageNumber)
        {
            var count = source.Count();

            var items = source
                .Skip((pageNumber -1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
       
    }
}
