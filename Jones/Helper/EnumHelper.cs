using System;
using System.Collections.Generic;
using System.Linq;

namespace Jones.Helper
{
    public static class EnumHelper
    {
        public static IEnumerable<T> ToEnumerable<T>() => Enum.GetValues(typeof(T)).Cast<T>();
        
        public static string ToRoleString(params Enum[] enums) => 
            string.Join(",", enums.Select(p => p.ToString()));
        
        public static string ToRoleString(IEnumerable<Enum> enums) => 
            string.Join(",", enums.Select(p => p.ToString()));
    }
}