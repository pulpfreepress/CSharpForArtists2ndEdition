/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.Diagnostics.Contracts;

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
		Contract.Requires<ArgumentException>((0 <= i) && (i <= 100), "i");
		val = i;
		Console.WriteLine("Incrementer object created with initial value of: " + val);
		Contract.Ensures((0 <= val) && (val <= 100));
	}

	/**********************************************
		Method: void Increment(int i)
		precondition: 0 < i <= 5
		postcondition: 0 <= Incrementer.val <= 100
	*********************************************/
	public virtual void Increment(int i){
		Contract.Requires<ArgumentException>((0 <= i) && (i <= 5), "i");
		if((val+i) <= 100){
			val += i;
		} else {
				int temp = val;
				temp += i;
				val = (temp - 100);
			}
		Console.WriteLine("Incremeter value is: " + val); 
		Contract.Ensures((0 <= val) && (val <= 100));
	}

	/*****************************************************
		Method: void CheckInvariant() - called automatically
		at the return of each method to ensure invariant
		condition is satisfied.
	*****************************************************/
	[ContractInvariantMethod]
	private void CheckInvariant(){
		Contract.Invariant((0 <= val) && (val <= 100));
	}
}// end Incrementer class definition
