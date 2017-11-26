/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class MessageArray {
  static void Main(){    
    String name = null; 
    int int_val = 0;

    String[] messages = {"Welcome to the Message Array Program",
			  "Please enter your name: ",
                          ", please enter an integer: ",
			  "You did not enter an integer!",
			  "Thank you for running the Message Array program"};

    const int WELCOME_MESSAGE     = 0;
    const int ENTER_NAME_MESSAGE  = 1;
    const int ENTER_INT_MESSAGE   = 2;
    const int INT_ERROR           = 3;
    const int THANK_YOU_MESSAGE   = 4;

    Console.WriteLine(messages[WELCOME_MESSAGE]);
    Console.Write(messages[ENTER_NAME_MESSAGE]);
    name = Console.ReadLine();
       
    Console.Write(name + messages[ENTER_INT_MESSAGE]);

    try{
        int_val = Int32.Parse(Console.ReadLine());
       }catch(FormatException) { Console.WriteLine(messages[INT_ERROR]); }
        
    Console.WriteLine(messages[THANK_YOU_MESSAGE]);            
  }
}
