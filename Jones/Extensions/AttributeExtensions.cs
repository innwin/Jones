using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using Jones.Helper;

namespace Jones.Extensions
{
    public static class AttributeExtensions
    {
        public static IEnumerable<TAttribute>? GetAttributes<TAttribute, TSource>(this TSource source, Expression<Func<TSource, dynamic?>> keySelector)
            where TSource : class 
            where TAttribute : Attribute
        {
            string name = THelper.GetPropertyName(keySelector);

            return source
                .GetType()
                .GetProperties()
                .FirstOrDefault(p => p.Name == name)?
                .GetCustomAttributes(typeof(TAttribute), false)
                .Cast<TAttribute>();
        }
        
        public static TAttribute? GetAttribute<TAttribute, TSource>(this TSource source, Expression<Func<TSource, dynamic?>> keySelector) 
            where TSource : class 
            where TAttribute : Attribute =>
            source.GetAttributes<TAttribute, TSource>(keySelector)?.FirstOrDefault();

        public static string? GetDescription<TSource>(this TSource source, Expression<Func<TSource, dynamic?>> keySelector)
            where TSource : class
        {
            return source.GetAttribute<DescriptionAttribute, TSource>(keySelector)?.Description;
        }

        public static string? GetCategory<TSource>(this TSource source, Expression<Func<TSource, dynamic?>> keySelector)
            where TSource : class
        {
            return source.GetAttribute<CategoryAttribute, TSource>(keySelector)?.Category;
        }

        public static DisplayAttribute? GetDisplay<TSource>(this TSource source, Expression<Func<TSource, dynamic?>> keySelector)
            where TSource : class
        {
            return source.GetAttribute<DisplayAttribute, TSource>(keySelector);
        }

        public static string? GetDisplayShortName<TSource>(this TSource source, Expression<Func<TSource, dynamic?>> keySelector)
            where TSource : class
        {
            return source.GetDisplay(keySelector)?.ShortName;
        }

        public static string? GetDisplayName<TSource>(this TSource source, Expression<Func<TSource, dynamic?>> keySelector)
            where TSource : class
        {
            return source.GetDisplay(keySelector)?.Name;
        }

        public static string? GetDisplayPrompt<TSource>(this TSource source, Expression<Func<TSource, dynamic?>> keySelector)
            where TSource : class
        {
            return source.GetDisplay(keySelector)?.Prompt;
        }
        
        
        public static IEnumerable<TAttribute>? GetFieldAttributes<TAttribute, TSource>(this TSource source, Expression<Func<TSource, dynamic?>> keySelector) 
            where TSource : class 
            where TAttribute : Attribute
        {
            string name = THelper.GetPropertyName(keySelector);
            
            return source
                .GetType()
                .GetField(name)?
                .GetCustomAttributes(typeof(TAttribute), false)
                .Cast<TAttribute>();
        }
        
        public static TAttribute? GetFieldAttribute<TAttribute, TSource>(this TSource source, Expression<Func<TSource, dynamic?>> keySelector) 
            where TSource : class 
            where TAttribute : Attribute =>
            source.GetFieldAttributes<TAttribute, TSource>(keySelector)?.FirstOrDefault();
        
        public static string? GetFieldDescription<TSource>(this TSource source, Expression<Func<TSource, dynamic?>> keySelector)
            where TSource : class
        {
            return source.GetFieldAttribute<DescriptionAttribute, TSource>(keySelector)?.Description;
        }

        public static string? GetFieldCategory<TSource>(this TSource source, Expression<Func<TSource, dynamic?>> keySelector)
            where TSource : class
        {
            return source.GetFieldAttribute<CategoryAttribute, TSource>(keySelector)?.Category;
        }

        public static DisplayAttribute? GetFieldDisplay<TSource>(this TSource source, Expression<Func<TSource, dynamic?>> keySelector)
            where TSource : class
        {
            return source.GetFieldAttribute<DisplayAttribute, TSource>(keySelector);
        }

        public static string? GetFieldDisplayShortName<TSource>(this TSource source, Expression<Func<TSource, dynamic?>> keySelector)
            where TSource : class
        {
            return source.GetFieldDisplay(keySelector)?.ShortName;
        }

        public static string? GetFieldDisplayName<TSource>(this TSource source, Expression<Func<TSource, dynamic?>> keySelector)
            where TSource : class
        {
            return source.GetFieldDisplay(keySelector)?.Name;
        }

        public static string? GetFieldDisplayPrompt<TSource>(this TSource source, Expression<Func<TSource, dynamic?>> keySelector)
            where TSource : class
        {
            return source.GetFieldDisplay(keySelector)?.Prompt;
        }
        
        public static bool IsHasAttribute<TAttribute, TSource>(this TSource source, Expression<Func<TSource, dynamic?>> keySelector) 
            where TSource : class
            where TAttribute : Attribute => 
            source.GetAttribute<TAttribute, TSource>(keySelector) != null;

        public static bool IsHasRequiredAttribute<TSource>(this TSource source, Expression<Func<TSource, dynamic?>> keySelector) 
            where TSource : class => source.IsHasAttribute<RequiredAttribute, TSource>(keySelector);
    }
}