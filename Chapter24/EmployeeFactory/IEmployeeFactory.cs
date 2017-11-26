/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public interface IEmployeeFactory {
	IEmployee GetNewSalariedEmployee(String firstName, String middleName, String lastName,
																	Sex gender, DateTime birthday, Haircolor hairColor, 
																	String employee_number);
	IEmployee GetNewHourlyEmployee(String firstName, String middleName, String lastName,
																Sex gender, DateTime birthday, Haircolor hairColor,
																String employee_number);
}
