namespace IteratorTraining
{
	internal class LazyLooper
	{
		public static Func<char> MakeLooper(string str)
		{
			var iterator = str.GetEnumerator();
			return () =>
			{
				if (!iterator.MoveNext())
				{
					iterator.Reset();
					iterator.MoveNext();
				}

				return iterator.Current;
			};
		}
	}
}
