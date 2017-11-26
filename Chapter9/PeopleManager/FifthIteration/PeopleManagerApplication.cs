/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class PeopleManagerApplication {
  public static void Main(){
    Person p1 = new Person("Ulysses", "S", "Grant", "Male", new DateTime(1822, 04, 22));
    Console.WriteLine(p1.FirstName + " " + p1.MiddleName + " " + p1.LastName + " " 
                      + p1.Gender + " " + p1.Birthday);
    Console.WriteLine(p1.FirstName + " is " + p1.Age + " years old!");
		p1.FirstName = "Rick";
		p1.MiddleName = "Warren";
		p1.LastName = "Miller";
		p1.Gender = "Male";
		p1.Birthday = new DateTime(1965, 02, 14);
		Console.WriteLine(p1.FirstName + " " + p1.MiddleName + " " + p1.LastName + " " 
                      + p1.Gender + " " + p1.Birthday);
		Console.WriteLine(p1.FirstName + " is " + p1.Age + " years old!");
  } // end Main
} // end class definition