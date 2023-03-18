using Sort_Search;

internal class Program
{
	private static void Main(string[] args)
	{
		int choice;
		int[] road;

		Road road1 = new Road(@"C:\Users\kieran\Desktop\Search _ Sort\Road_1_256.txt");
		Road road2 = new Road(@"C:\Users\kieran\Desktop\Search _ Sort\Road_2_256.txt");
		Road road3 = new Road(@"C:\Users\kieran\Desktop\Search _ Sort\Road_3_256.txt");

		Console.WriteLine("Road1: Array");
		for (int i = 0; i < road1.Arr.Length; i = i + 10) { Console.WriteLine(road1.Arr[i]); }
		Console.WriteLine("Road1: Ascending");
		for (int i = 0; i < road1.Arr.Length; i = i + 10) { Console.WriteLine(road1.Ascending[i]); }
		Console.WriteLine("Road1: Descending");
		for (int i = 0; i < road1.Arr.Length;  i = i + 10) { Console.WriteLine(road1.Descending[i]); }
		/*
		while (true)
		{
			try
			{
				Console.WriteLine("Which array out of the following;\n(1) Road_1_256,\n(2) Road_2_256,\n(3) Road_3_256, ");
				choice = int.Parse(Console.ReadLine()); // Reads input
				if (choice > 0 && choice < 4) // prevent out of bound errors
				{ 
					if (choice == 1) { road = road1.Arr; }
					else if (choice == 2) { road = road2.Arr; }
					else if (choice == 3) { road = road3.Arr; }
					break; 
				} 
				else { Console.WriteLine("Not a valid number\n"); }
			}
			catch { Console.WriteLine("Not a number\n"); }
		}

		
		while (true)
		{
			try
			{
				Console.WriteLine("1.Ascending or 2.Descending ");
				choice = int.Parse(Console.ReadLine()); // Reads input
				if (choice == 1) 
				{ 
					Console.WriteLine("Ascending sort..");
					road = Sorts.Bubble_Sort(road);
					break; 
				}
				else if (choice == 2) { Console.WriteLine("descending sort"); break; }
				else { Console.WriteLine("Not a valid number\n"); }
			}
			catch { Console.WriteLine("Not a number\n"); }
		}
		*/
	}
}
