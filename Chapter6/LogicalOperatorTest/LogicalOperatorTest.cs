/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class LogicalOperatorTest {
  static void Main(){
    int i = 0xFFFF;
    int mask_1 = 0x0000;
    int mask_2 = 0x0003;
    int mask_3 = 0xFFFF;
    Console.WriteLine("FFFF & 0000 = " + (i & mask_1));
    Console.WriteLine("FFFF | 0000 = " + (i | mask_1));
    Console.WriteLine("FFFF & 0003 = " + (i & mask_2));
    Console.WriteLine("FFFF | 0003 = " + (i | mask_2));
    Console.WriteLine("FFFF ^ FFFF = " + (i ^ mask_3));
  }
}