/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class ResizeArrayTest {
   static void Main(){
     int[] int_array = {1,2,3};
     Console.WriteLine("int_array has {0} dimension(s)", int_array.Rank);
     Console.WriteLine();
     
     for(int i = 0; i<int_array.GetLength(0); i++){
       Console.WriteLine("int_array[{0}] = {1}", i, int_array[i]);
      }
      
      Array.Resize(ref int_array, 6);
      Console.WriteLine();
      
      for(int i = 0; i<int_array.GetLength(0); i++){
             Console.WriteLine("int_array[{0}] = {1}", i, int_array[i]);
      }
      
      int[,] int_array_2d = new int[10,10];
      Console.WriteLine();
      Console.WriteLine("int_array_2d has {0} dimension(s)", int_array_2d.Rank);
      Console.WriteLine("int_array_2d has {0} total elements", int_array_2d.Length);
      
   }
}