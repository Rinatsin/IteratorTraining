using System.Collections;
using System.Reflection.Metadata.Ecma335;

namespace IteratorTraining
{
	//Реализация стека (базовая)
	internal class Stack<T> : IEnumerable<T>
	{
		private T[] _values = new T[100];
		private int _top = 0;

		public void Push(T value)
		{
			_values[_top] = value;
			_top++;
		}

		public T Pop()
		{
			_top--;
			return _values[_top];
		}

		public IEnumerator<T> GetEnumerator()
		{
			for (var i = _top - 1; i >= 0 ; i--)
			{
				yield return _values[i];
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public IEnumerable<T> TopToBottom => this;

		public IEnumerable<T> BottomToTop
		{
			get
			{
				for (var i = 0; i < _top; i++)
				{
					yield return _values[i];
				}
			}
		}

		public IEnumerable<T> TopN(int itemsFromTop)
		{
			var startIndex = itemsFromTop >= _top ? 0 : _top - itemsFromTop;
			for (var i = _top - 1; i >= startIndex; i--)
			{
				yield return _values[i];
			}
			
		}
	}
}
