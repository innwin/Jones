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
        public static IEnumerable<TAttribute>? GetAttributes<TAttribute>(this Type type, string fieldName) => 
            type.GetProperties()
                .FirstOrDefault(p => p.Name == fieldName)?
                .GetCustomAttributes(typeof(TAttribute), false)
                .Cast<TAttribute>();

        #region accessor

        public static IEnumerable<TAttribute>? GetAttributes<TAttribute>(this Expression<Func<dynamic?>> accessor)
            where TAttribute : Attribute
        {
            var fieldIdentifier = FieldIdentifier.Create(accessor);

            return fieldIdentifier.Model.GetType()
                .GetProperties()
                .FirstOrDefault(p => p.Name == fieldIdentifier.FieldName)?
                .GetCustomAttributes(typeof(TAttribute), false)
                .Cast<TAttribute>();
        }
        
        public static TAttribute? GetAttribute<TAttribute>(this Expression<Func<dynamic?>> accessor)
            where TAttribute : Attribute =>
            accessor.GetAttributes<TAttribute>()?.FirstOrDefault();

        public static string? GetDescription(this Expression<Func<dynamic?>> accessor) =>
            accessor.GetAttribute<DescriptionAttribute>()?.Description;

        public static string? GetCategory(this Expression<Func<dynamic?>> accessor) =>
            accessor.GetAttribute<CategoryAttribute>()?.Category;

        public static DisplayAttribute? GetDisplay(this Expression<Func<dynamic?>> accessor) =>
            accessor.GetAttribute<DisplayAttribute>();

        public static string? GetDisplayShortName(this Expression<Func<dynamic?>> accessor) =>
            accessor.GetDisplay()?.ShortName;

        public static string? GetDisplayName(this Expression<Func<dynamic?>> accessor) =>
            accessor.GetDisplay()?.Name;

        public static string? GetDisplayPrompt(this Expression<Func<dynamic?>> accessor) => 
            accessor.GetDisplay()?.Prompt;
        
        public static IEnumerable<TAttribute>? GetFieldAttributes<TAttribute>(this Expression<Func<dynamic?>> accessor)
            where TAttribute : Attribute
        {
            var fieldIdentifier = FieldIdentifier.Create(accessor);
            
            return fieldIdentifier.Model.GetType()
                .GetField(fieldIdentifier.FieldName)?
                .GetCustomAttributes(typeof(TAttribute), false)
                .Cast<TAttribute>();
        }
        
        public static TAttribute? GetFieldAttribute<TAttribute>(this Expression<Func<dynamic?>> accessor)
            where TAttribute : Attribute =>
            accessor.GetFieldAttributes<TAttribute>()?.FirstOrDefault();
        
        public static string? GetFieldDescription(this Expression<Func<dynamic?>> accessor) =>
            accessor.GetFieldAttribute<DescriptionAttribute>()?.Description;

        public static string? GetFieldCategory(this Expression<Func<dynamic?>> accessor) =>
            accessor.GetFieldAttribute<CategoryAttribute>()?.Category;

        public static DisplayAttribute? GetFieldDisplay(this Expression<Func<dynamic?>> accessor) =>
            accessor.GetFieldAttribute<DisplayAttribute>();

        public static string? GetFieldDisplayShortName(this Expression<Func<dynamic?>> accessor) =>
            accessor.GetFieldDisplay()?.ShortName;

        public static string? GetFieldDisplayName(this Expression<Func<dynamic?>> accessor) =>
            accessor.GetFieldDisplay()?.Name;

        public static string? GetFieldDisplayPrompt(this Expression<Func<dynamic?>> accessor) =>
            accessor.GetFieldDisplay()?.Prompt;
        
        public static bool IsHasAttribute<TAttribute>(this Expression<Func<dynamic?>> accessor)
            where TAttribute : Attribute => 
            accessor.GetAttribute<TAttribute>() != null;

        public static bool IsHasRequiredAttribute(this Expression<Func<dynamic?>> accessor) => 
            accessor.IsHasAttribute<RequiredAttribute>();

        #endregion
        
        #region keySelector

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

        #endregion
    }
}