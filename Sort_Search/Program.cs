using Sort_Search;
internal class Program
{
	public static Road road1_256;
	public static Road road1_2048;
	public static Road road2_256;
	public static Road road2_2048;
	public static Road road3_256;
	public static Road road3_2048;
	private static void Main(string[] args)
	{
		string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
		path = path.Replace(@"Sort_Search\bin\Debug\net6.0", "");

		road1_256 = new Road(path, "Road_1_256");
		road1_2048 = new Road(path, "Road_1_2048");
		road2_256 = new Road(path, "Road_2_256");
		road2_2048 = new Road(path, "Road_2_2048");
		road3_256 = new Road(path, "Road_3_256");
		road3_2048 = new Road(path, "Road_3_2048");

		while (true)
		{
			Road road = Select_Road();
			road.Display();

			while (true) // Helps ensure program doesnt continue if an incorrect value is inputted
			{ 
				try
				{
					Console.WriteLine("Input a number to search for: ");
					int choice = int.Parse(Console.ReadLine()); // Reads input
					if (choice >= 0 && choice < 1000)
					{
						int[] indexes=Searches.BinarySearch(road.Ascending, choice).ToArray();
						Console.WriteLine("\nFound:");
						foreach (int i in indexes) { Console.WriteLine(road.Ascending[i] +" at "+i); } // outputs each value of indexes
						break;
					}
					else { Console.WriteLine("Not a valid number\n"); }
				}
				catch (Exception e){ Console.WriteLine(e+"\nNot a number\n"); }
			}
		}
	}
	internal static Road Select_Road()
	{
		while (true)
		{
			try
			{
				Console.WriteLine("Which road:\n(1) Road_1_256,\n(2) Road_1_2048,\n(3) Road_2_256," +
											"\n(4) Road_2_2048,\n(5) Road_3_256,\n(6) Road_3_2048,\n(7) None, ");
				int choice = int.Parse(Console.ReadLine());
				if (choice == 1) { return road1_256; }
				else if (choice == 2) { return road1_2048; }
				else if (choice == 3) { return road2_256; }
				else if (choice == 4) { return road2_2048; }
				else if (choice == 5) { return road3_256; }
				else if (choice == 6) { return road3_2048; }
				else if (choice == 7) { Environment.Exit(0); }
				else { Console.WriteLine("Invalid number!"); }
			}
			catch { Console.WriteLine("Not a valid number"); };
		}
	}
}
