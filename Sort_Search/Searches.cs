namespace Sort_Search
{
	class Searches
	{
		public static int[] Linear_Search(int[] arr, int value)
		{
			Console.WriteLine("Searching for " + value);
			var list = new List<int>(); // create a list to store the indexes of the value
			for (int i = 0; i < arr.Length; i++) // loop through the array
			{
				if (arr[i] == value) // if the value is found
				{
					list.Add(i); // add the index to the list
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
					for (int i = 0; i < arr.Length; i++) // loop through the array
					{
						if (arr[i] == above || arr[i] == below) // if the value is found
						{
							list.Add(i);
						}
					}
					if (above < 999) { above++; } // keeps the values within the correct range of 0-1000
					if (below > 0) { below--; }
				}
			}
			return list.ToArray();
		}
		public static int[] Binary_Search(int[] arr, int value, bool first_Pass)
		{
			List<int> indexes = new List<int>(); // create a list to store the indexes of the value

			int min = 0;
			int max = arr.Length - 1;

			while (min <= max) // loop until the value is found
			{
				int mid = (min + max) / 2;

				if (arr[mid] == value)
				{
					// Value found, find all occurrences
					int lower = mid - 1;
					while (lower >= 0 && arr[lower] == value) // add all the indexes below the middle index
					{
						indexes.Add(lower);
						lower--;
					}
					indexes.Add(mid); // add the middle index

					int upper = mid + 1;
					while (upper < arr.Length && arr[upper] == value) // add all the indexes above the middle index
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
				while (indexes.Count==0) // while a value has not been found
				{					
					if (above <= 999) 
					{ 
						above++;
						indexes.AddRange(Binary_Search(arr, above, false)); // add the indexes to the list
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