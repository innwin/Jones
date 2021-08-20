using System;

namespace Jones
{
    public record PagingParams<Tk>
    {
        public Tk Page { get; }
        public int? PageSize { get; }

        public PagingParams(Tk page, int? pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }
    }

    public record PagingParams : PagingParams<int?>
    {
        public PagingParams(int? page, int? pageSize) : base(page, pageSize)
        {
        }
    }
    
    public record Paging
    {
        public int Page { get; }
        public int PageSize { get; }
        public int TotalCount { get; }
        public int TotalPages { get; }
        public string? EmptyTips { get; }

        public Paging(int page, int pageSize, int totalCount, string? emptyTips = null)
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
        
        public int? NextPage => Page >= TotalPages ? null : Page + 1;
        public int? PreviousPage => Page == 1 || TotalPages <= 1 ? null : Page - 1;
        
        public int StarPage => (Page - 1) * PageSize + 1;
        public int EndPage => Math.Min(Page * PageSize, TotalCount);
    }

    public record Paging<Tk, T>
    {
        public Tk Page { get; }
        
        public Tk? NextPage { get; }
        public Tk? PreviousPage { get; }
        public T[] Items { get; }
        public int PageSize { get; }
        public int TotalCount { get; }
        public int TotalPages { get; }
        public string? EmptyTips { get; }

        public Paging(Tk page, Tk? nextPage, Tk? previousPage, T[] items, int pageSize, int totalCount, string? emptyTips)
        {
            Page = page;
            NextPage = nextPage;
            PreviousPage = previousPage;
            Items = items;
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

    public record Paging<T> : Paging
    {
        public T[] Items { get; }

        public Paging(T[] items, int page, int pageSize, int totalCount, string? emptyTips = null) : base(page, pageSize, totalCount, emptyTips)
        {
            Items = items;
        }
    }
}