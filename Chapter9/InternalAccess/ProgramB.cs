/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using ProgramA;

namespace ProgramB {
  
  public class C {
    public C(){
      ProgramA.A a = new ProgramA.A();
      Console.WriteLine("The value of a.i is: " + a.i);
    }
    
    static void Main(){
      C c = new C();
    }
    
  }
}
