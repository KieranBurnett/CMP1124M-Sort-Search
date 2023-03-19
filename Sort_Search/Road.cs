namespace Sort_Search
{
	class Road
	{
		public string Id;
		public int[] Unsorted_array;
		public int[] Ascending;
		public int[] Descending;
		public Road(string Directory, string id)
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
		//write a method that will display every 10th value of the ascending array
		public void Display()
		{
			int amount = 10;
			if (Convert.ToString(Id).Substring(7, 4) == "2048") { amount = 50; }
			Console.WriteLine(Convert.ToString(Id).Substring(7, 3));
			Console.WriteLine("Printing every"+amount);
			Console.WriteLine(Id + " Ascending: ");
			for (int i = 0; i < Ascending.Length; i++)
				{
					if (i % amount == 0)
					{
						Console.WriteLine(Ascending[i]);
					}
				}
			Console.WriteLine(Id+" Descending: ");
			for (int i = 0; i<Ascending.Length; i++)
			{
				if (i % amount == 0)
				{
					Console.WriteLine(Descending[i]);
				}
			}
		}
	}
}