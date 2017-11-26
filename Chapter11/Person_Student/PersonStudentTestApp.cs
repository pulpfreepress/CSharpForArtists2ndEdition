/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class PersonStudentTestApp {
  public static void Main(){
    Person p1 = new Person("Ulysses", "S", "Grant", Person.Sex.MALE, new DateTime(1822, 04, 22));
    Person p2 = new Student("Steven", "Jay", "Jones", Person.Sex.MALE, new DateTime(1986, 03, 21), 
                            "1234564", "Finance");
    Student s1 = new Student("Virginia", "LeAnn", "Mattson", Person.Sex.FEMALE, new DateTime(1973, 09, 14), 
                             "8798765", "Computer Science");
    Console.WriteLine(p1);
    Console.WriteLine(p2);
    Console.WriteLine(s1);
    
    // p2.Major = "Criminal Justice"; // ERROR: p2 is a Person reference
    s1.Major = "Physics";
    
    Console.WriteLine("---------------------------------------------");
    Console.WriteLine(p2);
    Console.WriteLine(s1);
  }
}