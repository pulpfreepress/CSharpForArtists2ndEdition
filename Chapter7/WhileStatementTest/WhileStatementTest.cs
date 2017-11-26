/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class WhileStatementTest {
   static void Main(){
      int int_i = 0;

      while(int_i < 10){
        Console.WriteLine("The value of int_i = " + int_i);
        int_i++;
      }     
   }
}