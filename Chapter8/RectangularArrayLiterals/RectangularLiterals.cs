/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class RectangularLiterals {
  static void Main(){
    char[,] char_2d_array = {{'a', 'b', 'c'},
                              {'d', 'e', 'f'},
                              {'g', 'h', 'i'}};
                              
    Console.WriteLine("char_2d_array has rank: " + char_2d_array.Rank);
    Console.WriteLine("char_2d_array has type: " + char_2d_array.GetType());
    Console.WriteLine("Total number of elements: " + char_2d_array.Length);
    Console.WriteLine();
    
    for(int i = 0; i<char_2d_array.GetLength(0); i++){
      for(int j = 0; j<char_2d_array.GetLength(1); j++){
        Console.Write(char_2d_array[i,j] + " ");
      }
      Console.WriteLine();
    }
  }
}