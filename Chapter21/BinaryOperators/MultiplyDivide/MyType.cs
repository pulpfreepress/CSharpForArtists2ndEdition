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
  
	public static bool operator true(MyType mt){
		return !(!mt);
	}

	public static bool operator false(MyType mt){
		return !mt;
	}

	public static MyType operator ++(MyType mt){
		MyType result = new MyType(mt.IntField);
		++result.IntField;
		return result;
	}

	public static MyType operator --(MyType mt){
		MyType result = new MyType(mt.IntField);
		--result.IntField;
		return result;
	}

	public static MyType operator +(MyType lhs, MyType rhs){
		MyType result = new MyType(lhs.IntField);
		result.IntField += rhs.IntField;
		return result;
	}

	public static MyType operator -(MyType lhs, MyType rhs){
		MyType result = new MyType(lhs.IntField);
		result.IntField -= rhs.IntField;
		return result;
	}

	public static MyType operator +(MyType lhs, int rhs){
		MyType result = new MyType(lhs.IntField);
		result.IntField += rhs;
		return result;
	}

	public static MyType operator -(MyType lhs, int rhs){
		MyType result = new MyType(lhs.IntField);
		result.IntField -= rhs;
		return result;
	}
  
	public static MyType operator *(MyType lhs, MyType rhs){
		MyType result = new MyType(lhs.IntField);
		result.IntField *= rhs.IntField;
		return result;
	}

	public static MyType operator *(MyType lhs, int rhs){
		MyType result = new MyType(lhs.IntField);
		result.IntField *= rhs;
		return result;
	}

	public static MyType operator /(MyType lhs, MyType rhs){
		MyType result = new MyType(lhs.IntField);
		result.IntField /= rhs.IntField;
		return result;
	}

	public static MyType operator /(MyType lhs, int rhs){
		MyType result = new MyType(lhs.IntField);
		result.IntField /= rhs;
		return result;
	}

	public override String ToString(){
		return IntField.ToString();
	}
} // end class definition