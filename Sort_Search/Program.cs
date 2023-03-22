using Sort_Search;
internal class Program
{
	public static Road road1_256;
	public static Road road1_2048;
	public static Road road2_256;
	public static Road road2_2048;
	public static Road road3_256;
	public static Road road3_2048;
	public static Road Merge;
	private static void Main(string[] args)
	{
		string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location); // Gets the path of the current directory
		path = path.Replace(@"Sort_Search\bin\Debug\net6.0", ""); // Removes the last part of the path

		road1_256 = new Road(path, "Road_1_256"); // Creates the roads
		road1_2048 = new Road(path, "Road_1_2048");
		road2_256 = new Road(path, "Road_2_256");
		road2_2048 = new Road(path, "Road_2_2048");
		road3_256 = new Road(path, "Road_3_256");
		road3_2048 = new Road(path, "Road_3_2048");

		while (true) 
		{
			Road road = Select_Road(); // Selects a road to search
			road.Display(); // Displays the road file in ascending and descending, in the correct intervals

			while (true) // Helps ensure program doesnt continue if an incorrect value is inputted
			{ 
				try
				{
					Console.WriteLine("\nChoose a search method:\n(1) Linear Search,\n(2) Binary Search, "); // Asks for search method
					int search_Choice = int.Parse(Console.ReadLine());
					Console.WriteLine("Input a number to search for: "); // Asks for number to search for
					int query = int.Parse(Console.ReadLine()); // Reads input
					if (query >= 0 && query <= 1000) // Ensures the number is within the range of the road file
					{
						int[] indexes = { 0 }; // Creates an array to store the indexes of the found values
						if (search_Choice == 1) // If linear search is chosen
						{
							var watch = System.Diagnostics.Stopwatch.StartNew(); // Starts a timer
							indexes = Searches.Linear_Search(road.Ascending, query).ToArray(); // Searches for the value, using linear
							watch.Stop(); Console.WriteLine($"Roughly {watch.ElapsedMilliseconds}ms elapsed"); // Outputs the time elapsed
							Console.WriteLine("\nFound:");
							foreach (int i in indexes) { Console.WriteLine(road.Ascending[i] + " at " + i); } // outputs each value of indexes
							Console.WriteLine("");
							break;
						}
						else if (search_Choice == 2) // If binary search is chosen
						{
							var watch = System.Diagnostics.Stopwatch.StartNew(); // Starts a timer
							indexes = Searches.Binary_Search(road.Ascending, query, true).ToArray(); // Searches for the value, using binary
							watch.Stop(); Console.WriteLine($"Roughly {watch.ElapsedMilliseconds}ms elapsed"); // Outputs the time elapsed
							Console.WriteLine("\nFound:");
							foreach (int i in indexes) { Console.WriteLine(road.Ascending[i] + " at " + i); } // outputs each value of indexes
							Console.WriteLine("");
							break;
						}
						else { Console.WriteLine("Invalid input\n"); }
					}
					else { Console.WriteLine("Invalid input\n"); }
				}
				catch (Exception e){ Console.WriteLine(e + "\nOne of your inputs was not a number\n"); }
			}
		}
	}
	internal static Road Select_Road()
	{
		while (true)
		{
			try
			{
				Console.WriteLine("\nChoose a road to query:\n(1) Road_1_256,\n(2) Road_2_256,\n(3) Road_3_256," + // Asks for road to query
														"\n(4) Road_1_2048,\n(5) Road_2_2048,\n(6) Road_3_2048," +
														"\n(7) Merge,\n(8) None, ");
				int choice = int.Parse(Console.ReadLine());
				if (choice == 1) { return road1_256; } // Returns the road of choice
				else if (choice == 2) { return road2_256; }
				else if (choice == 3) { return road3_256; }
				else if (choice == 4) { return road1_2048; }
				else if (choice == 5) { return road2_2048; }
				else if (choice == 6) { return road3_2048; }
				else if (choice == 7) // Merging roads
				{
					while (true) // Helps ensure program doesnt continue if an incorrect value is inputted
					{
						try
						{
							Console.WriteLine("\nPick a first road:\n(1) Road_1_256,\n(2) Road_2_256,\n(3) Road_3_256," + // Asks for first road
																"\n(4) Road_1_2048,\n(5) Road_2_2048,\n(6) Road_3_2048, ");
							int first_Merge = int.Parse(Console.ReadLine());
							Console.WriteLine("\nIf you choose to merge 2 indentical roads, nothing will happen."); // Warns user, asks for second road
							Console.WriteLine("Pick a Second road:\n(1) Road_1_256,\n(2) Road_2_256,\n(3) Road_3_256," +
																"\n(4) Road_1_2048,\n(5) Road_2_2048,\n(6) Road_3_2048, ");
							int second_Merge = int.Parse(Console.ReadLine());
							if (first_Merge > 0 && first_Merge < 7 && second_Merge > 0 && second_Merge < 7) // Ensures the numbers are within the range
							{
								if (first_Merge == second_Merge) { Console.WriteLine("You chose the same road twice\n"); }
								else
								{ 
									Road temp; // Creates a temporary road to store the first road
									if (first_Merge == 1) { temp = road1_256; }
									else if (first_Merge == 2) { temp = road2_256; }
									else if (first_Merge == 3) { temp = road3_256; }
									else if (first_Merge == 4) { temp = road1_2048; }
									else if (first_Merge == 5) { temp = road2_2048; }
									else { temp = road3_2048; }
									if (second_Merge == 1) { Road merge = new Road(temp, road1_256); return merge; } // Merges the roads
									else if (second_Merge == 2) { Road merge = new Road(temp, road2_256); return merge; }
									else if (second_Merge == 3) { Road merge = new Road(temp, road3_256); return merge; }
									else if (second_Merge == 4) { Road merge = new Road(temp, road1_2048); return merge; }
									else if (second_Merge == 5) { Road merge = new Road(temp, road2_2048); return merge; }
									else { Road merge = new Road(temp, road3_2048); return merge; }
								}
							}
							else { Console.WriteLine("One of your inputs was an invalid number\n"); }
						}
						catch (Exception e) { Console.WriteLine(e + "\nOne of your inputs was not a number\n"); }
					}
				}
				else if (choice == 8) { Environment.Exit(0); } // Exits the program
				else { Console.WriteLine("Invalid number!"); }
			}
			catch { Console.WriteLine("Not a valid number"); };
		}
	}
}