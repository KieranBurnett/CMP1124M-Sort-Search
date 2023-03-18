using System.Runtime.InteropServices;

namespace Sort_Search
{
	class Sorts
	{
		public static int[] Reverse(int[] arr)
		{
			int temp;
			for (int i = 0; i < arr.Length / 2; i++)
			{
				temp = arr[i];
				arr[i] = arr[arr.Length - i - 1];
				arr[arr.Length - i - 1] = temp;
			}
			return arr;
		}
		public static int[] Bubble_Sort(int[] arr, bool Ascending)
		{
			int temp;
			for (int i = 0; i < arr.Length; i++)
			{
				for (int n = 0; n < arr.Length - 1; n++)
				{
					if (Ascending) 
					{
						if (arr[n] > arr[n + 1])
						{
							temp = arr[n + 1]; arr[n+1] = arr[n]; arr[n] = temp;
						}
					}
					else
					{
						if (arr[n] < arr[n + 1])
						{
							temp =	arr[n + 1]; arr[n + 1] = arr[n]; arr[n] = temp;
						}
					}
				}
			}
			return arr;
		}
		public static int[] Insertion_Sort(int[] arr)
		{
			int i, key, j;
			for (i = 1; i < arr.Length; i++)
			{
				key = arr[i];
				j = i - 1;
				while (j >= 0 && arr[j] > key)
				{
					arr[j + 1] = arr[j];
					j = j - 1;
				}
				arr[j + 1] = key;
			}
			return arr;
		}
	}
}
