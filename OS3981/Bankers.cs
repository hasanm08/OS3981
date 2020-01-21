
using System;
using System.Collections.Generic;
using System.Windows;

class Bankers
{
	static int n = 5; 
	static int m = 3;  
	int[,] need = new int[n, m];
	int[,] max;
	int[,] alloc;
	int[] avail;
	int[] safeSequence = new int[n];

	//public GFG(int[,] need, int[,] max, int[,] alloc, int[] avail, int[] safeSequence)
	//{
	//	this.need = need;
	//	this.max = max;
	//	this.alloc = alloc;
	//	this.avail = avail;
	//	this.safeSequence = safeSequence;
	//}

	string initializeValues()
	{
		string res = "";
		
		   alloc = new int[,] {{ 0, 1, 0 },
						{ 2, 0, 0 },
						{ 3, 0, 2 },
						{ 2, 1, 1 },
						{ 0, 0, 2 }};
		max = new int[,] {{ 7, 5, 3 },
						{ 3, 2, 2 },
					{ 9, 0, 2 },
					{ 2, 2, 2 },
					{ 4, 3, 3 }};
		avail = new int[] { 3, 3, 2 };
		for (int i = 0; i < alloc.GetLength(0); i++)
		{
			for (int j = 0; j < alloc.GetLength(1); j++)
			{
				res += "A(" + i.ToString() + "," + j.ToString() + ") =" + alloc[i, j].ToString() + "\n";

			}
		}
		for (int i = 0; i < max.GetLength(0); i++)
		{
			for (int j = 0; j < max.GetLength(1); j++)
			{
				res += "C(" + i.ToString() + "," + j.ToString() + ") =" + max[i, j].ToString() + "\n";

			}
		}
		
		return res;
	}

	string isSafe()
	{
		string res = "";
		int count = 0;

		Boolean[] visited = new Boolean[n];
		for (int i = 0; i < n; i++)
		{
			visited[i] = false;
		}
 
		int[] work = new int[m];
		for (int i = 0; i < m; i++)
		{
			work[i] = avail[i];
			res += "V(" + i.ToString() + ") =" + work[i].ToString()+"\n";

		}
		

		while (count < n)
		{
			Boolean flag = false;
			for (int i = 0; i < n; i++)
			{
				if (visited[i] == false)
				{
					int j;
					for (j = 0; j < m; j++)
					{
						if (need[i, j] > work[j])
							break;
					}
					if (j == m)
					{
						safeSequence[count++] = i;
						visited[i] = true;
						flag = true;
						for (j = 0; j < m; j++)
						{
							work[j] = work[j] + alloc[i, j];

							res += "V(" + j.ToString() + ") =" + work[j].ToString() + "\n";
						}
					}
				}
			}
			if (flag == false)
			{
				break;
			}
		}
		if (count < n)
		{
			
			res+=("The System is UnSafe!\n");
		}
		else
		{
			
			res+=("Following is the SAFE Sequence\n");
			for (int i = 0; i < n; i++)
			{
				res+=("P" + safeSequence[i]);
				if (i != n - 1)
					res+=(" -> ");
			}
		}
		return res;
	}

	string calculateNeed()
	{
		string res = "\n";
		for (int i = 0; i < n; i++)
		{
			for (int j = 0; j < m; j++)
			{
				need[i, j] = max[i, j] - alloc[i, j];
				res += "C-A(" + i.ToString() + "," + j.ToString() + ") =" +need[i,j].ToString()+"\n";
			}
		}
		return res;
	}
 
	public static string start()
	{
		string res = "";
		Bankers gfg = new Bankers();

		res+=gfg.initializeValues();

		res+=gfg.calculateNeed();

		res+="\n"+gfg.isSafe();
		return res;
	}
}

