/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

[Serializable]
public class SalariedEmployee : Employee {

	public SalariedEmployee():base() { }

	public SalariedEmployee(String firstName, String middleName, String lastName, 
													Sex gender, DateTime birthday, Haircolor hairColor, 
													String employeeNumber)
													:base(firstName, middleName, lastName, gender, birthday, 
													hairColor, employeeNumber){ }
     
	public override double Pay { 
		get { return ((base.PayInfo.Salary/12.0)/2.0); }
	}

	public override String ToString() { 
		return (base.ToString() + " " + Pay.ToString("C3")); 
	}
} // end SalariedEmployee class definition
