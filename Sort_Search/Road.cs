using System.Runtime.CompilerServices;

namespace Sort_Search
{
	class Road
	{
		public int[] Arr { get; set; }
		public int[] Ascending { get; set; }
		public int[] Descending { get; set; }
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
			catch (Exception e)
			{
				Console.WriteLine($"Exception caught when loading {road_Directory} -> {e}");
			}
			Arr = list.ToArray();
			Sorts sorts = new Sorts();
			Ascending = sorts.Bubble_Sort(Arr, true);
			Descending = sorts.Bubble_Sort(Arr, false);
		}
	}
}