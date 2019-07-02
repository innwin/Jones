namespace Jones
{
    public class PagingDto<TP, TK>
    {
        public TP Params { get; }
        public TK NextPageKey { get; }
        public int? PageSize { get; set; }
        public TK PreviousPageKey { get; }
        public bool? IsLoadPrevious { get; }

        public PagingDto(TP @params, TK nextPageKey, int? pageSize, TK previousPageKey = default, bool? isLoadPrevious = null)
        {
            Params = @params;
            NextPageKey = nextPageKey;
            PageSize = pageSize;
            PreviousPageKey = previousPageKey;
            IsLoadPrevious = isLoadPrevious;
        }
    }

    public class PagingDto<TP> : PagingDto<TP, int?>
    {
        public PagingDto(TP @params, int? nextPageKey, int? pageSize, int? previousPageKey = null, bool? isLoadPrevious = null) : base(@params, nextPageKey, pageSize, previousPageKey, isLoadPrevious)
        {
        }
    }
    
    public class Paging
    {
        public int Page { get; }
        public int PageSize { get; }
        public int TotalCount { get; }
        public int TotalPages { get; }

        public Paging(int page, int pageSize, int totalCount, int totalPages)
        {
            Page = page;
            PageSize = pageSize;
            TotalCount = totalCount;
            TotalPages = totalPages;
        }
    }

    public class Paging<T, TK> : Paging
    {
        public T[] Items { get; }
        public TK NextPageKey { get; }
        public TK PreviousPageKey { get; }

        public Paging(T[] items, TK nextPageKey, TK previousPageKey, int page, int pageSize, int totalCount, int totalPages) : base(page, pageSize, totalCount, totalPages)
        {
            Items = items;
            NextPageKey = nextPageKey;
            PreviousPageKey = previousPageKey;
        }
    }

    public class Paging<T> : Paging<T, int?>
    {
        public Paging(T[] items, int? nextPageKey, int? previousPageKey, int page, int pageSize, int totalCount, int totalPages) : base(items, nextPageKey, previousPageKey, page, pageSize, totalCount, totalPages)
        {
        }
    }
}