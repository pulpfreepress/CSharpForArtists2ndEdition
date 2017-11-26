/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class ArrayLiterals {
  static void Main(){
    int[] int_array = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
    double[] double_array = {1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0, 10.0};

    for(int i = 0; i < int_array.GetLength(0); i++){
      Console.Write(int_array[i] + " ");
    }
    Console.WriteLine();
    Console.WriteLine(int_array.GetType());
    Console.WriteLine(int_array.GetType().IsArray);
 
    Console.WriteLine();
   
    for(int i = 0; i < double_array.GetLength(0); i++){
      Console.Write(double_array[i] + " ");
    }
    Console.WriteLine();
    Console.WriteLine(double_array.GetType());
    Console.WriteLine(double_array.GetType().IsArray);
  }
}
