/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class ArraySortApp {
  static void Main() {
    int[] int_array = { 100, 45, 9, 1, 34, 22, 6, 4, 3, 2, 99, 66 };

    for (int i = 0; i < int_array.Length; i++) {
        Console.Write(int_array[i] + " ");
    }
    Console.WriteLine();

    Array.Sort(int_array);

    for (int i = 0; i < int_array.Length; i++) {
        Console.Write(int_array[i] + " ");
    }
    } // end Main() method
} // end ArraySortApp class definition
