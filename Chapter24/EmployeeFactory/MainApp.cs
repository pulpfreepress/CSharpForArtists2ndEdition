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

public class MainApp {

	private IEmployeeFactory _employeeFactory = null;
	private List<IEmployee> _employeeList = null;

	public MainApp(){
		_employeeFactory = new EmployeeFactory();
		_employeeList = new List<IEmployee>();
	}

	public void CreateEmployees(){
		_employeeList.Add(_employeeFactory.GetNewSalariedEmployee("Rick", "Warren", "Miller",
											Sex.MALE, new DateTime(1968, 2, 4), Haircolor.BROWN, "0001"));
		_employeeList[0].PayInfo = new PayInfo(78000);
		_employeeList.Add(_employeeFactory.GetNewHourlyEmployee("Coralie", "Sylvia", "Powell",
											Sex.FEMALE, new DateTime(1969, 4, 8), Haircolor.BLONDE, "0002"));
		_employeeList[1].PayInfo = new PayInfo(80, 57);
	}

	public void ListEmployees(){
		foreach(IEmployee e in _employeeList){
			Console.WriteLine(e);
		}
	}

	public static void Main(){
		MainApp ma = new MainApp();
		ma.CreateEmployees();
		ma._employeeList.Sort();
		ma.ListEmployees();
	} // end Main()
} // end class definition