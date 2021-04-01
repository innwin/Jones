using System;
using System.Linq;
using Jones.Extensions;

namespace Jones
{
    public abstract record Result<Trc> where Trc : Enum
    {
        public abstract bool IsSuccess { get; }
        public Trc Code { get; }
        public string? Message { get; }

        public Result(Trc code) : this(code, code.GetDescription()) { }
        public Result(Trc code, string? message)
        {
            Code = code;
            Message = message;
        }
    }

    public abstract record Result<Trc, T> : Result<Trc> where Trc : Enum
    {
        public T? Data { get; }

        public Result(Trc code, string? message, T? data) : base(code, message)
        {
            Data = data;
        }

        public bool IsHasContent => Data != null;
    }

    public abstract record PagingResult<Trc, Tk, T> : Result<Trc, Paging<Tk, T>> where Trc : Enum
    {
        public PagingResult(Trc code, string? message, Paging<Tk, T>? data) : base(code, message, data)
        {
        }
        public new bool IsHasContent => Data?.Items.Any() == true;
    }

    public abstract record PagingResult<Trc, T> : Result<Trc, Paging<T>> where Trc : Enum
    {
        public PagingResult(Trc code, string? message, Paging<T>? data) : base(code, message, data)
        {
        }

        public new bool IsHasContent => Data?.Items.Any() == true;
    }
}
