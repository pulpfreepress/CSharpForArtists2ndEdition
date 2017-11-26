/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.Collections;

public class MainApp {
	public static void Main(){
		ArrayList surrealists = new ArrayList();
		
		Person p1 = new Person("Rick", "", "Miller", Person.Sex.MALE, new DateTime(1965, 02, 04));
		Person p2 = new Person("Max", "", "Ernst", Person.Sex.MALE, new DateTime(1891, 04, 02));
		Person p3 = new Person("Andre", "", "Breton", Person.Sex.MALE, new DateTime(1896, 02, 19));
		Person p4 = new Person("Roland", "", "Penrose", Person.Sex.MALE, new DateTime(1900, 10, 14));
		Person p5 = new Person("Lee", "", "Miller", Person.Sex.FEMALE, new DateTime(1907, 04, 23));
		Person p6 = new Person("Henri-Robert-Marcel", "", "Duchamp", Person.Sex.MALE, new DateTime(1887, 07, 28));
		
		surrealists.Add(p1);
		surrealists.Add(p2);
		surrealists.Add(p3);
		surrealists.Add(p4);
		surrealists.Add(p5);
		surrealists.Add(p6);
		
		foreach(object o in surrealists){
		  //Console.WriteLine(o.ToString());
			Console.WriteLine(o);
		}
		
		Console.WriteLine("-----------------------------------------------------");
		
		foreach(Person p in surrealists){
			Console.WriteLine(p.FirstName);
		}
		
		Console.WriteLine("-----------------------------------------------------");
		
		for(int i = 0; i<surrealists.Count; i++){
			Console.WriteLine(((Person)surrealists[i]).FirstName + " " + ((Person)surrealists[i]).LastName);
		}
		
	} // end Main()
} // end MainApp class definition