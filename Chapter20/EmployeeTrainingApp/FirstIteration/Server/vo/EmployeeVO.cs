/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.Drawing;

namespace EmployeeTraining.VO {

	[Serializable]
	public class EmployeeVO : PersonVO {

		// private instance fields
		private Guid	_employeeID;
		private Image	_picture;

		//default constructor
		public EmployeeVO(){}

		public EmployeeVO(Guid employeeID, string firstName, string middleName, 
											string lastName, Sex gender, DateTime birthday)
											:base(firstName, middleName, lastName, gender, birthday){
			_employeeID = employeeID;
		}

		// public properties
		public Guid EmployeeID {
			get { return _employeeID;  }
			set { _employeeID = value; }
		}
	
		public Image Picture {
			get { return _picture;  }
			set { _picture = value; }
		}

		public override string ToString(){
			return (_employeeID + " " + base.ToString());
		}
	} // end EmployeeVO class
} // end namespace 
