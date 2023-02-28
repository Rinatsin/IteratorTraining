using IteratorTraining.Data;
using IteratorTraining.Iterators;

namespace IteratorTraining
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			Console.WriteLine("Набор тренировочных решений в целях повышения квалификации!");

			//Реализация skip last метода из linq
			SkipLastLinqTest();
			Console.ReadKey();
			Console.WriteLine();

			//Наивная реализация стека (для общего понимания)
			StackTest();
			Console.ReadKey();
			Console.WriteLine();

			//Решение задачи с CodeWars (https://www.codewars.com/kata/51fc3beb41ecc97ee20000c3)
			LazyRepeaterFromCodeWarsTest();
			Console.ReadKey();
			Console.WriteLine();

			LinqMethodsTest();
			Console.ReadKey();
			Console.WriteLine();
		}

		private static void SkipLastLinqTest()
		{
			Console.WriteLine("Linq SkipLant custom test");
			Console.WriteLine("-------------------------");
			var seq = new int[5] { 1, 2, 3, 4, 5 };
			var result = seq.SkipLastItem();

			Console.WriteLine(string.Join(", ", seq.Select(x => x.ToString())));
			Console.WriteLine(string.Join(", ", result.Select(x => x.ToString())));
		}

		private static void StackTest()
		{
			Console.WriteLine("Custom stack test");
			Console.WriteLine("-----------------");
			var theStack = new Stack<int>();
			
			for (var number = 0; number <= 9; number++)
			{
				theStack.Push(number);
			}

			Console.WriteLine("Custom stack base test");
			foreach (var number in theStack)
			{
				Console.Write("{0} ", number);
			}
			Console.WriteLine();

			Console.WriteLine("Custom stack TopToBottom test");
			foreach (var number in theStack.TopToBottom)
			{
				Console.Write("{0} ", number);
			}
			Console.WriteLine();

			Console.WriteLine("Custom stack BottomToTop test");
			foreach (var number in theStack.BottomToTop)
			{
				Console.Write("{0} ", number);
			}
			Console.WriteLine();

			Console.WriteLine("Custom stack Top(7) test");
			foreach (var number in theStack.TopN(7))
			{
				Console.Write("{0} ", number);
			}
			Console.WriteLine();
		}

		private static void LazyRepeaterFromCodeWarsTest()
		{
			Console.WriteLine("Lazy Repeater from CodeWars");
			Console.WriteLine("---------------------------");
			const int numberOfLaunches = 10;
			var abc = LazyLooper.MakeLooper("abc");
			for (var i = 0; i < numberOfLaunches; i++)
			{
				Console.Write($"{abc()} ");
			}
			Console.WriteLine();
		}

		private static void LinqMethodsTest()
		{
			var cars = new List<Car>()
			{
				new("Skoda", "Octavia", 230),
				new("Skoda", "Fabia", 200),
				new("Skoda", "Superb", 240),
				new("Skoda", "Yeti", 220),
				new("Skoda", "Karoq", 210),
				new("Toyota", "Camry", 240),
				new("Toyota", "Land Cruiser", 210),
				new("Toyota", "Supra", 300),
				new("Porsche", "911", 320),
				new("Porsche", "Cayman", 330)
			};
			Console.WriteLine("Custom Sequence (foreach)");
			Console.WriteLine("--------------------");
			var sequence = new CarSequence(cars.ToArray(), 0);
			var ienumerator = sequence.GetEnumerator();
			while (ienumerator.MoveNext())
			{
				Console.WriteLine($"{ienumerator.Current} \n");
			}
			ienumerator.Dispose();
			Console.WriteLine();


			Console.WriteLine("Custom Linq Where Select OrderBy (Выбраны модели с максимальной скоростью меньше 300 и отсортированы по длине имени)");
			Console.WriteLine("-----------------");
			var modelCarsSpeedLessThan300 = cars
				.WhereCustom(c => c.MaxSpeed < 300)
				.SelectCustom(c => c.Model)
				.OrderByCustom(name => name.Length, Comparer<int>.Default);
			Console.WriteLine(string.Join(Environment.NewLine, modelCarsSpeedLessThan300));
			Console.WriteLine();
		}
	}
}