using System;
using System.Diagnostics;

/*
    Accessing multidimensional array
    RunTime 00:00:00.72
	RunTime 00:00:00.70
	RunTime 00:00:00.70
	RunTime 00:00:00.70
	RunTime 00:00:00.68
	Accessing jagged array
	RunTime 00:00:00.65
	RunTime 00:00:00.69
	RunTime 00:00:00.66
	RunTime 00:00:00.67
	RunTime 00:00:00.69
 */
namespace CSharpArrayCompare
{
    static class Constants
	{
		public const int NumArrays = 100000;
        public const int NumTries = 5;
        public const int ArraySize = 100;

	}
    class MainClass
    {
        public static void Main(string[] args)
        {
            Stopwatch stopWatch;

            Console.Out.WriteLine("Accessing multidimensional array");
			for (int i = 0; i < Constants.NumTries; i++)
            {
                stopWatch = Stopwatch.StartNew();
                ProccessMultiDimensionalArray();
                stopWatch.Stop();
                PrintRunTime(stopWatch);
            }

			Console.Out.WriteLine("Accessing jagged array");
			for (int i = 0; i < Constants.NumTries; i++)
			{
				stopWatch = Stopwatch.StartNew();
				ProccessJaggedArray();
				stopWatch.Stop();
				PrintRunTime(stopWatch);
			}

        }

        public static void PrintRunTime(Stopwatch stopWatch)
        {
			// Get the elapsed time as a TimeSpan value.
			TimeSpan ts = stopWatch.Elapsed;

			// Format and display the TimeSpan value.
			string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
				ts.Hours, ts.Minutes, ts.Seconds,
				ts.Milliseconds / 10);
			Console.Out.WriteLine("RunTime " + elapsedTime);
        }

        public static void ProccessMultiDimensionalArray()
        {
            int[,] multiArr = BuildMultiDimensionalArray();
            AccessMultiDimensionalArray(multiArr);
        }

		public static void ProccessJaggedArray()
		{
			int[][] jaggedArr = BuildJaggedArray();
			AccessJaggedArray(jaggedArr);
		}

        public static int[,] BuildMultiDimensionalArray()
        {
            Random r = new Random();
            int[,] arrays = new int[Constants.NumArrays, Constants.ArraySize];
            for (int i = 0; i < Constants.NumArrays; i++)
            {
                for (int j = 0; j < Constants.ArraySize; j++)
                {
                    arrays[i, j] = r.Next(0, 100);
                }
            }
            return arrays;
        }

        public static void AccessMultiDimensionalArray(int[,] array)
        {
            Random r = new Random();
			for (int i = 0; i < Constants.NumArrays; i++)
			{
				int val = array[i, r.Next(0, Constants.ArraySize - 1)];
			}
        }

		public static int[][] BuildJaggedArray()
		{
			Random r = new Random();
			int[][] arrays = new int[Constants.NumArrays][];
			for (int i = 0; i < Constants.NumArrays; i++)
			{
                arrays[i] = new int[Constants.ArraySize];
				for (int j = 0; j < Constants.ArraySize; j++)
				{
					arrays[i][j] = r.Next(0, 100);
				}
			}
			return arrays;
		}

		public static void AccessJaggedArray(int[][] array)
		{
			Random r = new Random();
			for (int i = 0; i < Constants.NumArrays; i++)
			{
				int val = array[i][r.Next(0, Constants.ArraySize - 1)];
			}
		}
    }
}
