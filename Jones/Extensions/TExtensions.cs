using System;

namespace Jones.Extensions
{
    public static class TExtensions
    {
        public static bool IsNullable<T>(this T _) => Nullable.GetUnderlyingType(typeof(T)) != null;
    }
}