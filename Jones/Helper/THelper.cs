using System;
using System.Linq.Expressions;

namespace Jones.Helper
{
    public static class THelper
    {
        public static string GetPropertyName<T>(Expression<Func<T, dynamic?>> property)
        {
            LambdaExpression lambda = property;
            MemberExpression memberExpression;
        
            if (lambda.Body is UnaryExpression unaryExpression)
            {
                memberExpression = (MemberExpression)unaryExpression.Operand;
            }
            else
            {
                memberExpression = (MemberExpression)lambda.Body;
            }
        
            return memberExpression.Member.Name;
        }
    }
}