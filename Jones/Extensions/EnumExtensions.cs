using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Jones.Extensions
{
    public static class EnumExtensions
    {
        public static T? GetAttribute<T>(this Enum enumSubItem) where T : Attribute
        {
            return enumSubItem
                .GetType()
                .GetField(enumSubItem.ToString())?
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

        public static DisplayAttribute? GetDisplay(this Enum enumSubItem)
        {
            return enumSubItem.GetAttribute<DisplayAttribute>();
        }

        public static string? GetDisplayShortName(this Enum enumSubItem)
        {
            return enumSubItem.GetDisplay()?.ShortName;
        }

        public static string? GetDisplayName(this Enum enumSubItem)
        {
            return enumSubItem.GetDisplay()?.Name;
        }

        public static string? GetDisplayPrompt(this Enum enumSubItem)
        {
            return enumSubItem.GetDisplay()?.Prompt;
        }
        
        public static T? GetEnumAttribute<T>(this Enum enumSubItem) where T : Attribute
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

        public static DisplayAttribute? GetEnumDisplay(this Enum enumSubItem)
        {
            return enumSubItem.GetEnumAttribute<DisplayAttribute>();
        }

        public static string? GetEnumDisplayShortName(this Enum enumSubItem)
        {
            return enumSubItem.GetEnumDisplay()?.ShortName;
        }

        public static string? GetEnumDisplayName(this Enum enumSubItem)
        {
            return enumSubItem.GetEnumDisplay()?.Name;
        }

        public static string? GetEnumDisplayPrompt(this Enum enumSubItem)
        {
            return enumSubItem.GetEnumDisplay()?.Prompt;
        }


        public static string ToRoleString<T>(this IEnumerable<T> enums) where T : Enum =>
            string.Join(",", enums.Select(p => p.ToString()));
    }
}