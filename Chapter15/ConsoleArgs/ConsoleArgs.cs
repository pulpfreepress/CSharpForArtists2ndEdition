/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class ConsoleArgs {
	public static void Main(String[] args){
		try{
				Console.WriteLine(args[0]);
		}catch(IndexOutOfRangeException e){
			Console.WriteLine("  HelpLink: " + e.HelpLink);
			Console.WriteLine("   Message: " + e.Message);
			Console.WriteLine("    Source: " + e.Source);
			Console.WriteLine("TargetSite: " + e.TargetSite.Name);
			Console.WriteLine("StackTrace: " + e.StackTrace);
		}
	}
}