/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class Subscriber {
	
  public Subscriber(Publisher publisher){
   	publisher.MinuteTick += MinuteTickHandler;
    Console.WriteLine("Subscriber Created");
  }
  
  public void MinuteTickHandler(Object sender, MinuteEventArgs e){
    Console.WriteLine("Subscriber Handler Method: {0}", e.Minute);
  }
 } // end Subscriber class definition
