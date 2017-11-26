/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class IfElseStatementTest {
  public static void Main(String[] args){
  
  try{
   int int_i = Convert.ToInt32(args[0]);
   int int_j = Convert.ToInt32(args[1]);

   if(int_i < int_j) {
	Console.Write("Yes ");
        Console.WriteLine(int_i + " is less than " + int_j);
     } else {
        Console.Write("No ");
        Console.WriteLine(int_i + " is not less than " + int_j);
        }
        
    }catch(IndexOutOfRangeException){
     Console.WriteLine("You must enter two integer numbers! Please try again.");
   }catch(FormatException){
     Console.Write("One of the arguments you entered was not a valid integer value! ");
     Console.WriteLine("Please try again.");
   }
  }
}
