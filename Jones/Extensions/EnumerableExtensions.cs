using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jones.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return source == null || !source.Any();
        }

        public static string ToString<T>(this IEnumerable<T> source, string separated) =>
            source.AsParallel().Select(p => p.ToString()).Aggregate((total, next) => $"{total}{separated}{next}");
    }
}