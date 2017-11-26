/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class ReadOnlyTest {
           int field_1 = 1;
  readonly int field_2 = 25;

  static void Main(){
     
     ReadOnlyTest rot = new ReadOnlyTest();
     Console.WriteLine(rot.field_1);
     Console.WriteLine(rot.field_2);
     
     rot.field_1 = 2;
     rot.field_2 = 26;  // this will cause an error
  
     Console.WriteLine(rot.field_1);
     Console.WriteLine(rot.field_2);
  }
}
