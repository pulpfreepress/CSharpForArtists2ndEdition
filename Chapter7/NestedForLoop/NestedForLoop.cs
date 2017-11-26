/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class NestedForLoop {
  static void Main(String[] args){
    try{
      int limit_i = Convert.ToInt32(args[0]);
      int limit_j = Convert.ToInt32(args[1]);
      int total = 0;

      for(int i = 1; i <= limit_i; i++){
        for(int j = 1; j <= limit_j; j++){
          total += (i*j);
        }
      }
      Console.WriteLine("The total is: " + total);
    }catch(IndexOutOfRangeException){
       Console.WriteLine("Two arguments are required to run this program!");
    }catch(FormatException){
       Console.WriteLine("Both arguments must be integers!");
    }
  }
}
