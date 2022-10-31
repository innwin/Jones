using System.Diagnostics.CodeAnalysis;

namespace Jones.Entities;

public record CheckData<T>(bool IsTrue, string? Message, T? Data)
{
    public bool CheckIsTrue([NotNullWhen(true)] out T? data)
    {
        data = Data;
        return IsTrue;
    }
}