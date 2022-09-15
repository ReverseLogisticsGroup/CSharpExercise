using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpExercise
{

    public static class RLGExtensions
    {
        public static IEnumerable<TSource> RLGWhere<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate)
        {
            if (source == null)
            {
                throw new Exception("soruce is null");
            }

            if (predicate == null)
            {
                throw new Exception("predicate is null");
            }

            int index = 0;
            foreach (TSource item in source)
            {
                if (predicate(item, index))
                    yield return item;
                index++;
            }
        }

        public static IEnumerable<TSource> RLGSelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            if (source == null)
            {
                throw new Exception("source is null");
            }

            if (selector == null)
            {
                throw new Exception("selector is null");
            }

            foreach (TSource item in source.SelectMany(x => source))
            {
                yield return item;
            }
        }


    }
}
