/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class Test {
	public static void Main(){
		bool keep_going = true;
		String input;
		while(keep_going){
			try{
				input = Console.ReadLine();
				Console.WriteLine("The first letter of the string is: " + input[0]);
	  	}catch(Exception){
				
		  }
		}
	}
}