namespace Jones.Extensions
{
    public static class BooleanExtensions
    {
        public static bool? ToNullable(this bool source) => source ? (bool?)true : null;
        public static bool? ToFalseNull(this bool? source) => source == true ? (bool?)true : null;
    }
}