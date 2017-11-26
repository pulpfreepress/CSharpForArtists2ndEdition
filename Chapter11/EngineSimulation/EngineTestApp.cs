/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using EngineSimulation;

public class EngineTestApp {
	public static void Main(){
		Engine e1 = new Engine(1);
		e1.StartEngine();
		e1.SetPartFault("OilPump");
		e1.ClearPartFault("OilPump");
		e1.StartEngine();
		e1.StopEngine();
	} // end Main()
} // end class