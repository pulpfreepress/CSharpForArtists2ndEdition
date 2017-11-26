/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

public class DriverApplication {
  public static void Main(){
    AbstractClass a1 = new DerivedClass();
    DerivedClass  d1 = new DerivedClass();
    a1.PrintMessage();
    d1.PrintMessage();
    a1.Message = "New Message";
    d1.Message = "Another Message";
    a1.PrintMessage();
    d1.PrintMessage();
  }
}