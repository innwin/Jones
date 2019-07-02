namespace Jones.Helper
{
    public static class PagingHelper
    {
        public static Paging<T> GetPaging<T>(T[] items, int pageIndex, int pageSize, int totalCount, int totalPages)
        {
            var page = pageIndex + 1;
            return new Paging<T>(items, totalPages > page ? (int?)(page + 1) : null, null, page, pageSize, totalCount, totalPages);
        }
    }
}