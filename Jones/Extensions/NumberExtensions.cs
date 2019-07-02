using System;

namespace Jones.Extensions
{
    public static class NumberExtensions
    {
        public static double Intercept(this double source, int digits)
        {
            var digitsPow = Math.Pow(10, digits);
            return Convert.ToDouble((int) (source * digitsPow)) / digitsPow;
        }
    }
}