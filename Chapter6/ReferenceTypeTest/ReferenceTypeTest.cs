/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.Text;

public class ReferenceTypeTest {
  static void Main(){
    StringBuilder sb1 = new StringBuilder();
    StringBuilder sb2 = sb1;
    sb1.Append("Howdy Pawdner!");
    Console.WriteLine(sb1);
    Console.WriteLine(sb2);
  }
}
