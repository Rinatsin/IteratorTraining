using System.Collections;
using IteratorTraining.Data;

namespace IteratorTraining.Iterators
{
	internal class CarSequence : IEnumerable<Car>
	{
		private readonly int _startValue;
		private readonly Car[] _values;

		public CarSequence(Car[] values, int startValue)
		{
			_values = values;
			_startValue = startValue;
		}

		public IEnumerator<Car> GetEnumerator()
		{
			return new CarIterator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		private class CarIterator : IEnumerator<Car>
		{
			private readonly CarSequence _parent;
			private int _position;

			public CarIterator(CarSequence parent)
			{
				_parent = parent;
				_position = -1;
			}

			public bool MoveNext()
			{
				if (_position != _parent._values.Length)
				{
					_position++;
				}
				return _position < _parent._values.Length;
			}

			public void Reset()
			{
				_position = -1;
			}

			public Car Current
			{
				get
				{
					if (_position == -1 || _position == _parent._values.Length)
					{
						throw new InvalidOperationException();
					}
					return _parent._values[_position];
				}
			}

			object IEnumerator.Current => Current;

			public void Dispose()
			{
			}
		}
	}
}
