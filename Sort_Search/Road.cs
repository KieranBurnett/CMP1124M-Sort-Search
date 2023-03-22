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
			string file_Path=Directory+id+".txt";
			Id = id;
			var list = new List<int>();
			try
			{
				var data = File.ReadAllLines(file_Path);
				foreach (string s in data)
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
					Console.WriteLine("\nChoose for "+Id+":\n(1) Bubble Sort,\n(2) Insertion Sort,\n(3) Merge Sort,\n(4) Quick Sort");
					int choice = int.Parse(Console.ReadLine());
					var watch = System.Diagnostics.Stopwatch.StartNew();
					if (choice == 1) { Ascending = Sorts.Bubble_Sort(Unsorted_array, true); 
						watch.Stop(); Console.WriteLine("Roughly " + watch.ElapsedMilliseconds+"ms elapsed");
						Descending = Sorts.Bubble_Sort(Unsorted_array, false);
						break; }
					else if (choice == 2) { Ascending = Sorts.Insertion_Sort(Unsorted_array, true); 
						watch.Stop(); Console.WriteLine("Roughly " + watch.ElapsedMilliseconds + "ms elapsed");
						Descending = Sorts.Insertion_Sort(Unsorted_array, false);
						break; }
					else if (choice == 3) { Ascending = Sorts.Selection_Sort(Unsorted_array, true); 
						watch.Stop(); Console.WriteLine("Roughly " + watch.ElapsedMilliseconds + "ms elapsed");
						Descending = Sorts.Insertion_Sort(Unsorted_array, false);
						break; }
					else if (choice == 4) { Ascending = Sorts.Quick_Sort(Unsorted_array, true); 
						watch.Stop(); Console.WriteLine("Roughly " + watch.ElapsedMilliseconds + "ms elapsed");
						Descending = Sorts.Insertion_Sort(Unsorted_array, false);
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
		public Road(Road First, Road Second) // for merging roads
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
					Console.WriteLine("\nChoose for " + Id + ":\n(1) Bubble Sort,\n(2) Insertion Sort,\n(3) Merge Sort,\n(4) Quick Sort");
					int choice = int.Parse(Console.ReadLine());
					var watch = System.Diagnostics.Stopwatch.StartNew();
					if (choice == 1)
					{
						Ascending = Sorts.Bubble_Sort(Unsorted_array, true);
						watch.Stop(); Console.WriteLine("Roughly " + watch.ElapsedMilliseconds + "ms elapsed");
						Descending = Sorts.Bubble_Sort(Unsorted_array, false);
						break;
					}
					else if (choice == 2)
					{
						Ascending = Sorts.Insertion_Sort(Unsorted_array, true);
						watch.Stop(); Console.WriteLine("Roughly " + watch.ElapsedMilliseconds + "ms elapsed");
						Descending = Sorts.Insertion_Sort(Unsorted_array, false);
						break;
					}
					else if (choice == 3)
					{
						Ascending = Sorts.Selection_Sort(Unsorted_array, true);
						watch.Stop(); Console.WriteLine("Roughly " + watch.ElapsedMilliseconds + "ms elapsed");
						Descending = Sorts.Insertion_Sort(Unsorted_array, false);
						break;
					}
					else if (choice == 4)
					{
						Ascending = Sorts.Quick_Sort(Unsorted_array, true);
						watch.Stop(); Console.WriteLine("Roughly " + watch.ElapsedMilliseconds + "ms elapsed");
						Descending = Sorts.Insertion_Sort(Unsorted_array, false);
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
			int amount = 50;
			if (Id.Split("_")[2] == "256") { amount = 10; }
			Console.WriteLine(Id + " Ascending (every "+amount+"): ");
			for (int i = 0; i < Ascending.Length; i++)
				{
					if (i % amount == 0)
					{
						Console.WriteLine(Ascending[i]);
					}
				}
			Console.WriteLine(Id+ " Descending (every "+amount+"): ");
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