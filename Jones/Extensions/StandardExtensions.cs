using System;

namespace Jones.Extensions
{
    public static class StandardExtensions
    {
        // Kotlin: fun <T> T.also(block: (T) -> Unit): T
        public static T Also<T>(this T self, Action<T> block)
        {
            block(self);
            return self;
        }
        
        // Kotlin: fun <T, R> T.let(block: (T) -> R): R
        public static R Let<T, R>(this T self, Func<T, R> block) 
        {
            return block(self);
        }
    }
}