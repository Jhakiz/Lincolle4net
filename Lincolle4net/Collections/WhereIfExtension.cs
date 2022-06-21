using System.Linq;

namespace System.Collections.Generic
{
    public static class WhereIfExtension
    {
        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> input, bool condition, Func<T, bool> predicate)
        {
            return condition ?
                input.Where(predicate) :
                input;
        }

        public static IEnumerable<T> WhereIf<T>(this IList<T> input, bool condition, Func<T, bool> predicate)
        {
            return condition ?
                input.Where(predicate) :
                input;
        }

        public static IEnumerable<T> WhereIf<T>(this ICollection<T> input, bool condition, Func<T, bool> predicate)
        {
            return condition ?
                input.Where(predicate) :
                input;
        }

        public static IEnumerable<T> WhereIf<T>(this Stack<T> input, bool condition, Func<T, bool> predicate)
        {
            return condition ?
                input.Where(predicate) :
                input;
        }

        public static Dictionary<TKey, TValue> WhereIf<TKey, TValue>(this Dictionary<TKey, TValue> input, bool condition, Func<KeyValuePair<TKey, TValue>, bool> predicate)
        {
            if (input is null)
                throw new ArgumentNullException(nameof(input));

            return condition ?
                Enumerable
                    .Where(input, predicate)
                    .ToDictionary(item => item.Key, item => item.Value) :
                input;
        }

    }
}
