namespace Jones.Extensions
{
    public static class PagingExtensions
    {
        public static PagingParams ToPagingParams<TP>(this PagingParams<TP> source)
        {
            return new PagingParams(source.Page, source.PageSize);
        }
    }
}