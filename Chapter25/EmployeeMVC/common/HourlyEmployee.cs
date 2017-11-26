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
	[Serializable]
	public class HourlyEmployee : Employee {

		public HourlyEmployee():base() { }

		public HourlyEmployee(String firstName, String middleName, String lastName,
													Sex gender, DateTime birthday, Haircolor hairColor,
													String employee_number)
													:base(firstName, middleName, lastName, gender, birthday,
													hairColor, employee_number){ }
			 
		public override double Pay { 
			get { return base.PayInfo.HoursWorked * base.PayInfo.HourlyRate; }
		}

		public override String ToString() { 
			return (base.ToString() + " " + Pay.ToString("C3")); 
		}
	} // end HourlyEmployee class definition
} // end namespace