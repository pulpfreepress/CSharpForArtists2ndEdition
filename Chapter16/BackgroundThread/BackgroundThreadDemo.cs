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

public class BackgroundThreadDemo {

	public static void Run(){
		bool keepgoing = true;
		while(keepgoing){
			Console.Write("Please enter a letter or 'Q' to exit: ");
			String s = Console.ReadLine();
			switch(s[0]){
				case 'Q': keepgoing = false;
									break;
				default: break;
			}
		}
	}

	public static void Main(){
		Thread thread1 = new Thread(Run);
		thread1.IsBackground = true;
		thread1.Start();
	} // end Main()
} // end class