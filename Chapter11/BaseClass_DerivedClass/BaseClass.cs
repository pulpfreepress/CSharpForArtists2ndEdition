/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class BaseClass {
  private String _message;
  
  public String Message {
    get { return _message; }
    set { _message = value; }
  }
  
  public BaseClass(String message){
    Console.WriteLine("BaseClass object created...");
    Message = message;
  }
  
  public BaseClass():this("Default BaseClass message"){ }
  
  public void PrintMessage(){
    Console.WriteLine("BaseClass PrintMessage(): " + _message);
  }

}