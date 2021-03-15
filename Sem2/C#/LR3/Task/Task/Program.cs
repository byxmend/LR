using System;

namespace Task
{
	class Program
	{
		static void FillArray(Company[] arr)
		{
			for (int i = 0; i < arr.Length; i++)
			{
				arr[i] = new Company();
				Console.Write("Name: ");
				arr[i].Name = Console.ReadLine();
				Console.Write("AvarageSalary: ");
				arr[i].AvarageSalary = CheckInteger();
				Console.Write("WebsiteDomain: ");
				arr[i].WebsiteDomain = Console.ReadLine();
			}
		}

		static int CheckInteger()
		{
			int num;
			while (!int.TryParse(Console.ReadLine(), out num) || num <= 0)
			{
				Console.WriteLine("Error, enter the data again");
			}
			return num;
		}

		static void Main()
		{
			Company obj1 = new Company();
			Company obj2 = new Company("Wargaming", 2000, "com");
			Console.WriteLine(obj1 + "\n");
			Console.WriteLine(obj2 + "\n");

			Console.WriteLine("Do you want to change the values? (yes - more then 1)");
			int decision;
			if (int.TryParse(Console.ReadLine(), out decision) && decision >= 1)
			{
				Company[] arr = new Company[2];
				FillArray(arr);
				Console.WriteLine();
			}
		}
	}
}