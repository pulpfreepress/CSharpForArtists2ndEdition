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
public class PersonVO {

	//enumeration
	public enum Sex {MALE, FEMALE}

	// private instance fields
	private string   _firstName;
	private string   _middleName;
	private string   _lastName;
	private Sex      _gender;       
	private DateTime _birthday;

	//default constructor
	public PersonVO(){
		_firstName = string.Empty;
		_middleName = string.Empty;
		_lastName = string.Empty;
		_gender = Sex.MALE;
		_birthday = DateTime.Now;
	}

	public PersonVO(string firstName, string middleName, string lastName, 
									Sex gender, DateTime birthday){
		_firstName = firstName;
		_middleName = middleName;
		_lastName = lastName;
		_gender = gender;
		_birthday = birthday;
	}

	// public properties
	public string FirstName {
		get { return _firstName; }
		set { _firstName = value; }
	}

	public string MiddleName {
		get { return _middleName; }
		set { _middleName = value; }
	}

	public string LastName {
		get { return _lastName; }
		set { _lastName = value; }
	}

	public Sex Gender {
		get { return _gender; }
		set { _gender = value; }
	}

	public DateTime Birthday {
		get { return _birthday; }
		set { _birthday = value; }
	}

	public int Age {
		get { 
			int years = DateTime.Now.Year - _birthday.Year;
			int adjustment = 0;
			if(DateTime.Now.Month < _birthday.Month){
				adjustment = 1;
			}else if((DateTime.Now.Month == _birthday.Month) && 
							(DateTime.Now.Day < _birthday.Day)){
							adjustment = 1;
						} 
		return years - adjustment;
		}
	}

	public string FullName {
		get { return FirstName + " " + MiddleName + " " + LastName; }
	}

	public string FullNameAndAge {
		get { return FullName + " " + Age; } 
	}

	public override string ToString(){
		return FullName + " is a " + Gender + " who is " + Age + " years old.";
	}
} // end PersonVO class
