/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class ReferenceEqualityTest {
  static void Main(){
     Object o1 = new Object();
     Object o2 = new Object();
     Object o3 = o2;
     String s1 = "Hello";
     String s2 = "Hello";
     String s3 = "World";
     Console.WriteLine(o1 == o2);
     Console.WriteLine(o1 != o2);
     Console.WriteLine(o2 == o3);
     Console.WriteLine(s1 == s2);
     Console.WriteLine(s1 == s3);
  }
}