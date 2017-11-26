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
		PersonVO p1 = new PersonVO("Rick", "Warren", "Miller", PersonVO.Sex.MALE,
															new DateTime(1985, 3, 7), PersonVO.Haircolor.BROWN);
		PersonVO p2 = new PersonVO(p1); // using copy constructor
		Console.WriteLine(p1);
		Console.WriteLine(p2);
		p1.FirstName = "Steve";
		p1.MiddleName = "Jay";
		p1.LastName = "Jones";
		Console.WriteLine(p1);
		Console.WriteLine(p2);
  }
}