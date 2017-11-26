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
		MyComplexType mct1 = new MyComplexType("mct1");
		mct1.StringList[0] = "Hello";
		mct1.StringList[1] = "World";
		Console.WriteLine(mct1);

		MyComplexType mct2 = (MyComplexType)mct1.Clone();
		Console.WriteLine(mct2);
		mct2.StringList[0] = "New String";
		Console.WriteLine(mct1);
		Console.WriteLine(mct2);

		MyComplexType mct3 = (MyComplexType)mct2.GetMemberwiseClone();
		Console.WriteLine(mct3);
		mct2.StringList[2] = "Another String";
		Console.WriteLine(mct2);
		Console.WriteLine(mct3);
	} // end main
} // end class definition