namespace IteratorTraining.Data
{
	internal class Car
	{
		public string? Manufacturer;
		public string? Model;
		public int MaxSpeed;

		public Car(string manufacturer, string model, int maxSpeed)
		{
			Manufacturer = manufacturer;
			Model = model;
			MaxSpeed = maxSpeed;
		}

		public override string ToString()
		{
			return $"{Manufacturer} {Model} has a top speed of {MaxSpeed} km/h";
		}
	}
}
