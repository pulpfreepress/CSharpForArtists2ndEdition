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
    IMessagePrinter i1 = new MessagePrinter();
    MessagePrinter  m1 = new MessagePrinter();
    i1.PrintMessage();
    m1.PrintMessage();
    i1.Message = "New Message";
    m1.Message = "Another Message";
    i1.PrintMessage();
    m1.PrintMessage();
  }
}