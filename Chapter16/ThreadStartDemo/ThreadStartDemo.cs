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

public class ThreadStartDemo {
	private const int COUNT = 200;

	public static void Run(){
		for(int i=0; i<COUNT; i++){
			Console.Write(Thread.CurrentThread.Name);
		}
	}
  
	public static void Main(){
		Thread thread1 = new Thread(new ThreadStart(Run)); // longhand way
		Thread thread2 = new Thread(Run); // shorthand way
		thread1.Name = "1";
		thread1.Start();
		thread2.Name = "2";
		thread2.Start();
	} // end Main()
} // end class