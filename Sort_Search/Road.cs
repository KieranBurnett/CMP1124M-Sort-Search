namespace Sort_Search
{
	class Road
	{
		public string Id;
		public int[] Unsorted_array;
		public int[] Ascending;
		public int[] Descending;
		public Road(string Directory, string id) // for none merged roads
		{
			string file_Path=Directory+id+".txt"; // Path to the file
			Id = id;
			var list = new List<int>(); // List to store the values from the file
			try
			{
				var data = File.ReadAllLines(file_Path);
				foreach (string s in data) // Loop through the file and add the values to the list
				{
					list.Add(int.Parse(s));
				}
				Unsorted_array = list.ToArray();
			}
			catch
			{
				Console.WriteLine($"Problem with finding {file_Path}");
			}
			Unsorted_array = list.ToArray();
			while (true) // Helps ensure program doesnt continue if an incorrect value is inputted
			{
				try
				{
					Console.WriteLine("\nChoose for "+Id+":\n(1) Bubble Sort,\n(2) Insertion Sort,\n(3) Selection Sort,\n(4) Quick Sort"); // Ask the user for a choice
					int choice = int.Parse(Console.ReadLine());
					var watch = System.Diagnostics.Stopwatch.StartNew();
					if (choice == 1) { Ascending = Sorts.Bubble_Sort(Unsorted_array, true); // call the sort method with the ascending parameter as true
						watch.Stop(); Console.WriteLine($"Roughly {watch.ElapsedMilliseconds}ms elapsed");
						Descending = Sorts.Bubble_Sort(Unsorted_array, false); // call the sort method with the ascending parameter as false
						break; }
					else if (choice == 2) { Ascending = Sorts.Insertion_Sort(Unsorted_array, true); // call the sort method with the ascending parameter as true
						watch.Stop(); Console.WriteLine($"Roughly {watch.ElapsedMilliseconds}ms elapsed");
						Descending = Sorts.Insertion_Sort(Unsorted_array, false); // call the sort method with the ascending parameter as false
						break; }
					else if (choice == 3) { Ascending = Sorts.Selection_Sort(Unsorted_array, true); // call the sort method with the ascending parameter as true
						watch.Stop(); Console.WriteLine($"Roughly {watch.ElapsedMilliseconds}ms elapsed");
						Descending = Sorts.Selection_Sort(Unsorted_array, false); // call the sort method with the ascending parameter as false
						break; }
					else if (choice == 4) { Ascending = Sorts.Quick_Sort(Unsorted_array, true); // call the sort method with the ascending parameter as true
						watch.Stop(); Console.WriteLine($"Roughly {watch.ElapsedMilliseconds}ms elapsed");
						Descending = Sorts.Quick_Sort(Unsorted_array, false); // call the sort method with the ascending parameter as false
						break; }
					else { Console.WriteLine("Not a valid number in this case,"); }
				}
				catch
				{
					Console.WriteLine("Please enter a valid number.");
					continue;
				}
			}
		}
		public Road(Road First, Road Second) // for merging roads "https://www.geeksforgeeks.org/c-sharp-constructor-overloading/" (GeeksforGeeks, 2018) for help with constructor overloading/ multiple constructor classes
		{
			if ( First.Id.Split("_")[2] == "2048" || Second.Id.Split("_")[2] == "2048") 
			{
				Id = "Road_Merge_2048";
			}
			else { Id = "Road_Merge_256"; }
			Unsorted_array = First.Unsorted_array.Concat(Second.Unsorted_array).ToArray();
			while (true) // Helps ensure program doesnt continue if an incorrect value is inputted
			{
				try
				{
					Console.WriteLine("\nChoose for " + Id + ":\n(1) Bubble Sort,\n(2) Insertion Sort,\n(3) Selection Sort,\n(4) Quick Sort");
					int choice = int.Parse(Console.ReadLine());
					var watch = System.Diagnostics.Stopwatch.StartNew();
					if (choice == 1)
					{
						Ascending = Sorts.Bubble_Sort(Unsorted_array, true); // call the sort method with the ascending parameter as true
						watch.Stop(); Console.WriteLine($"Roughly {watch.ElapsedMilliseconds}ms elapsed");
						Descending = Sorts.Bubble_Sort(Unsorted_array, false); // call the sort method with the ascending parameter as false
						break;
					}
					else if (choice == 2)
					{
						Ascending = Sorts.Insertion_Sort(Unsorted_array, true); // call the sort method with the ascending parameter as true
						watch.Stop(); Console.WriteLine($"Roughly {watch.ElapsedMilliseconds}ms elapsed");
						Descending = Sorts.Insertion_Sort(Unsorted_array, false); // call the sort method with the ascending parameter as false
						break;
					}
					else if (choice == 3)
					{
						Ascending = Sorts.Selection_Sort(Unsorted_array, true); // call the sort method with the ascending parameter as true
						watch.Stop(); Console.WriteLine($"Roughly {watch.ElapsedMilliseconds}ms elapsed");
						Descending = Sorts.Selection_Sort(Unsorted_array, false); // call the sort method with the ascending parameter as false
						break;
					}
					else if (choice == 4)
					{ 
						Ascending = Sorts.Quick_Sort(Unsorted_array, true); // call the sort method with the ascending parameter as true
						watch.Stop(); Console.WriteLine($"Roughly {watch.ElapsedMilliseconds}ms elapsed");
						Descending = Sorts.Quick_Sort(Unsorted_array, false); // call the sort method with the ascending parameter as false
						break;
					}
					else { Console.WriteLine("Not a valid number in this case,"); }
				}
				catch
				{
					Console.WriteLine("Please enter a valid number.");
					continue;
				}
			}
		}
		public void Display()
		{
			int amount = 50; // sets default interval as 50
			if (Id.Split("_")[2] == "256") { amount = 10; } // if two 256 were merged, interval set to 10
			Console.WriteLine($"{Id} Ascending (every {amount}): ");
			for (int i = 0; i < Ascending.Length; i++)
				{
					if (i % amount == 0)
					{
						Console.WriteLine(Ascending[i]);
					}
				}
			Console.WriteLine($"{Id} Descending (every {amount}): ");
			for (int i = 0; i<Ascending.Length; i++)
			{
				if (i % amount == 0)
				{
					Console.WriteLine(Descending[i]);
				}
			}
			Console.WriteLine("");
		}
	}
}