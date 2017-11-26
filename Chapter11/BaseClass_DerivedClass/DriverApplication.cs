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
    BaseClass b1 = new BaseClass();
    BaseClass b2 = new DerivedClass();
    DerivedClass d1 = new DerivedClass();
    
    b1.PrintMessage();
    b2.PrintMessage();
    d1.PrintMessage();
  }

}