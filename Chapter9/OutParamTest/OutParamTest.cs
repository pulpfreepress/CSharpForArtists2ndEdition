/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class OutParamTest {
  int  _a = 2;
  int  _count = 10;
  long _result;
  
  public void Factor(int value, int power, out long total){
    total = 1;
    for(int i = 1; i <= power; i++){
      total = total * value;
      Console.WriteLine("Value of i is {0} and value of total is {1}", i, total);
    }
  }
  
  public void Run(){
    Console.WriteLine("The value of _result before calling Factor is: " + _result);
    Console.WriteLine("----------------------------------------------------------");
    Factor(_a, _count, out _result);
     Console.WriteLine("----------------------------------------------------------");
    Console.WriteLine("The value of _result after calling Factor is: " + _result); 
  }

  public static void Main(){
    OutParamTest pt = new OutParamTest();
    pt.Run();
  } // end Main
} // end class definition