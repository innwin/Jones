namespace Jones
{
    public class PagingParams<TP, TK>
    {
        public TP Params { get; set; }
        public TK NextPage { get; set; }
        public int? PageSize { get; set; }
        public TK PreviousPage { get; set; }
        public bool? IsLoadPrevious { get; set; }

        public PagingParams()
        {
            
        }

        public PagingParams(TP @params, TK nextPage, int? pageSize, TK previousPage = default, bool? isLoadPrevious = null)
        {
            Params = @params;
            NextPage = nextPage;
            PageSize = pageSize;
            PreviousPage = previousPage;
            IsLoadPrevious = isLoadPrevious;
        }
    }

    public class PagingParams<TP> : PagingParams<TP, int?>
    {
        public PagingParams()
        {
            
        }
        public PagingParams(TP @params, int? nextPage, int? pageSize, int? previousPage = null, bool? isLoadPrevious = null) : base(@params, nextPage, pageSize, previousPage, isLoadPrevious)
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

        public Paging(int page, int pageSize, int totalCount)
        {
            Page = page;
            PageSize = pageSize;
            TotalCount = totalCount;
            
            if (PageSize > 0)
            {
                TotalPages = TotalCount / PageSize;
                if (TotalCount % PageSize > 0)
                {
                    TotalPages += 1;
                }
            }
        }
    }

    public class Paging<T, TK> : Paging
    {
        public T[]? Items { get; set; }
        public TK NextPage { get; set; }
        public TK PreviousPage { get; set; }

        public Paging()
        {
            
        }

        public Paging(T[]? items, TK nextPage, TK previousPage, int page, int pageSize, int totalCount) : base(page, pageSize, totalCount)
        {
            Items = items;
            NextPage = nextPage;
            PreviousPage = previousPage;
        }
    }

    public class Paging<T> : Paging<T, int?>
    {
        public Paging()
        {
            
        }
        
        public Paging(T[]? items, int page, int pageSize, int totalCount) : 
            base(items, null, null, page, pageSize, totalCount)
        {
            NextPage = page == TotalPages ? null : (int?) (page + 1);
            PreviousPage = page == 1 || TotalPages == 1 ? null : (int?) (page - 1);
        }
    }
}