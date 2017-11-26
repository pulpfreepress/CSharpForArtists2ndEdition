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

public class SurrealistServer : MarshalByRefObject, ISurrealistServer {
	private List<Person> surrealists  = null;

	public SurrealistServer(){
		this.InitializeSurrealists();
	}

	public List<Person> GetSurrealists(){
		Console.WriteLine("Request for surrealists received!");
		return surrealists;
	}

	private void InitializeSurrealists(){
		surrealists = new List<Person>();
		Person p1 = new Person("Rick", "", "Miller", Person.Sex.MALE, 
														new DateTime(1965, 02, 08));
		Person p2 = new Person("Max", "", "Ernst", Person.Sex.MALE, 
														new DateTime(1891, 04, 02));
		Person p3 = new Person("Andre", "", "Breton", Person.Sex.MALE, 
														new DateTime(1896, 02, 19));
		Person p4 = new Person("Roland", "", "Penrose", Person.Sex.MALE, 
														new DateTime(1900, 10, 14));
		Person p5 = new Person("Lee", "", "Miller", Person.Sex.FEMALE, 
														new DateTime(1907, 04, 23));
		Person p6 = new Person("Henri-Robert-Marcel", "", "Duchamp", Person.Sex.MALE, 
														new DateTime(1887, 07, 28));
		
		surrealists.Add(p1);
		surrealists.Add(p2);
		surrealists.Add(p3);
		surrealists.Add(p4);
		surrealists.Add(p5);
		surrealists.Add(p6);
	}
}