using System.IO;
using System.Linq;

internal class Program
{
	private static void Main(string[] args)
	{
		// read groovy code, write class,
		string[] R1_256_string = File.ReadAllLines(@"C:\Users\Kieran\Desktop\Sort-Search\Road_1_256.txt");
		int[] R1_256;
		foreach (string r in R1_256_string) { R1_256.Append(r); }
		string[] R2_256_string = File.ReadAllLines(@"C:\Users\Kieran\Desktop\Sort-Search\Road_2_256.txt");
		string[] R3_256_string = File.ReadAllLines(@"C:\Users\Kieran\Desktop\Sort-Search\Road_3_256.txt");

		int choice;
		string[] road;
		while (true)
		{
			try
			{
				Console.WriteLine("Which array out of the following;\n(1) Road_1_256,\n(2) Road_2_256,\n(3) Road_3_256, ");
				choice = int.Parse(Console.ReadLine()); // Reads input
				if (choice > 0 && choice < 4) // prevent out of bound errors
				{ 
					if (choice == 1) { road = R1_256;  }
					else if (choice == 2) { road = R2_256; }
					else if (choice == 3) { road = R3_256; }
					break; 
				} 
				else { Console.WriteLine("Not a valid number"); }
			}
			catch 
			{
				Console.WriteLine("Not a number");
			}
		}
		while (true)
		{
			try
			{
				Console.WriteLine("1.Ascending or 2.Descending ");
				choice = int.Parse(Console.ReadLine()); // Reads input
				if (choice == 1 || choice == 2) // prevent out of bound errors
				{
					if (choice == 1) 
					{
						//Write own ascending sort, cant use array.sort()
					}
					else if (choice == 2) { road = R2_256; }
					else if (choice == 3) { road = R3_256; }
					break;
				}
				else { Console.WriteLine("Not a valid number"); }
			}
		}
		
	}
}