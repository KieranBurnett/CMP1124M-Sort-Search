using Sort_Search;
internal class Program
{
	private static void Main(string[] args)
	{
		int choice;
		int[] road;

		string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
		path=path.Replace(@"Sort_Search\bin\Debug\net6.0", "");
		
		// C:\Users\Kieran\source\repos\KieranBurnett\CMP1124M-Sort-Search\Road_1_256.txt
		// C:\Users\Kieran\Source\Repos\KieranBurnett\CMP1124M-Sort-Search\Sort_Search\bin\Debug\net6.0

		Road road1 = new Road(path + "Road_1_256.txt");
		Road road2 = new Road(path + "Road_2_256.txt");
		Road road3 = new Road(path + "Road_3_256.txt");

		
		Console.WriteLine("Road1: Ascending");
		for (int i = 0; i < road1.Ascending.Length; i = i + 10) { Console.WriteLine(road1.Ascending[i]); }
		Console.WriteLine("Road1: Descending");
		for (int i = 0; i < road1.Descending.Length;  i = i + 10) { Console.WriteLine(road1.Descending[i]); }
		

		//int[] indexes=Searches.Linear_Search(road1.Ascending, 3);
		// (int i in indexes) { Console.WriteLine(road1.Ascending[i] +" at "+i); } // outputs each value of indexes

		
		while (true)
		{
			try
			{
				Console.WriteLine("Which array out of the following;\n(1) Road_1_256,\n(2) Road_2_256,\n(3) Road_3_256, ");
				choice = int.Parse(Console.ReadLine()); // Reads input
				if (choice > 0 && choice < 4) // prevent out of bound errors
				{ 
					if (choice == 1) { road = road1.Ascending; }
					else if (choice == 2) { road = road2.Ascending; }
					else if (choice == 3) { road = road3.Ascending; }
					break; 
				} 
				else { Console.WriteLine("Not a valid number\n"); }

			}
			catch { Console.WriteLine("Not a number\n"); }
		}
		//Console.WriteLine(road);
		/*
		while (true)
		{
			try
			{
				Console.WriteLine("Input a number to search for");
				choice = int.Parse(Console.ReadLine()); // Reads input
				if (choice > 0 && choice < 1000) 
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
