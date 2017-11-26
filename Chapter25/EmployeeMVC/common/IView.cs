/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

namespace Com.PulpFreePress.Common {
	public interface IView {
		IEmployee EditingEmployee { get; set; }
		String FirstName { get; set; }
		String MiddleName { get; set; }
		String LastName { get; set; }
		String EmployeeNumber { get; set; }
		String Salary { get; set; }
		String HoursWorked { get; set; }
		String HourlyRate { get; set; }
		DateTime Birthday { get; set; }
		Sex Gender { get; set; }
		Haircolor HairColor { get; set; }
		IEmployee GetNewSalariedEmployee();
		IEmployee GetNewHourlyEmployee();
		IEmployee GetEditedEmployee();
		void PopulateEditFields(HourlyEmployee employee);
		void PopulateEditFields(SalariedEmployee employee);
		ViewMode Mode { get; set; }
		void DisplayEmployeeInfo(String[] employees_info);
		String GetSaveFile();
		String GetLoadFile();
		void ClearInputFields();
		void EnableCommonFields(bool state);
		void EnableSubmitButton(bool state);
		void EnableSalaryFields(bool state);
		void EnableHourlyFields(bool state);
		int GetSelectedLineNumber();
	} // end IView interface definition
} // end namespace