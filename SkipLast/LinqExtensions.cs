namespace IteratorTraining
{
	internal static class LinqExtensions
	{
		public static IEnumerable<T> SkipLastNItems<T>(this IEnumerable<T> source, int n)
		{
			var iterator = source.GetEnumerator();
			var hasItems = false;
			var cache = new Queue<T>(n + 1);

			do
			{
				hasItems = iterator.MoveNext();
				if (hasItems)
				{
					cache.Enqueue(iterator.Current);
					if (cache.Count > n)
					{
						yield return cache.Dequeue();
					}
				}

			} while (hasItems);
		}

		public static IEnumerable<T> SkipLastItem<T>(this IEnumerable<T> source)
		{
			var iterator = source.GetEnumerator();
			var hasItems = false;
			var isFirst = true;
			var item = default(T);

			do
			{
				hasItems = iterator.MoveNext();
				if (hasItems)
				{
					if (!isFirst) yield return item;
					item = iterator.Current;
					isFirst = false;
				}
			} while (hasItems);
		}

		public static IEnumerable<T> WhereCustom<T>(this IEnumerable<T> source, Func<T, bool> predicate)
		{
			foreach (var item in source)
			{
				if (predicate(item))
				{
					yield return item;
				}
			}
		}

		public static IEnumerable<TResult> SelectCustom<TSource, TResult>(this IEnumerable<TSource> source,
			Func<TSource, TResult> selector)
		{
			foreach (var item in source)
			{
				yield return selector(item);
			}
		}

		public static IEnumerable<TSource> OrderByCustom<TSource, TKey>(this IEnumerable<TSource> source,
			Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
		{
			var elements = source.ToList();

			while (elements.Count > 0)
			{
				TSource minElement = elements[0];
				int minIndex = 0;
				for (int i = 1; i < elements.Count; i++)
				{
					var element1 = keySelector(elements[i]);
					var element2 = keySelector(minElement);

					if (comparer.Compare(element1, element2) < 0)
					{
						minElement = elements[i];
						minIndex = i;
					}
				}
				elements.RemoveAt(minIndex);
				yield return minElement;
			}
		}
	}
}
