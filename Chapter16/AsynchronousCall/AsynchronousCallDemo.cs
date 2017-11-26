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

public class AsynchronousCallDemo {
  
  private const int COUNT = 100;
  public delegate void RunDelegate(String message);
  
  public static void Run(String message){
    for(int i=0; i<COUNT; i++){
			Console.Write(message + " ");
			Thread.Sleep(100);
		}
  }
  
  public static void Main(){
		RunDelegate runDelegate1 = new RunDelegate(Run);
		RunDelegate runDelegate2 = new RunDelegate(Run);
		IAsyncResult result1 = runDelegate1.BeginInvoke("Hello", null, null);
		IAsyncResult result2 = runDelegate2.BeginInvoke("World!", null, null);
		while(!(result1.IsCompleted && result2.IsCompleted)){
			Console.Write(" - ");
			Thread.Sleep(1000);
		}
		runDelegate1.EndInvoke(result1);
		runDelegate2.EndInvoke(result2);
		Console.WriteLine("\nMain thread exiting now...bye!");
  } // end Main() method
} // end class definition