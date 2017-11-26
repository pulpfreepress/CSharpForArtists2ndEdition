/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class ArrayTestApp {
  public static void Main(){
    DynamicArray da = new DynamicArray();
    Console.WriteLine("The array contains " + da.Count + " objects.");
    da.Add("Ohhh if you loved C# like I love C#!!");
    Console.WriteLine(da[0].ToString());
    for(int i = 1; i<26; i++){
      da.Add(i);
    }
    Console.WriteLine("The array contains " + da.Count + " objects.");
    for(int i=0; i<da.Count; i++){
      if(da[i] != null){
	    Console.Write(da[i].ToString() + ", ");
	    }
    }
    Console.WriteLine();
  }//end Main() method
}// end ArrayTestApp class definition
