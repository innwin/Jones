using System.ComponentModel;
using System.Linq;
using Jones.Extensions;

namespace Jones
{
    public enum ResultCodeType
    {
        [Description("成功")]
        Success = 200,    // Ok
        
        [Description("客户端请求错误")]
        BadRequest = 400,
        [Description("未授权")]
        Unauthorized = 401,
        [Description("禁止操作")]
        Forbidden = 403,
        [Description("未发现资源")]
        NotFound = 404,
        [Description("有冲突")]
        Conflict = 409,
        
        [Description("服务器发生了错误")]
        InternalServerError = 500,
        
        [Description("余额不足")]
        InsufficientBalance = 901
    }
    
    public record Result
    {
        public bool IsSuccess => Code == ResultCodeType.Success;
        public ResultCodeType Code { get; }
        public string? Msg { get; }
        
        public static Result CreateSuccess(string? msg = null) => new (true, msg);
        
        public static Result CreateError(string? msg = null) => new (false, msg);
        public static Result CreateError(ResultCodeType resultCodeType) => new (resultCodeType);
        public static Result CreateError(string msg, ResultCodeType resultCodeType) => new (msg, resultCodeType);
        
        public static Result Create(Result result) => new(result);
        
        public Result(ResultCodeType resultCodeType) : this(resultCodeType.GetDescription(), resultCodeType) { }
        public Result(string? msg, ResultCodeType resultCodeType)
        {
            Code = resultCodeType;
            Msg = msg;
        }

        protected Result(bool isSuccess, string? msg = null)
        {
            Code = isSuccess ? ResultCodeType.Success : ResultCodeType.InternalServerError;
            Msg = msg;
        }

        protected Result(Result result)
        {
            Code = result.IsSuccess ? ResultCodeType.Success : ResultCodeType.InternalServerError;
            Msg = result.Msg;
        }
    }

    public record Result<T> : Result
    {
        public T? Data { get; }
        
        public new static Result<T> CreateSuccess(string? msg = null) => new (true, msg);
        public static Result<T> CreateSuccess(T? data, string? msg = null) => new (data, msg);
        
        public new static Result<T> CreateError(string? msg) => new(false, msg);
        public new static Result<T> CreateError(ResultCodeType resultCodeType) => new(resultCodeType);
        public new static Result<T> CreateError(string msg, ResultCodeType resultCodeType) => new(msg, resultCodeType);
        
        public new static Result<T> Create(Result result) => new(result);
        
        public Result(string msg, ResultCodeType resultCodeType) : base(msg, resultCodeType) { }
        public Result(ResultCodeType resultCodeType) : base(resultCodeType) { }

        protected Result(bool isSuccess, string? msg = null, T? data = default) : base(isSuccess, msg)
        {
            Data = data;
        }

        protected Result(bool isSuccess, T? data) : base(isSuccess)
        {
            Data = data;
        }
        protected Result(T? data, string? msg = null) : base(true, msg)
        {
            Data = data;
        }

        protected Result(Result result, T? data = default) : base(result.Msg, result.Code)
        {
            Data = data;
        }

        public bool IsHasContent => Data != null;
    }

    public record PagingResult<Tk, T> : Result<Paging<Tk, T>>
    {
        public new static PagingResult<Tk, T> CreateSuccess(string? msg = null) => new (true, msg);
        public new static PagingResult<Tk, T> CreateSuccess(Paging<Tk, T>? data, string? msg = null) => new (data, msg);
        
        public new static PagingResult<Tk, T> CreateError(string? msg) => new(false, msg);
        public new static PagingResult<Tk, T> CreateError(ResultCodeType resultCodeType) => new(resultCodeType);
        public new static PagingResult<Tk, T> CreateError(string msg, ResultCodeType resultCodeType) => new(msg, resultCodeType);
        
        public new static PagingResult<Tk, T> Create(Result result) => new(result);
        
        public PagingResult(string msg, ResultCodeType resultCodeType) : base(msg, resultCodeType)
        {
        }

        public PagingResult(ResultCodeType resultCodeType) : base(resultCodeType)
        {
        }

        protected PagingResult(bool isSuccess, string? msg = null, Paging<Tk, T>? data = default) : base(isSuccess, msg, data)
        {
        }

        protected PagingResult(bool isSuccess, Paging<Tk, T>? data) : base(isSuccess, data)
        {
        }

        protected PagingResult(Paging<Tk, T>? data, string? msg = null) : base(data, msg)
        {
        }

        protected PagingResult(Result result, Paging<Tk, T>? data = default) : base(result, data)
        {
        }
        
        public new bool IsHasContent => Data?.Items.Any() == true;
    }

    public record PagingResult<T> : Result<Paging<T>>
    {
        public new static PagingResult<T> CreateSuccess(string? msg = null) => new (true, msg);
        public new static PagingResult<T> CreateSuccess(Paging<T>? data, string? msg = null) => new (data, msg);
        
        public new static PagingResult<T> CreateError(string? msg) => new(false, msg);
        public new static PagingResult<T> CreateError(ResultCodeType resultCodeType) => new(resultCodeType);
        public new static PagingResult<T> CreateError(string msg, ResultCodeType resultCodeType) => new(msg, resultCodeType);
        
        public new static PagingResult<T> Create(Result result) => new(result);
        
        public PagingResult(string msg, ResultCodeType resultCodeType) : base(msg, resultCodeType)
        {
        }

        public PagingResult(ResultCodeType resultCodeType) : base(resultCodeType)
        {
        }

        protected PagingResult(bool isSuccess, string? msg = null, Paging<T>? data = default) : base(isSuccess, msg, data)
        {
        }

        protected PagingResult(bool isSuccess, Paging<T>? data) : base(isSuccess, data)
        {
        }

        protected PagingResult(Paging<T>? data, string? msg = null) : base(data, msg)
        {
        }

        protected PagingResult(Result result, Paging<T>? data = default) : base(result, data)
        {
        }
        
        public new bool IsHasContent => Data?.Items.Any() == true;
    }
}
