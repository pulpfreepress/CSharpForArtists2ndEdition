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

public class AsyncCallWithCallBackDemo {
  
  private const int COUNT = 100;
  public delegate int SumDelegate(int a, int b);
  
  public static int Sum(int a, int b){
    return a + b;
  }
  
  public static void WrapUp(IAsyncResult result){
    SumDelegate sumDelegate = (SumDelegate)result.AsyncState;
		int sum = sumDelegate.EndInvoke(result);
		Console.WriteLine("The result is: {0} ", sum);
  }
  
  public static void Main(){
		SumDelegate sumDelegate1 = new SumDelegate(Sum);
		SumDelegate sumDelegate2 = new SumDelegate(Sum);
		IAsyncResult result1 = sumDelegate1.BeginInvoke(1, 2, new AsyncCallback(WrapUp), sumDelegate1);
		IAsyncResult result2 = sumDelegate2.BeginInvoke(3, 4, new AsyncCallback(WrapUp), sumDelegate2);
		while(!(result1.IsCompleted && result2.IsCompleted)){
			Thread.Sleep(10);
		}
		Console.WriteLine("\nMain thread exiting now...bye!");
  } // end Main() method
} // end class definition