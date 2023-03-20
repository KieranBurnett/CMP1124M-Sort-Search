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
			Ascending = Sorts.Selection_Sort(Unsorted_array);
			Descending = Sorts.Flip(Ascending);
		}
		public Road(Road First, Road Second) // for merging roads
		{
			if ( First.Id.Split("_")[2] == "2048" || Second.Id.Split("_")[2] == "2048") 
			{
				Id = "Road_Merge_2048";
			}
			else { Id = "Road_Merge_256"; }
			Unsorted_array = First.Unsorted_array.Concat(Second.Unsorted_array).ToArray();
			Ascending = Sorts.Selection_Sort(Unsorted_array);
			Descending = Sorts.Flip(Ascending);
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