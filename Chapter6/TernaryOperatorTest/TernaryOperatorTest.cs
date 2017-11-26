/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class TernaryOperatorTest {
  static void Main(){
    Console.WriteLine(true  ? "Return this string if true" : "Return this string if false");
    Console.WriteLine(false ? "Return this string if true" : "Return this string if false");   
    Console.WriteLine();
    int i = 3;
    int j = 7;
    Console.WriteLine((i < j)  ? "Return this string if true" : "Return this string if false");
    Console.WriteLine((i > j)  ? "Return this string if true" : "Return this string if false"); 
  }
}