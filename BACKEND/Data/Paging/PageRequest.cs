namespace Data.Paging
{
    public class PageRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public PageRequest(int pageIndex, int pageSize)
        {
            this.PageIndex = pageIndex; 
            this.PageSize = pageSize;
        }
    }
}