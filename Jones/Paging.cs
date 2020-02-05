namespace Jones
{
    public class PagingParams<TP, TK>
    {
        public TP Params { get; set; }
        public TK NextPageKey { get; set; }
        public int? PageSize { get; set; }
        public TK PreviousPageKey { get; set; }
        public bool? IsLoadPrevious { get; set; }

        public PagingParams()
        {
            
        }

        public PagingParams(TP @params, TK nextPageKey, int? pageSize, TK previousPageKey = default, bool? isLoadPrevious = null)
        {
            Params = @params;
            NextPageKey = nextPageKey;
            PageSize = pageSize;
            PreviousPageKey = previousPageKey;
            IsLoadPrevious = isLoadPrevious;
        }
    }

    public class PagingParams<TP> : PagingParams<TP, int?>
    {
        public PagingParams()
        {
            
        }
        public PagingParams(TP @params, int? nextPageKey, int? pageSize, int? previousPageKey = null, bool? isLoadPrevious = null) : base(@params, nextPageKey, pageSize, previousPageKey, isLoadPrevious)
        {
        }
    }
    
    public class Paging
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }

        public Paging()
        {
            
        }

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
        public T[] Items { get; set; }
        public TK NextPageKey { get; set; }
        public TK PreviousPageKey { get; set; }

        public Paging()
        {
            
        }

        public Paging(T[] items, TK nextPageKey, TK previousPageKey, int page, int pageSize, int totalCount, int totalPages) : base(page, pageSize, totalCount, totalPages)
        {
            Items = items;
            NextPageKey = nextPageKey;
            PreviousPageKey = previousPageKey;
        }
    }

    public class Paging<T> : Paging<T, int?>
    {
        public Paging()
        {
            
        }
        
        public Paging(T[] items, int page, int pageSize, int totalCount, int totalPages) : 
            base(items, 
                page == pageSize ? null : (int?)(page + 1), 
                page == 1 || pageSize == 1 ? null : (int?)(page - 1), 
                page, pageSize, totalCount, totalPages)
        {
        }
    }
}