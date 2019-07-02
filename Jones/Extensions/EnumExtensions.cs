using System;
using System.ComponentModel;
using System.Linq;

namespace Jones.Extensions
{
    public static class EnumExtensions
    {
        public static T GetAttribute<T>(this Enum enumSubItem) where T : Attribute
        {
            return enumSubItem
                .GetType()
                .GetField(enumSubItem.ToString())
                .GetCustomAttributes(typeof(T), false)
                .Cast<T>()
                .FirstOrDefault();
        }

        public static string GetDescription(this Enum enumSubItem)
        {
            return enumSubItem.GetAttribute<DescriptionAttribute>()?.Description;
        }
        
        public static T GetEnumAttribute<T>(this Enum enumSubItem) where T : Attribute
        {
            return enumSubItem
                .GetType()
                .GetCustomAttributes(typeof(T), false)
                .Cast<T>()
                .FirstOrDefault();
        }

        public static string GetEnumDescription(this Enum enumSubItem)
        {
            return enumSubItem.GetEnumAttribute<DescriptionAttribute>()?.Description;
        }
    }
}