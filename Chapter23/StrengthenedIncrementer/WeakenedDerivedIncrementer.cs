/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

#define DEBUG
using System;
using System.Diagnostics;

public class WeakenedDerivedIncrementer : Incrementer {
	/********************************************
		Class invariant: 0 <= val <= 50
	******************************************/
	private int val = 0;

	/**********************************************
		Constructor Method: WeakenedDerivedIncrementer(int i)
		precondition: ((0 <= i) && (i <= 50))
		postcondition: 0 <= val <= 50
	**********************************************/
	public WeakenedDerivedIncrementer(int i):base(i){
		Debug.Assert((0 <= i) && (i <= 50));  // enforce precondition
		val = i;
		Console.WriteLine("WeakenedDerivedIncrementer object created with value: " + val);
		CheckInvariant();
	}

	/***********************************************
		Method: void Increment(int i)
		precondition: ((0 < i) && (i <= 10)) 
		postcondition: 0 <= val <= 50
	***********************************************/
	override public void Increment(int i){
		Debug.Assert((0 < i) && (i <= 10)); // enforce precondition
		if((0 <= i) && (i <= 5)){  // remember, it's our job to use the base class correctly!
			base.Increment(i);
		}

		if((val+i) <= 50){
			val += i;
		} else {
				int temp = val;
				temp += i;
				val = (temp - 50);
			}
		CheckInvariant();  // check invariant
		Console.WriteLine("WeakenedDerivedIncrementer value is: " + val);
	}
	
	/*********************************************
		Method: void CheckInvariant() - called
		immediately after any change to class
		invariant to ensure invariant condition
		is satisfied.
	*******************************************/
	private void CheckInvariant(){
		Debug.Assert((0 <= val) && (val <= 50));
	}
} // end WeakenedDerivedIncrementer class definition
