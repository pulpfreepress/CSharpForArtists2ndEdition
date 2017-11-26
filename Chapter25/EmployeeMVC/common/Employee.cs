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
	public abstract class Employee : IEmployee {
		private Person _person;
		private String  _employeeNumber;
		private PayInfo _payInfo;

		protected Employee(){
			_person = new Person();
		}

		protected Employee(String firstName, String middleName, String lastName, 
											Sex gender, DateTime birthday, Haircolor hairColor, 
											String employeeNumber){
			_person = new Person(firstName, middleName, lastName, gender, birthday, 
													hairColor);
			_employeeNumber = employeeNumber;
		}

		public int Age { 
			get{ return _person.Age; } 
		}
			
		public String FullName { 
			get { return _person.FullName; }
		}
		
		public String FullNameAndAge { 
			get { return _person.FullNameAndAge; } 
		}

		public String FirstName { 
			get { return _person.FirstName; } 
			set { _person.FirstName = value; }
		}

		public String MiddleName { 
			get { return _person.MiddleName; }
			set { _person.MiddleName = value; }
		}

		public String LastName { 
			get { return _person.LastName; }
			set { _person.LastName = value; }
		}

		public Sex Gender { 
			get { return _person.Gender; } 
			set { _person.Gender = value; }
		}

		public Haircolor HairColor {
			get { return _person.HairColor; }
			set { _person.HairColor = value; }
		}

		public String EmployeeNumber { 
			get { return _employeeNumber; } 
			set { _employeeNumber = value; }
		}

		public DateTime Birthday { 
			get { return _person.Birthday; } 
			set { _person.Birthday = value; } 
		}

		public PayInfo PayInfo { 
			get { return _payInfo; }
			set { _payInfo = value; }
		}

		// defer implementation of this property
		public abstract double Pay { get; } 

		public override String ToString(){
			return (_person + " " + EmployeeNumber + " ");
		}

		public int CompareTo(IEmployee other){
			return this.ToString().CompareTo(other.ToString());
		}
	}  // end Employee class definition
} // end namespace