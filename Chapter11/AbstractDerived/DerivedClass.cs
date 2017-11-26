/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class DerivedClass:AbstractClass {	
  private String _message;
  
  public override String Message {
     get { return _message; }
     set { _message = value; }
  }
  
  public DerivedClass(String message){
    _message = message;
    Console.WriteLine("DerivedClass object created...");
  }
  
  public DerivedClass():this("Default DerivedClass message"){ }
  
  public override void PrintMessage(){
    Console.WriteLine("DerivedClass PrintMessage(): " + _message);
  }
}