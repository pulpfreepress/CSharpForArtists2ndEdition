/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class AssignmentOpsTest {
  static void Main(){
    int i = 0;
    Console.WriteLine("The value of i initially = " + i);
    Console.WriteLine("i += 1 = " + (i += 1));
    Console.WriteLine("i -= 1 = " + (i -= 1));
    Console.WriteLine("i += 2 = " + (i += 2));
    Console.WriteLine("i *= 2 = " + (i *= 2));
    Console.WriteLine("i /= 2 = " + (i /= 2));
  }
}