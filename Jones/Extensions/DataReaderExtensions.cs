using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;

namespace Jones.Extensions;

public static class DataReaderExtensions
{
    // https://github.com/zzzprojects/Z.ExtensionMethods/blob/master/src/Z.Data/System.Data.IDataReader/IDataReader.ToEntities.cs
    /// <summary>
    ///     Enumerates to entities in this collection.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="this">The @this to act on.</param>
    /// <returns>@this as an IEnumerable&lt;T&gt;</returns>
    public static IEnumerable<T> ToEntities<T>(this IDataReader @this) where T : new()
    {
        var type = typeof (T);
        var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);

        var list = new List<T>();

        var hash = new HashSet<string>(Enumerable.Range(0, @this.FieldCount).Select(@this.GetName));

        while (@this.Read())
        {
            var entity = new T();

            foreach (var property in properties)
            {
                if (!hash.Contains(property.Name.ToLower())) continue;
                
                var valueType = property.PropertyType;
                property.SetValue(entity, @this[property.Name.ToLower()].To(valueType), null);
            }

            foreach (var field in fields)
            {
                if (!hash.Contains(field.Name.ToLower())) continue;
                
                var valueType = field.FieldType;
                field.SetValue(entity, @this[field.Name.ToLower()].To(valueType));
            }

            list.Add(entity);
        }

        return list;
    }

    /// <summary>
    ///     A System.Object extension method that toes the given this.
    /// </summary>
    /// <param name="this">this.</param>
    /// <param name="type">The type.</param>
    /// <returns>An object.</returns>
    /// <example>
    ///     <code>
    ///       using System;
    ///       using Microsoft.VisualStudio.TestTools.UnitTesting;
    /// 
    /// 
    ///       namespace ExtensionMethods.Examples
    ///       {
    ///           [TestClass]
    ///           public class System_Object_To
    ///           {
    ///               [TestMethod]
    ///               public void To()
    ///               {
    ///                   string nullValue = null;
    ///                   string value = &quot;1&quot;;
    ///                   object dbNullValue = DBNull.Value;
    /// 
    ///                   // Exemples
    ///                   var result1 = value.To&lt;int&gt;(); // return 1;
    ///                   var result2 = value.To&lt;int?&gt;(); // return 1;
    ///                   var result3 = nullValue.To&lt;int?&gt;(); // return null;
    ///                   var result4 = dbNullValue.To&lt;int?&gt;(); // return null;
    /// 
    ///                   // Unit Test
    ///                   Assert.AreEqual(1, result1);
    ///                   Assert.AreEqual(1, result2.Value);
    ///                   Assert.IsFalse(result3.HasValue);
    ///                   Assert.IsFalse(result4.HasValue);
    ///               }
    ///           }
    ///       }
    /// </code>
    /// </example>
    /// <example>
    ///     <code>
    ///       using System;
    ///       using Microsoft.VisualStudio.TestTools.UnitTesting;
    ///       using Z.ExtensionMethods.Object;
    /// 
    ///       namespace ExtensionMethods.Examples
    ///       {
    ///           [TestClass]
    ///           public class System_Object_To
    ///           {
    ///               [TestMethod]
    ///               public void To()
    ///               {
    ///                   string nullValue = null;
    ///                   string value = &quot;1&quot;;
    ///                   object dbNullValue = DBNull.Value;
    /// 
    ///                   // Exemples
    ///                   var result1 = value.To&lt;int&gt;(); // return 1;
    ///                   var result2 = value.To&lt;int?&gt;(); // return 1;
    ///                   var result3 = nullValue.To&lt;int?&gt;(); // return null;
    ///                   var result4 = dbNullValue.To&lt;int?&gt;(); // return null;
    /// 
    ///                   // Unit Test
    ///                   Assert.AreEqual(1, result1);
    ///                   Assert.AreEqual(1, result2.Value);
    ///                   Assert.IsFalse(result3.HasValue);
    ///                   Assert.IsFalse(result4.HasValue);
    ///               }
    ///           }
    ///       }
    /// </code>
    /// </example>
    /// ###
    private static object? To(this object? @this, Type type)
    {
        if (@this == null) return @this;
        
        if (@this.GetType() == type)
        {
            return @this;
        }

        var converter = TypeDescriptor.GetConverter(@this);
        if (converter.CanConvertTo(type))
        {
            return converter.ConvertTo(@this, type);
        }

        converter = TypeDescriptor.GetConverter(type);
        if (converter.CanConvertFrom(@this.GetType()))
        {
            return converter.ConvertFrom(@this);
        }

        return @this == DBNull.Value ? null : @this;
    }
}