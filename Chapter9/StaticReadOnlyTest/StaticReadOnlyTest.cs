/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class StaticReadOnlyTest {
                  int field_1 = 1;
  static readonly int field_2 = 25;
  
  
  void InstanceMethod(){
     Console.WriteLine("From instance method: " + field_2); 
  }

  static void Main(){
     
     StaticReadOnlyTest srot = new StaticReadOnlyTest();
     Console.WriteLine(srot.field_1);
     srot.InstanceMethod();
     
     srot.field_1 = 2;
    
     Console.WriteLine(srot.field_1);
     Console.WriteLine(field_2);
  }
}
