/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class IfStatementTest {
  static void Main(String[] args){
    int int_i = Convert.ToInt32(args[0]);
    int int_j = Convert.ToInt32(args[1]);

    if(int_i < int_j) 
      Console.WriteLine(int_i + " is less than " + int_j);
    
  }
}
