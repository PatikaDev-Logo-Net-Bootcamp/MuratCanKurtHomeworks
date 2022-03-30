namespace Homework4.Business.Extensions
{
    public static class StringExtensions
    {
        public static bool NullCheck(this string value)
        {
            return string.IsNullOrEmpty(value);
        }
    }
}
