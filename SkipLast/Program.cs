namespace SkipLast
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello, World!");

			var seq = new int[5] { 1, 2, 3, 4, 5 };
			var result = seq.SkipLastNItems(2);

			Console.WriteLine(string.Join(", ", seq.Select(x => x.ToString())));
			Console.WriteLine(string.Join(", ", result.Select(x => x.ToString())));
			Console.ReadLine();
		}

	}
}