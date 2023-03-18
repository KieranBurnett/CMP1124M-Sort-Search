using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sort_Search
{
	class Searches
	{
		// o(n)
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
					below--;
				}
			}
			return list.ToArray();
		}
		// as binary only finds one value, could then look left and right however than results in o(n) for large sample sizes
		// instead do recursive binary seach each side to remain with o(log(n))
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
					// begin recursive binary search above and below
					int upperBound = mid - 1;
					int i = upperBound;
					do
					{
						upperBound = i;
						// doesnt work as Binary_search returns an array but i is an int, mean bottom index and top index
						// will have to be stored outside the method
						// to go for values above and below it will have to be a for loop until its broken if a value is found
						i = Binary_Search(arr, value);
					} while (i != -1)
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
			// if list is empty,try using the number above and below the value,
			
			return list.ToArray();
		}
	}
}
