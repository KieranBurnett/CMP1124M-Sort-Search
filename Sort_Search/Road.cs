namespace Sort_Search
{
	class Road
	{
		public int[] Unsorted_array;
		public int[] Ascending;
		public int[] Descending;
		public Road(string road_Directory)
		{
			var list = new List<int>();
			try
			{
				var data = File.ReadAllLines(road_Directory);
				foreach (string s in data)
				{
					list.Add(int.Parse(s));
				}
				Unsorted_array = list.ToArray();
			}
			catch
			{
				Console.WriteLine($"Problem with finding {road_Directory}");
			}
			Unsorted_array = list.ToArray();
			Ascending = Sorts.Selection_Sort(Unsorted_array);
			Descending = Sorts.Flip(Ascending);
		}
	}
}