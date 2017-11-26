/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public interface IEmployee : IComparable<IEmployee> {
	int Age { get; }
	String FullName { get; }
	String FullNameAndAge { get; }
	String FirstName { get; set; }
	String MiddleName { get; set; }
	String LastName { get; set; }
	String EmployeeNumber { get; set; }
	DateTime Birthday { get; set; }
	Sex Gender { get; set; }
	Haircolor HairColor { get; set; }
	PayInfo PayInfo { get; set; }
	double Pay { get; }
}
