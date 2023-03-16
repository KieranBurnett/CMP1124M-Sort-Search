namespace Sort_Search
{
	class Road
	{
		internal static int[] Road_Data(string road_Directory)
		{
			var list = new List<int>();
			try
			{
				var data = File.ReadAllLines(road_Directory);
				foreach (string s in data)
				{
					list.Add(int.Parse(s));
				}
				return list.ToArray();
			}
			catch (Exception e)
			{
				Console.WriteLine($"Exception caught when loading {road_Directory} -> {e}");
			}
			return list.ToArray();
		}
	}
}