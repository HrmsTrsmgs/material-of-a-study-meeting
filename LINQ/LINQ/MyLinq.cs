using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Linq.MyLinq
{
    static class EnumerableExtensions
    {
        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            foreach(var item in source)
            {
                yield return selector(item);
            }
        }

        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach(var item in source)
            {
                if(predicate(item))
                {
                    yield return item;
                }
            }
        }

        public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector) where TKey : IComparable<TKey>
        {
            return new OrderdEnumerable<TSource>(source).CreateOrderedEnumerable(keySelector, Comparer<TKey>.Create((key1, key2) => key1.CompareTo(key2)), false);
        }

        public static List<TSource> ToList<TSource>(this IEnumerable<TSource> source)
        {
            var list = new List<TSource>();

            foreach(var item in source)
            {
                list.Add(item);
            }
            return list;
        }

        public class OrderdEnumerable<TElement> : IOrderedEnumerable<TElement>
        {
            public OrderdEnumerable(IEnumerable<TElement> source)
            {
                this.sourse = source;
            }

            IEnumerable<TElement> sourse;

            Func<IEnumerator<TElement>> CreateEnumerator;

            public IOrderedEnumerable<TElement> CreateOrderedEnumerable<TKey>(Func<TElement, TKey> keySelector, IComparer<TKey> comparer, bool descending)
            {
                CreateEnumerator = () =>
                {
                    var list = sourse.ToList();
                    list.Sort((item1, item2) => comparer.Compare(keySelector(item1), keySelector(item2)));

                    if (descending)
                    {
                        list.Reverse();
                    }
                    return list.GetEnumerator();
                };

                return this;
            }

            public IEnumerator<TElement> GetEnumerator()
            {
                if (CreateEnumerator == null)
                {
                    return sourse.GetEnumerator();
                }
                else
                {
                    return CreateEnumerator();
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        public interface IOrderedEnumerable<TElement> : IEnumerable<TElement>, IEnumerable
        {
            IOrderedEnumerable<TElement> CreateOrderedEnumerable<TKey>(Func<TElement, TKey> keySelector, IComparer<TKey> comparer, bool descending);
        }
    }
}
