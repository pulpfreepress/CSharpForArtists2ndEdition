/********************************************************************************
  Copyright 2008 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class MainApp {
	public static void Main(){
		MyType mt = new MyType();
		MyType mt2 = new MyType(6);
		Console.WriteLine("mt = " + mt);
		Console.WriteLine("mt2 = " + mt2);
		MyType mt3 = mt2; // assignment
		Console.WriteLine("mt3 should be 6:" + mt3);
		mt += mt2; // addition assignment
		Console.WriteLine("mt += mt2 : mt should be 11 : " + mt);
		mt *= mt;  // multiplication assignment
		Console.WriteLine("mt *= mt : mt should be 121 : " + mt);
		mt /= 2; // division assignment - will lose the remainder when doing integer division
		Console.WriteLine("mt /= 2 : mt should be 60 :  " + mt);
	}
}