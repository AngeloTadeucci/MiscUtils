using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;

namespace MiscUtils
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> ThrowIfEmpty<T>(this IEnumerable<T> source)
        {
            if (!source.Any())
            {
                throw new EnumerableEmptyException();
            }

            return source;
        }

        public static Dictionary<TKey, TSource> ToDictionaryDupes<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
            => source.ToDictionaryDupes(keySelector, x => x, null);

        public static Dictionary<TKey, TSource> ToDictionaryDupes<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
            => source.ToDictionaryDupes(keySelector, x => x, comparer);

        public static Dictionary<TKey, TElement> ToDictionaryDupes<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
            => source.ToDictionaryDupes(keySelector, elementSelector, null);

        public static Dictionary<TKey, TElement> ToDictionaryDupes<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (keySelector == null)
            {
                throw new ArgumentNullException(nameof(keySelector));
            }
            if (elementSelector == null)
            {
                throw new ArgumentNullException(nameof(elementSelector));
            }

            Dictionary<TKey, TElement> dictionary = new Dictionary<TKey, TElement>(comparer);

            foreach (TSource item in source)
            {
                dictionary[keySelector(item)] = elementSelector(item);
            }

            return dictionary;
        }

        public static IDisposable AsDisposable<T>(this IEnumerable<T> source) where T : IDisposable
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return Disposable.Create(() =>
            {
                foreach (var d in source)
                {
                    d?.Dispose();
                }
            });
        }
    }
}
