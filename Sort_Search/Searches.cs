namespace Sort_Search
{
	class Searches
	{
		public static int[] Linear_Search(int[] arr, int value)
		{
			Console.WriteLine("Searching for " + value);
			var list = new List<int>();
			for (int i = 0; i < arr.Length; i++)
			{
				if (arr[i] == value)
				{
					list.Add(i);
				}
			}
			// if list is empty, try using the number above and below the value
			if (list.Count == 0)
			{
				int above = value + 1;
				int below = value - 1;
				while (list.Count == 0)
				{
					Console.WriteLine("Now looking for " + above + " and " + below + ".");
					for (int i = 0; i < arr.Length; i++)
					{
						if (arr[i] == above || arr[i] == below)
						{
							list.Add(i);
						}
					}
					above++;
					if (below > 0) { below--; }
				}
			}
			return list.ToArray();
		}
		public static int[] Binary_Search(int[] arr, int value, bool first_Pass)
		{
			List<int> indexes = new List<int>();

			int min = 0;
			int max = arr.Length - 1;

			while (min <= max)
			{
				int mid = (min + max) / 2;

				if (arr[mid] == value)
				{
					// Value found, find all occurrences
					int lower = mid - 1;
					while (lower >= 0 && arr[lower] == value)
					{
						indexes.Add(lower);
						lower--;
					}
					indexes.Add(mid);

					int upper = mid + 1;
					while (upper < arr.Length && arr[upper] == value)
					{
						indexes.Add(upper);
						upper++;
					}
					return indexes.ToArray();
				}
				else if (arr[mid] < value)
				{
					min = mid + 1;
				}
				else
				{
					max = mid - 1;
				}
			}
			// Value not found, try next larger and smaller values
			if (indexes.Count == 0 && first_Pass)
			{
				Console.WriteLine("Unable to find "+value);
				int above = value;
				int below = value;
				while (indexes.Count==0)
				{					
					if (above <= 999) 
					{ 
						above++;
						indexes.AddRange(Binary_Search(arr, above, false)); 
					}
					if (below > 0) 
					{ 
						below--;
						indexes.AddRange(Binary_Search(arr, below, false));
					}
					Console.WriteLine("Now looking for " + above + " and " + below + ".");
				}
			}
			return indexes.ToArray();
		}
	}
}