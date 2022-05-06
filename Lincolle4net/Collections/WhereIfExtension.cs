namespace System.Collections.Generic
{
    public static class WhereIfExtension
    {
        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> input, bool condition, Func<T, bool> predicate)
            where T : class
        {
            return condition ? 
                input.Where(predicate) : 
                input;
        }

    }
}
