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
public class Dog {

	private string _name = null;
	private DateTime _birthday;

	public Dog(string name, DateTime birthday){
		_name = name;
		_birthday = birthday;
	}

	public Dog():this("Snuggles", new DateTime(2005,01,01)){ }

	public Dog(string name):this(name, new DateTime(2005,01,01)){ }
	
	public int Age {
		get { 
			int years = DateTime.Now.Year - _birthday.Year;
			int adjustment = 0;
			if(DateTime.Now.Month < _birthday.Month){
				adjustment = 1;
			} else if((DateTime.Now.Month == _birthday.Month) && (DateTime.Now.Day < _birthday.Day)){
							adjustment = 1;
						} 
			return years - adjustment;
		}
	}
   
	public DateTime Birthday {
		get { return _birthday; }
		set { _birthday = value; }
	}

	public string Name {
		get { return _name; }
		set { _name = value; }
	}

	public override string ToString(){
		return (_name + "," + Age);     
	}
} // end class