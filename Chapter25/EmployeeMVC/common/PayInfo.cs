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
	public class PayInfo {
		// fields
		private double _salary = 0;
		private double _hoursWorked = 0;
		private double _hourlyRate = 0;

		// properties
		public double Salary {
			get { return _salary; }
			set { _salary = value; }
		}  

		public double HoursWorked {
			get { return _hoursWorked; }
			set { _hoursWorked = value; }
		}

		public double HourlyRate {
			get { return _hourlyRate; }
			set { _hourlyRate = value; }
		}

		// constructors
		public PayInfo(){ }

		public PayInfo(double salary){
			_salary = salary;
		}
		
		public PayInfo(double hoursWorked, double hourlyRate){
			_hoursWorked = hoursWorked;
			_hourlyRate = hourlyRate;
		}
	} // end PayInfo class definition
} // end namespace
