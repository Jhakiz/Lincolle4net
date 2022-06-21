using System.Collections.Generic;

namespace System.Linq
{
    public static class WhereIfExtension
    {
        public static IEnumerable<T> WhereIf<T>(this IQueryable<T> input, bool condition, Func<T, bool> predicate)
            where T : class
        {
            return condition ? 
                input.Where(predicate) : 
                input;
        }

    }
}
