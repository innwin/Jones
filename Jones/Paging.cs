namespace Jones
{
    public class PagingParams
    {
        public int? Page { get; set; }
        public int? PageSize { get; set; }

        public PagingParams()
        {
            
        }

        public PagingParams(int? page, int? pageSize = null)
        {
            Page = page;
            PageSize = pageSize;
        }
    }
    
    public class PagingParams<TK, TP>
    {
        public TK Page { get; set; }
        public int? PageSize { get; set; }
        public TP Params { get; set; }

        public PagingParams()
        {
            
        }

        public PagingParams(TK page, int? pageSize, TP @params)
        {
            Params = @params;
            Page = page;
            PageSize = pageSize;
        }
    }

    public class PagingParams<TP> : PagingParams<int?, TP>
    {
        public PagingParams()
        {
            
        }
        public PagingParams(int? page, int? pageSize, TP @params) : base(page, pageSize, @params)
        {
        }
    }
    
    public class Paging
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public string EmptyTips { get; set; }

        public Paging()
        {
        }

        public Paging(int page, int pageSize, int totalCount, string emptyTips = null)
        {
            Page = page;
            PageSize = pageSize;
            TotalCount = totalCount;
            EmptyTips = emptyTips;

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

    public class Paging<TK, T> : Paging
    {
        public TK NextPage { get; set; }
        public TK PreviousPage { get; set; }
        public T[]? Items { get; set; }

        public Paging()
        {
            
        }

        public Paging(TK nextPage, TK previousPage, T[]? items, int page, int pageSize, int totalCount, string emptyTips = null) : 
            base(page, pageSize, totalCount, emptyTips)
        {
            NextPage = nextPage;
            PreviousPage = previousPage;
            Items = items;
        }
    }

    public class Paging<T> : Paging<int?, T>
    {
        public Paging()
        {
            
        }
        
        public Paging(T[]? items, int page, int pageSize, int totalCount, string emptyTips = null) : 
            base(null, null, items, page, pageSize, totalCount, emptyTips)
        {
            NextPage = page == TotalPages ? null : (int?) (page + 1);
            PreviousPage = page == 1 || TotalPages == 1 ? null : (int?) (page - 1);
        }
    }
}