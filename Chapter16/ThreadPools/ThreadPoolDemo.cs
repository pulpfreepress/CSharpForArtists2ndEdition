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

public class ThreadPoolDemo {

	private const int COUNT = 20000;

	public static void Run(object stateInfo){
		for(int i=0; i<COUNT; i++){
			Console.Write(stateInfo + " ");
			Thread.Sleep(100);
		}
	}

	public static void Main(){
		int workerThreads = 0;
		int completionPortThreads = 0;
		ThreadPool.GetMinThreads(out workerThreads, out completionPortThreads);
		Console.WriteLine("Minimum number of worker threads in thread pool: {0} ", 
											workerThreads);
		Console.WriteLine("Minimum number of completion port threads in thread pool: {0} ", 
											completionPortThreads);
		ThreadPool.GetAvailableThreads(out workerThreads, out completionPortThreads);
		Console.WriteLine("Available worker threads in thread pool: {0} ", workerThreads);
		Console.WriteLine("Available completion port threads in thread pool: {0} ", 
											completionPortThreads);

		for(int i = 0; i<45; i++){
			ThreadPool.QueueUserWorkItem(new WaitCallback(Run), i);
			Thread.Sleep(1000); // sleep twice as long as it takes to start a threadpool thread
			ThreadPool.GetAvailableThreads(out workerThreads, out completionPortThreads);
			Console.Write("\nAvailable worker threads in thread pool: {0} ", workerThreads);
			Console.WriteLine("\nAvailable completion port threads in thread pool: {0}", 
												completionPortThreads);
		}
	} // end Main() method
} // end class definition