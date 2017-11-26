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
		MyProperties props = MyProperties.GetInstance();
		MyProperties props2 = MyProperties.GetInstance();
		Console.WriteLine("Should be true : " + (props == props2));
		//Add some keys and values
		props.SetProperty("Rick", "Pine Forest Senior High");
		props.SetProperty("Steve", "Seventy-First High School");
		props.SetProperty("Jake", "Terry Sanford High School");
		props.SetProperty("Laura", "Westover High School");
		props.SetProperty("Bob", "Reid Ross High School");
		//Save to XML file
		props.Store();
		//Read XML file
		props.Read();
		//Write values to console
		Console.WriteLine("----------------------------------");
		Console.WriteLine("Rick attended " + props.GetProperty("Rick"));
		Console.WriteLine("Steve attended " + props.GetProperty("Steve"));
		Console.WriteLine("Jake attended " + props.GetProperty("Jake"));
		Console.WriteLine("Laura attended " + props.GetProperty("Laura"));
		Console.WriteLine("Bob attended " + props.GetProperty("Bob"));
	}
}