/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class TwoDimensionalArray {
  static void Main(String[] args){
  
    try{
     int rows = Int32.Parse(args[0]);
     int cols = Int32.Parse(args[1]);

     int[,] int_2d_array = new int[rows, cols];
     Console.WriteLine("          Array rank: " + int_2d_array.Rank);
     Console.WriteLine("          Array type: " + int_2d_array.GetType());
     Console.WriteLine("Total array elements: " + int_2d_array.Length);
     Console.WriteLine();

     for(int i = 0, element = 1; i<int_2d_array.GetLength(0); i++){
       for(int  j = 0; j<int_2d_array.GetLength(1); j++){
        int_2d_array[i,j] = element++;
        Console.Write("{0:D3} ",int_2d_array[i,j]);
       }
        Console.WriteLine();
     }
     
    }catch(IndexOutOfRangeException){
       Console.WriteLine("This program requires two command-line arguments.");
    }catch(FormatException){
       Console.WriteLine("Arguments must be integers!");
    }
  }
}
