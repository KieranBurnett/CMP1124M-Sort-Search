using System.Runtime.CompilerServices;

namespace Sort_Search
{
	class Road
	{
		public int[] Arr;
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
				Arr = list.ToArray();
			}
			catch
			{
				Console.WriteLine($"Problem with finding {road_Directory}");
			}
			Arr = list.ToArray();
			Ascending = Sorts.Bubble_Sort(Arr, true);
			Descending = Sorts.Reverse(Ascending);
		}
	}
}