namespace Sort_Search
{
	class Sorts
	{
		/*
		public static int[] Flip(int[] arr)
		{
			int[] Descending = new int[arr.Length];
			for (int i = 0; i < arr.Length; i++)
			{
				Descending[i] = arr[arr.Length - 1 - i];
			}
			return Descending;
		}*/
		public static int[] Bubble_Sort(int[] arr, bool ascending)
		{
			int[] sorted = new int[arr.Length];
			for (int i = 0; i < arr.Length; i++)
			{
				sorted[i] = arr[i];
			}
			int temp;
			for (int i = 0; i < sorted.Length - 1; i++)
			{
				for (int j = 0; j < sorted.Length - i - 1; j++)
				{
					if (ascending)
					{
						if (sorted[j] > sorted[j + 1])
						{
							temp = sorted[j];
							sorted[j] = sorted[j + 1];
							sorted[j + 1] = temp;
						}
					}
					else
					{
						if (sorted[j] < sorted[j + 1])
						{
							temp = sorted[j];
							sorted[j] = sorted[j + 1];
							sorted[j + 1] = temp;
						}
					}
				}
			}
			return sorted;
		}
		public static int[] Insertion_Sort(int[] arr, bool ascending)
		{
			int[] sorted = new int[arr.Length];
			for (int i = 0; i < arr.Length; i++)
			{
				sorted[i] = arr[i];
			}
			int temp;
			for (int i = 1; i < sorted.Length; i++)
			{
				for (int j = i; j > 0; j--)
				{
					if (ascending)
					{ 
						if (sorted[j] < sorted[j - 1])
						{
							temp = sorted[j];
							sorted[j] = sorted[j - 1];
							sorted[j - 1] = temp;
						}
					}
					else
					{
						if (sorted[j] > sorted[j - 1])
						{
							temp = sorted[j];
							sorted[j] = sorted[j - 1];
							sorted[j - 1] = temp;
						}
					}
				}
			}
			return sorted;
		}
		public static int[] Selection_Sort(int[] arr, bool ascending)
		{
			int[] sorted = new int[arr.Length];
			for (int i = 0; i < arr.Length; i++)
			{
				sorted[i] = arr[i];
			}
			int temp;
			for (int i = 0; i < sorted.Length - 1; i++)
			{
				int min = i;
				for (int j = i + 1; j < sorted.Length; j++)
				{
					if (ascending)
					{
						if (sorted[j] < sorted[min])
						{
							min = j;
						}
					}
					else
					{
						if (sorted[j] > sorted[min])
						{
							min = j;
						}
					}
				}
				temp = sorted[i];
				sorted[i] = sorted[min];
				sorted[min] = temp;
			}
			return sorted;
		}
		public static int[] Quick_Sort(int[] arr, bool ascending)
		{
			if (arr.Length <= 1)
			{
				return arr;
			}
			int pivot = arr[arr.Length / 2];
			if (ascending)
			{
				int[] left = arr.Where(x => x < pivot).ToArray();
				int[] middle = arr.Where(x => x == pivot).ToArray();
				int[] right = arr.Where(x => x > pivot).ToArray();
				return (Quick_Sort(left, true).Concat(middle).Concat(Quick_Sort(right, true)).ToArray());
			}
			else
			{
				int[] left = arr.Where(x => x > pivot).ToArray();
				int[] middle = arr.Where(x => x == pivot).ToArray();
				int[] right = arr.Where(x => x < pivot).ToArray();
				return (Quick_Sort(left, false).Concat(middle).Concat(Quick_Sort(right, false)).ToArray());
			}
		}
	}
}