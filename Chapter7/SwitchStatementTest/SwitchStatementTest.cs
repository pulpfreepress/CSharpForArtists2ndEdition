/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class SwitchStatementTest {
  public static void Main(String[] args){
    try{
      int int_i = Convert.ToInt32(args[0]);
      
      switch(int_i){
        case 1: Console.WriteLine("You entered one");
                break;
        case 2: Console.WriteLine("You entered two");
                break;
        case 3: Console.WriteLine("You entered three");
                break;
        case 4: Console.WriteLine("You entered four");
                break;
        case 5: Console.WriteLine("You entered five");
                break;
        default: Console.WriteLine("Please enter a number between 1 and 5");
                 break;
        }
      }catch(IndexOutOfRangeException){
         Console.WriteLine("Enter one number at the command-line!");
      }catch(FormatException){
         Console.WriteLine("You entered an invalid number! Try again.");
      }
      
  }
}