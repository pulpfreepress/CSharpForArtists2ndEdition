/********************************************************************************
  Copyright 2008 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class C : B {
	public C(){ 
		Console.WriteLine("C object created!");
	}

	public override void f(A a){
		Console.WriteLine("C.f() called!");
	}
}
