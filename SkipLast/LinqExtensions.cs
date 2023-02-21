namespace SkipLast
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

		public static IEnumerable<T> SkipVarItems<T>(this IEnumerable<T> source, IEnumerable<T> exclude)
		{
			var iterator = source.GetEnumerator();

			yield return iterator.Current;
		} 
	}
}
