/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class MainApp {
	public static void Main(){
		Incrementer i1 = new Incrementer(0);
		i1.Increment(1);
		i1.Increment(2);
		i1.Increment(3);
		i1.Increment(4);
		i1.Increment(5);
		i1.Increment(6); // will throw an ArgumentException
	} // end Main() method
}// end MainApp clas definition
