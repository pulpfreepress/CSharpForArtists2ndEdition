/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class IntArrayTest {
  static void Main(){
    int[] int_array = new int[10];
    for(int i = 0; i < int_array.GetLength(0); i++){
      Console.Write(int_array[i] + " ");
     }
     Console.WriteLine();
  }
}