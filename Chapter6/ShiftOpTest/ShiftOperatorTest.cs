/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class ShiftOperatorTest {
  static void Main(){
    short i =  -0x000F;
    short j =   0x000F;
    Console.WriteLine("The value of i before the shift: " + i);
    Console.WriteLine("The value of j before the shift: " + j);
    Console.WriteLine("The value of i after the shift: " + (i >> 2));
    Console.WriteLine("The value of j after the shift: " + (j >> 2));
  }
}