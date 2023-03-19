using System.Linq;

namespace Sort_Search
{
	class Searches
	{
		// o(n)
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
		public static int[] BinarySearch(int[] arr, int value)
		{
			if (value < 0 || value > 999)
			{
				return new int[] { };
			}

			List<int> indices = new List<int>();

			int left = 0;
			int right = arr.Length - 1;
			int mid;

			while (left <= right)
			{
				mid = (left + right) / 2;

				if (arr[mid] == value)
				{
					indices.Add(mid);

					// Find lower bound
					int lower = mid - 1;
					while (lower >= 0 && arr[lower] == value)
					{
						indices.Add(lower);
						lower--;
					}

					// Find upper bound
					int upper = mid + 1;
					while (upper < arr.Length && arr[upper] == value)
					{
						indices.Add(upper);
						upper++;
					}

					return indices.ToArray();
				}
				else if (arr[mid] < value)
				{
					left = mid + 1;
				}
				else
				{
					right = mid - 1;
				}
			}

			// If target value is not found, search for next closest values
			int greater = value + 1;
			int lesser = value - 1;

			while (indices.Count == 0 && (greater <= 999 || lesser >= 0))
			{
				if (greater <= 999)
				{
					int leftIndex = 0;
					int rightIndex = arr.Length - 1;

					while (leftIndex <= rightIndex)
					{
						int midIndex = (leftIndex + rightIndex) / 2;

						if (arr[midIndex] == greater)
						{
							indices.Add(midIndex);
							break;
						}
						else if (arr[midIndex] < greater)
						{
							leftIndex = midIndex + 1;
						}
						else
						{
							rightIndex = midIndex - 1;
						}
					}

					greater++;
				}

				if (lesser >= 0)
				{
					int leftIndex = 0;
					int rightIndex = arr.Length - 1;

					while (leftIndex <= rightIndex)
					{
						int midIndex = (leftIndex + rightIndex) / 2;

						if (arr[midIndex] == lesser)
						{
							indices.Add(midIndex);
							break;
						}
						else if (arr[midIndex] < lesser)
						{
							leftIndex = midIndex + 1;
						}
						else
						{
							rightIndex = midIndex - 1;
						}
					}

					lesser--;
				}
			}

			return indices.ToArray();
		}

	}
}
