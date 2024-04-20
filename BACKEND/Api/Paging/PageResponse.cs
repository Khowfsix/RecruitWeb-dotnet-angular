using PagedList;

namespace Api.Paging
{
    public class PageResponse<T>
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalMatchedInDb { get; set; }
        public List<T> Items { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
        public bool IsFirstPage { get; set; }
        public bool IsLastPage { get; set; }

        public PageResponse(IPagedList<T>? paged) {
            this.PageIndex = paged!.PageNumber;
            this.PageSize = paged.PageSize;
            this.TotalPages = paged.PageCount;
            this.TotalMatchedInDb = paged.TotalItemCount;
            this.Items = paged.ToList();
            this.HasNextPage = paged.HasNextPage;
            this.HasPreviousPage = paged.HasPreviousPage;
            this.IsLastPage = paged.IsLastPage;
            this.IsFirstPage = paged.IsFirstPage;
        }

        //public PageResponse(List<T> items, int totalMatchedInDb, int pageIndex, int pageSize)
        //{
        //    PageIndex = pageIndex;
        //    TotalPages = (int)Math.Ceiling(totalMatchedInDb / (double)pageSize);
        //    PageSize = pageSize;
        //    Items = items;
        //    TotalMatchedInDb = totalMatchedInDb;
        //    //this.AddRange(items);
        //}

        //public static async Task<PageResponse<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        //{
        //    var count = await source.CountAsync();
        //    var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        //    return new PageResponse<T>(items, count, pageIndex, pageSize);
        //}
    }
}