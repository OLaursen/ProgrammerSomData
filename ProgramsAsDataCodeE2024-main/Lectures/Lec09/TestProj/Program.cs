
using System;
using System.Text;		// For StringBuilder
using System.Diagnostics;       // For Stopwatch
using System.Collections.Generic;

public class Program
{
    public static void Main(String[] args)
	{
		Queue<Queue<int>> q = new();

		Console.WriteLine("Press return to continue...");
		Console.ReadLine();

		buildList(q, 50000000);
		Console.WriteLine("Initialization: Building array of small strings");

		destroyList(q, 50000000);

		buildList(q, 50000000);

		destroyList(q, 50000000);

		Console.WriteLine("Finished!");
	}

	private static void buildList(Queue<Queue<int>> q, int n)
	{
		for (int i = 0; i < n; i++)
		{
			q.Enqueue(new Queue<int>());
		}
	}

	private static void destroyList(Queue<Queue<int>> q, int n)
	{
		for (int i = 0; i < n; i++)
		{
			q.Dequeue();
		}
	}
}

