using System.Diagnostics;

namespace CSharpExercise;

public static class RLGExtensions
{
    public static IEnumerable<TSource> RLGWhere<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
        if (source == null)
        {
            throw new ArgumentNullException("source");
        }
        if (predicate == null)
        {
            throw new ArgumentNullException("predicate");
        }

        foreach (TSource item in source)
        {
            if(predicate(item))
                yield return item;
        }
    }

    public static IEnumerable<TSource> RLGWhere<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate)
    {
        if (source == null)
        {
            throw new ArgumentNullException("source");
        }
        if (predicate == null)
        {
            throw new ArgumentNullException("predicate");
        }
        int index = 0;
        foreach (TSource item in source)
        {
            if (predicate(item, index))
                yield return item;
            index++;
        }
    }

    public static IEnumerable<TResult> RLGSelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
    {
        if (source == null)
        {
            throw new ArgumentNullException("source");
        }
        if (selector == null)
        {
            throw new ArgumentNullException("selector");
        }
        foreach (TSource item in source)
        {
            yield return selector(item);
        }
    }

    public static IEnumerable<TResult> RLGSelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, TResult> selector)
    {
        if (source == null)
        {
            throw new ArgumentNullException("source");
        }
        if (selector == null)
        {
            throw new ArgumentNullException("selector");
        }
        int index = 0;
        foreach (TSource item in source)
        {
            yield return selector(item, index);
            index++;
        }
    }

    public static IEnumerable<TSource> RLGWhere<TSource>(this IEnumerable<IEnumerable<TSource>> source, Func<TSource, bool> predicate)
    {
        if (source == null)
        {
            throw new ArgumentNullException("source");
        }
        if (predicate == null)
        {
            throw new ArgumentNullException("predicate");
        }

        foreach (TSource item in source.SelectMany(x => x))
        {
            if (predicate(item))
                yield return item;
        }
    }

    public static IEnumerable<TResult> RLGSelect<TSource, TResult>(this IEnumerable<IEnumerable<TSource>> source, Func<TSource, TResult> selector)
    {
        if (source == null)
        {
            throw new ArgumentNullException("source");
        }
        if (selector == null)
        {
            throw new ArgumentNullException("selector");
        }
        foreach (TSource item in source.SelectMany(x => x))
        {
            yield return selector(item);
        }
    }
}
