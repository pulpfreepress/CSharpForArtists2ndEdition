/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class Ragged2dArray {
  static void Main(){
    int[][] ragged_2d_array = new int[10][];
   
    Console.WriteLine("ragged_2d_array has rank: " + ragged_2d_array.Rank);
    Console.WriteLine("ragged_2d_array has type: " + ragged_2d_array.GetType());
    Console.WriteLine("Total number of elements: " + ragged_2d_array.Length);
    Console.WriteLine();
    
    for(int i = 0; i<ragged_2d_array.GetLength(0); i++){
      ragged_2d_array[i] = new int[i+1];
    }
    
    for(int i = 0; i<ragged_2d_array.GetLength(0); i++){
      for(int j = 0; j<ragged_2d_array[i].GetLength(0); j++){
        Console.Write(ragged_2d_array[i][j] + " ");
      }
      Console.WriteLine();
    }
  }
}