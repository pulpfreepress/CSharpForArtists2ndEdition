/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class EmployeeTestApp {
	public static void Main(){
		Employee[] employees = new Employee[4];
		
		employees[0] = new HourlyEmployee("Rick", "W", "Miller", Person.Sex.MALE, 
		                                  new DateTime(1964,02,02), "11111111", 80, 17.00);
		                                  
		employees[1] = new SalariedEmployee("Steve", "J", "Jones", Person.Sex.MALE, 
		                                  new DateTime(1975,08,09), "22222222", 130000.00);
		
		employees[2] = new HourlyEmployee("Bob", "E", "Evans", Person.Sex.MALE, 
		                                  new DateTime(1956,12,23), "33333333", 80, 25.00);
		
		employees[3] = new SalariedEmployee("Coralie", "S", "Miller", Person.Sex.FEMALE, 
		                                  new DateTime(1967,11,21), "44444444", 67000.00);
		
		for(int i=0; i<employees.Length; i++){
		  Console.WriteLine(employees[i].FullName + " " + String.Format("{0:C}", employees[i].Pay()));
	  }	
	} // end Main()
} // end class definition