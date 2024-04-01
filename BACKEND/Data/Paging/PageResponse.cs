using Microsoft.EntityFrameworkCore;

namespace Data.Paging
{
    public class PageResponse<T>
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalMatchedInDb { get; set; }

        public List<T> Items { get; set; }

        public PageResponse(List<T> items, int totalMatchedInDb, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(totalMatchedInDb / (double)pageSize);
            PageSize = pageSize;
            Items = items;
            TotalMatchedInDb = totalMatchedInDb;
            //this.AddRange(items);
        }

        public bool HasPreviousPage => PageIndex > 1;

        public bool HasNextPage => PageIndex < TotalPages;

        public static async Task<PageResponse<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PageResponse<T>(items, count, pageIndex, pageSize);
        }
    }
}