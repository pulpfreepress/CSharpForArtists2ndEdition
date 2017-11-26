/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class CommandLineAdder {
	public static void Main(String[] args){
		try{
			int total = 0;
			for(int i=0; i<args.Length; i++){
				total += Int32.Parse(args[i]);
			}
			Console.WriteLine("You entered {0} arguments and their total comes to {1}", 
												args.Length, total);
		}catch(FormatException){
			Console.WriteLine("One or more arguments failed to convert to an integer!");
		}catch(Exception){
			Console.WriteLine("The program encountered an unknown problem...");
		}finally{
			Console.WriteLine("Thank you for using Command Line Adder!");
		}
	}
}