/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class HourlyEmployee : Employee {
	
	private int _hoursWorked;
	private double _hourlyWage;
	
	public int HoursWorked {
		get { return _hoursWorked; }
		set { _hoursWorked = value; }
	}
	
	public double HourlyWage {
		get { return _hourlyWage; }
		set { _hourlyWage = value; }
	}
	
	public HourlyEmployee(String firstName, String middleName, String lastName, 
                Sex gender, DateTime birthday, String employeeNumber, int hoursWorked,
                double hourlyWage): base(firstName, middleName, lastName, gender, birthday,
                employeeNumber){
		_hoursWorked = hoursWorked;
		_hourlyWage = hourlyWage;
	}
	
	public override double Pay(){
		return _hoursWorked * _hourlyWage;
	}
	
}