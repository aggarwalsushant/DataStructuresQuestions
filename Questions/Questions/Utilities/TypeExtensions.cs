using System;

namespace Questions.Utilities
{
    public static class TypeExtensions
    {
        #region Generic_Number_Extensions
        public static bool Between<T>(this T source, T a, T b, bool inclusive = true) where T : IComparable<T>
        {
            return inclusive ?
                source.CompareTo(a) >= 0 && source.CompareTo(b) <= 0 :
                source.CompareTo(a) > 0 && source.CompareTo(b) < 0;
        }
        #endregion
    }
}
