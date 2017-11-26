/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;


namespace ProgramA {

  public class A {
    internal int i = 0;
  
  
  }

  class B {
  
    static void Main(){
      A a = new A(); // OK - belongs to ProgramA
      B b = new B(); // OK - belongs to ProgramA
      Console.WriteLine("Value of a.i is: " + a.i); 
    }
  }

}
