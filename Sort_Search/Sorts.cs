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
			int[] sorted = (int[])arr.Clone(); // create a new array to store the sorted values
			int temp;
			for (int i = 0; i < sorted.Length - 1; i++) // loop through the array
			{
				for (int j = 0; j < sorted.Length - i - 1; j++)
				{
					if (ascending)
					{
						if (sorted[j] > sorted[j + 1]) // if the current index value is greater that the one above
						{
							temp = sorted[j]; // swap
							sorted[j] = sorted[j + 1];
							sorted[j + 1] = temp;
						}
					}
					else
					{
						if (sorted[j] < sorted[j + 1]) // if the current index value is less than the one above
						{
							temp = sorted[j]; // swap
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
			int[] sorted = (int[])arr.Clone(); // create a new array to store the sorted values
			int temp;
			for (int i = 1; i < sorted.Length; i++) // loop through whole array
			{
				for (int j = i; j > 0; j--) // for every value less that the current index
				{
					if (ascending)
					{ 
						if (sorted[j] < sorted[j - 1]) // slots the number into the correct spot
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
			int[] sorted = (int[])arr.Clone(); // create a new array to store the sorted values
			int temp;
			for (int i = 0; i < sorted.Length - 1; i++) // loops through the array
			{
				int min = i;
				for (int j = i + 1; j < sorted.Length; j++) // for every value above the current index
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
				temp = sorted[i]; // swaps values
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
				int[] left = arr.Where(x => x < pivot).ToArray(); // left side is less than pivot point
				int[] middle = arr.Where(x => x == pivot).ToArray();
				int[] right = arr.Where(x => x > pivot).ToArray();
				return (Quick_Sort(left, true).Concat(middle).Concat(Quick_Sort(right, true)).ToArray());
			}
			else
			{
				int[] left = arr.Where(x => x > pivot).ToArray(); // left side is greater than pivot point
				int[] middle = arr.Where(x => x == pivot).ToArray();
				int[] right = arr.Where(x => x < pivot).ToArray();
				return (Quick_Sort(left, false).Concat(middle).Concat(Quick_Sort(right, false)).ToArray());
			}
		}
	}
}