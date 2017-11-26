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

public class Incrementer {
	/**********************************************
		Class invariant: 0 <= Incrementer.val <= 100
	**********************************************/
	private int val = 0;
	
	/********************************************
		Constructor Method: Incrementer(int i) 
		precondition: ((0 <= i) &&  (i <= 100))
		postcondition:  0 <= Incrementer.val <= 100
	********************************************/
	public Incrementer(int i){
		Debug.Assert((0 <= i) && (i <= 100));
		val = i;
		Console.WriteLine("Incrementer object created with initial value of: " + val);
		CheckInvariant();   // enforce class invariant
	}

	/**********************************************
		Method: void Increment(int i)
		precondition: 0 < i <= 5
		postcondition: 0 <= Incrementer.val <= 100
	*********************************************/
	public virtual void Increment(int i){
		Debug.Assert((0 < i) && (i <= 5)); // enforce precondition
		if((val+i) <= 100){
			val += i;
		} else {
				int temp = val;
				temp += i;
				val = (temp - 100);
			}
		CheckInvariant();           // enforce class invariant
		Console.WriteLine("Incremeter value is: " + val);   
	}

	/*********************************************
		Method: void CheckInvariant() - called
		immediately after any change to class
		invariant to ensure invariant condition
		is satisfied.
	*******************************************/
	private void CheckInvariant(){
		Debug.Assert((0 <= val) && (val <= 100));
	}
}// end Incrementer class definition
