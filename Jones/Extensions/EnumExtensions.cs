using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Jones.Extensions
{
    public static class EnumExtensions
    {
        [return: MaybeNull]
        public static T GetAttribute<T>(this Enum enumSubItem) where T : Attribute
        {
            return enumSubItem
                .GetType()
                .GetField(enumSubItem.ToString())
                .GetCustomAttributes(typeof(T), false)
                .Cast<T>()
                .FirstOrDefault();
        }

        public static string? GetDescription(this Enum enumSubItem)
        {
            return enumSubItem.GetAttribute<DescriptionAttribute>()?.Description;
        }

        public static string? GetCategory(this Enum enumSubItem)
        {
            return enumSubItem.GetAttribute<CategoryAttribute>()?.Category;
        }
        
        [return: MaybeNull]
        public static T GetEnumAttribute<T>(this Enum enumSubItem) where T : Attribute
        {
            return enumSubItem
                .GetType()
                .GetCustomAttributes(typeof(T), false)
                .Cast<T>()
                .FirstOrDefault();
        }

        public static string? GetEnumDescription(this Enum enumSubItem)
        {
            return enumSubItem.GetEnumAttribute<DescriptionAttribute>()?.Description;
        }

        public static string? GetEnumCategory(this Enum enumSubItem)
        {
            return enumSubItem.GetEnumAttribute<CategoryAttribute>()?.Category;
        }

        public static string? GetEnumDescriptionAndCategory(this Enum enumSubItem)
        {
            var description = enumSubItem.GetEnumDescription();
            var category = enumSubItem.GetEnumCategory();
            if (description == null && category == null)
            {
                return null;
            }
            
            var stringBuilder = new StringBuilder();
            if (description != null)
            {
                stringBuilder.Append(description);
            }

            if (category != null)
            {
                if (stringBuilder.Length > 0)
                {
                    stringBuilder.Append(" : ");
                }
                stringBuilder.Append(category);
            }
            return stringBuilder.ToString();
        }
    }
}