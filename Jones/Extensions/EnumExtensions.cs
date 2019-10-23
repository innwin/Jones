using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

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
    }
}