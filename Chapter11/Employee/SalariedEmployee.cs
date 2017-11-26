/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class SalariedEmployee : Employee {
	
	private double _salary;
	
	public double Salary {
		get { return _salary; }
		set { _salary = value; }
	}
	
	public SalariedEmployee(String firstName, String middleName, String lastName, 
                Sex gender, DateTime birthday, String employeeNumber, double salary):
                base(firstName, middleName, lastName, gender, birthday, employeeNumber){
		_salary = salary;
		
	}
	
	public override double Pay(){
		return _salary/24;
	}
	
}