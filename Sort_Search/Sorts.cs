namespace Sort_Search
{
	class Sorts
	{
		internal int[] Bubble_Sort(int[] array, bool Ascending)
		{
			int temp;
			for (int i = 0; i < array.Length; i++)
			{
				for (int n = 0; n < array.Length - 1; n++)
				{
					if (Ascending) 
					{
						if (array[n] > array[n + 1])
						{
							temp = array[n + 1]; array[n+1] = array[n]; array[n] = temp;
						}
					}
					else
					{
						if (array[n] < array[n + 1])
						{
							temp = array[n + 1]; array[n + 1] = array[n]; array[n] = temp;
						}
					}
				}
			}
			return array;
		}
	}
}
