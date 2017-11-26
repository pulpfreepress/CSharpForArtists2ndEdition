/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.Collections.Generic;

public class SortingListDemo {
	public static void Main(){
		List<PersonVO> surrealists = new List<PersonVO>();
		
		PersonVO p1 = new PersonVO("Rick", "", "Miller", PersonVO.Sex.MALE, 
																new DateTime(1985, 03, 07), PersonVO.Haircolor.BROWN);
		PersonVO p2 = new PersonVO("Max", "", "Ernst", PersonVO.Sex.MALE, 
																new DateTime(1891, 04, 02), PersonVO.Haircolor.BLACK);
		PersonVO p3 = new PersonVO("Andre", "", "Breton", PersonVO.Sex.MALE, 
																new DateTime(1896, 02, 19), PersonVO.Haircolor.BLONDE);
		PersonVO p4 = new PersonVO("Roland", "", "Penrose", PersonVO.Sex.MALE, 
																new DateTime(1900, 10, 14), PersonVO.Haircolor.BLONDE);
		PersonVO p5 = new PersonVO("Lee", "", "Miller", PersonVO.Sex.FEMALE, 
																new DateTime(1907, 04, 23), PersonVO.Haircolor.BLONDE);
		PersonVO p6 = new PersonVO("Henri-Robert-Marcel", "", "Duchamp", PersonVO.Sex.MALE, 
																new DateTime(1887, 07, 28), PersonVO.Haircolor.BROWN);
		
		surrealists.Add(p1);
		surrealists.Add(p2);
		surrealists.Add(p3);
		surrealists.Add(p4);
		surrealists.Add(p5);
		surrealists.Add(p6);
		
		for(int i=0; i<surrealists.Count; i++){
			Console.WriteLine(surrealists[i].FullNameAndAge);
		}
		
		surrealists.Sort();
		Console.WriteLine("---------------------------------------");
		
		for(int i=0; i<surrealists.Count; i++){
			Console.WriteLine(surrealists[i].FullNameAndAge);
		}
		
	} // end Main() 
} // end SortingListDemo 