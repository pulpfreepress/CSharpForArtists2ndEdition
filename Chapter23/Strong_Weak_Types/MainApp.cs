/********************************************************************************
  Copyright 2008 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class MainApp {
	public static void Main(){
		A a1 = new A();
		a1.f(new A()); // A's method called

		Console.WriteLine("------------------");

		A a2 = new B();
		a2.f(new A()); // A's method called
		a2.f(new B()); // A's method called
		
    Console.WriteLine("------------------");

		B b1 = new C();
		b1.f(new A());  // C's overriding method called
		b1.f(new B()); // B's overloaded method called
		b1.f(new C()); // B's overloaded method called

		Console.WriteLine("------------------");

		A a3 = new C();  
		a3.f(new A()); // C's overriding method called
		a3.f(new B()); // C's overriding method called
		a3.f(new C()); // C's overriding method called
	} // end Main() method
} // end MainApp program
