namespace SkipLast
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello, World!");

			var seq = new int[5] { 1, 2, 3, 4, 5 };
			var result = seq.SkipLastItem();

			Console.WriteLine(string.Join(", ", seq.Select(x => x.ToString())));
			Console.WriteLine(string.Join(", ", result.Select(x => x.ToString())));
			Console.ReadLine();

			//Stack test
			StackTest();

		}

		private static void StackTest()
		{
			var theStack = new Stack<int>();
			
			for (var number = 0; number <= 9; number++)
			{
				theStack.Push(number);
			}
			
			foreach (int number in theStack)
			{
				Console.Write("{0} ", number);
			}
			Console.WriteLine();
			
			foreach (int number in theStack.TopToBottom)
			{
				Console.Write("{0} ", number);
			}
			Console.WriteLine();

			foreach (int number in theStack.BottomToTop)
			{
				Console.Write("{0} ", number);
			}
			Console.WriteLine();

			foreach (int number in theStack.TopN(7))
			{
				Console.Write("{0} ", number);
			}
			Console.WriteLine();

			Console.ReadKey();
		}

	}
}