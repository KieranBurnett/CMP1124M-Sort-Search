using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort_Search
{
	class Searches
	{
		public static int[] Linear_Search(int[] arr, int value)
		{
			Console.WriteLine("Searching for "+value);
			var list = new List<int>();
			for (int i = 0; i < arr.Length; i++)
			{
				if (arr[i] == value)
				{
					list.Add(i);
				}
			}
			// if list is empty, rerun the method using the number above and below the value
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
					below--;
				}
			}
			return list.ToArray();
		}
		public static int[] Binary_Search(int[] arr, int value)
		{
			Console.WriteLine("Searching for " + value);
			var list = new List<int>();
			int[] sorted = Sorts.Selection_Sort(arr);
			int min = 0;
			int max = sorted.Length - 1;
			int mid = (min + max) / 2;
			while (min <= max)
			{
				if (sorted[mid] == value)
				{
					list.Add(mid);
					break;
				}
				else if (sorted[mid] < value)
				{
					min = mid + 1;
				}
				else
				{
					max = mid - 1;
				}
				mid = (min + max) / 2;
			}
			// if list is empty, rerun the method using the number above and below the value
			if (list.Count == 0)
			{
				int above = value + 1;
				int below = value - 1;
				while (list.Count == 0)
				{
					Console.WriteLine("Now looking for " + above + " and " + below + ".");
					for (int i = 0; i < sorted.Length; i++)
					{
						if (sorted[i] == above || sorted[i] == below)
						{
							list.Add(i);
						}
					}
					above++;
					below--;
				}
			}
			return list.ToArray();
		}
	}
}
