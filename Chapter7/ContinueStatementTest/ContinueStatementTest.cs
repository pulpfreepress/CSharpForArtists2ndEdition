/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class ContinueStatementTest {
  static void Main(String[] args){
    try{
      int limit_i = Convert.ToInt32(args[0]);
      
      for(int i = 0; i<limit_i; i++){
        if((i % 2) == 0) continue;
        Console.WriteLine(i);
      }
    }catch(IndexOutOfRangeException){
       Console.WriteLine("This program requires one integer argument!");
    }catch(FormatException){
       Console.WriteLine("Argument must be a valid integer!");
    }
  }
}
