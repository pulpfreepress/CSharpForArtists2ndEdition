/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class MyType {
	private int _intField;

	public int IntField {
		get { return _intField; }
		set { _intField = value; }
	}

	public MyType():this(5){ }
  
	public MyType(int intField){
		_intField = intField;
	}

	public static MyType operator +(MyType mt){
		return new MyType(+mt.IntField);
	}

	public static MyType operator -(MyType mt){
		return new MyType(-mt.IntField);
	}

	public static bool operator ! (MyType mt){
		return (mt.IntField <= 0);	
	}
} // end class definition