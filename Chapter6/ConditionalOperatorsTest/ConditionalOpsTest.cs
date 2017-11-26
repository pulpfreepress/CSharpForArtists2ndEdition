/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class ConditionalOpsTest {
	static void Main(){
		Console.WriteLine("false && false = " + (false  && false));
    Console.WriteLine("true  && false = " + (true  && false));
    Console.WriteLine("false && true  = " + (false && true));
    Console.WriteLine("true  && true  = " + (true  && true));
    Console.WriteLine("--------------------");
    Console.WriteLine("false || false = " + (false || false));
    Console.WriteLine("true  || false = " + (true  || false));
    Console.WriteLine("false || true  = " + (false || true));
		Console.WriteLine("true  || true  = " + (true  || true));
  }
}