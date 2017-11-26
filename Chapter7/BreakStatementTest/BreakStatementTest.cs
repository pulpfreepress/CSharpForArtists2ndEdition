/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class BreakStatementTest {
  static void Main(){
     for(int i = 0; i < 2; i++){
         for(int j = 0; j < 1000; j++){
           Console.WriteLine("Inner for loop - j = " + j);
           if(j == 3) break;
            }
        Console.WriteLine("Outer for loop - i = " + i);
      }
  }
}
