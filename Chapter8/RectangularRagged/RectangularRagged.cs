/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class RectangularRagged {
  static void Main(){
    int[][] int_2d_array = new int[10][10];
    
    for(int i=0; i<int_2d_array.GetLength(0); i++){
      for(int j=0; j<int_2d_array.GetLength(1); j++){
        Console.Write(int_2d_array[i][j] + " ");
      }
      Console.WriteLine();
    }
 
  }
}