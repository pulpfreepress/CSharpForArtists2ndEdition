/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class ObjectArray {
 static void Main(){
    Object[] object_array = new Object[10];
    Console.WriteLine("object_array has type " + object_array.GetType());
    Console.WriteLine("object_array has rank " + object_array.Rank);
    Console.WriteLine();

    object_array[0] = new Object();
    Console.WriteLine(object_array[0].GetType());
    Console.WriteLine();
  
    object_array[1] = new Object();
    Console.WriteLine(object_array[1].GetType());
    Console.WriteLine();

    for(int i = 2; i < object_array.GetLength(0); i++){
        object_array[i] = new Object();
        Console.WriteLine(object_array[i].GetType());
        Console.WriteLine();
    }
  }
}