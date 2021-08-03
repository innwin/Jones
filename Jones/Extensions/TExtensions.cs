using System;

namespace Jones.Extensions
{
    public static class TExtensions
    {
        public static bool IsNullable<T>(this T any)
        {
            if (any == null) return true; // obvious
            var type = typeof(T);
            if (!type.IsValueType) return true; // ref-type
            if (Nullable.GetUnderlyingType(type) != null) return true; // Nullable<T>
            return false; // value-type
        }
    }
}