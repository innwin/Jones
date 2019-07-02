using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jones.Extensions
{
    public static class CollectionExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return source == null || !source.Any();
        }
        
        public static string ToString<T>(this IEnumerable<T> source, string separated)
        {
            var enumerable = source as T[] ?? source.ToArray();
            if (enumerable.IsNullOrEmpty())
            {
                return null;
            }
            var resultSbr = new StringBuilder();
            foreach (var data in enumerable)
            {
                if (resultSbr.Length == 0)
                    resultSbr.Append(data);
                else
                    resultSbr.Append(separated).Append(data);
            }
            return resultSbr.ToString();
        }
    }
}