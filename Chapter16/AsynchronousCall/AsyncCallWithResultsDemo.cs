/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.Threading;

public class AsyncCallWithResultsDemo {

	private const int COUNT = 100;
	public delegate int SumDelegate(int a, int b);

	public static int Sum(int a, int b){
		return a + b;
	}

	public static void Main(){
		SumDelegate sumDelegate1 = new SumDelegate(Sum);
		SumDelegate sumDelegate2 = new SumDelegate(Sum);
		IAsyncResult result1 = sumDelegate1.BeginInvoke(1, 2, null, null);
		IAsyncResult result2 = sumDelegate2.BeginInvoke(3, 4, null, null);
		while(!(result1.IsCompleted && result2.IsCompleted)){
			Thread.Sleep(100);
		}
		int sum1 = sumDelegate1.EndInvoke(result1);
		int sum2 = sumDelegate2.EndInvoke(result2);
		Console.WriteLine("The result of the first async method call is: {0}", sum1);
		Console.WriteLine("The result of the second async method call is: {0}", sum2);
		Console.WriteLine("\nMain thread exiting now...bye!");
	} // end Main() method
} // end class definition