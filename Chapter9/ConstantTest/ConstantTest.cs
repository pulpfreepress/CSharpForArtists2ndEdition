/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class ConstantTest {
                  int    field_1 = 1;
  static readonly int    field_2 = 25;
            const int CONSTANT_1 = 35;
  
  static void Main(){
    ConstantTest ct = new ConstantTest();
    Console.WriteLine(ct.field_1);              // can only be accessed via reference since it's non-static
    Console.WriteLine(ConstantTest.field_2);    // can be accessed via class
    Console.WriteLine(field_2);                 // or directly because it's static
    Console.WriteLine(ConstantTest.CONSTANT_1); // can be accessed via class
    Console.WriteLine(CONSTANT_1);              // or directly because it's static
  }
}