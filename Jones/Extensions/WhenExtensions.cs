using System;

namespace Jones.Extensions
{
    public static class WhenExtensions
    {
        public static void When<T>(this T source, Func<T, bool> predicate, Action<T> action)
        {
            if (predicate.Invoke(source))
            {
                action.Invoke(source);
            }
        }
        
        public static void WhenTrue(this bool source, Action action)
        {
            if (source)
            {
                action.Invoke();
            }
        }

        public static void WhenFalse(this bool source, Action action)
        {
            if (!source)
            {
                action.Invoke();
            }
        }
    }
}