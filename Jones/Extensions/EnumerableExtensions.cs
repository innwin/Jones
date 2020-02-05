using System;
using System.Collections.Generic;
using System.Linq;

namespace Jones.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T>? source)
        {
            return source == null || !source.Any();
        }

        public static string? ToString<T>(this IEnumerable<T>? source, string separator) => 
            string.Join(separator, source);
            // source?.AsParallel().Select(p => p?.ToString() ?? string.Empty).Aggregate((total, next) => $"{total}{separated}{next}");
    }
}