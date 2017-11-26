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
		PersonVO p2 = new PersonVO(p1);
		PersonVO p3 = new PersonVO("Coralie", "Sarah", "Miller", PersonVO.Sex.FEMALE, 
																new DateTime(1989, 4, 5), PersonVO.Haircolor.BLONDE);
		PersonVO p4 = null;

		Console.WriteLine("p1.Equals(p1) = " +  p1.Equals(p1));
		Console.WriteLine("p1.Equals(p2) = " +  p1.Equals(p2));
		Console.WriteLine("p2.Equals(p1) = " +  p2.Equals(p1));
		Console.WriteLine("p1.Equals(p3) = " +  p1.Equals(p3));
		Console.WriteLine("p3.Equals(p1) = " +  p3.Equals(p1));
		Console.WriteLine("p1.Equals(null) = " +  p1.Equals(null));
		Console.WriteLine("p1.Equals(p4) = " +  p1.Equals(p4));
		Console.WriteLine("------------------------------------");
		Console.WriteLine("p1.GetHashCode() = " + p1.GetHashCode());
		Console.WriteLine("p2.GetHashCode() = " + p2.GetHashCode());
		Console.WriteLine("p3.GetHashCode() = " + p3.GetHashCode()); 
	}
}