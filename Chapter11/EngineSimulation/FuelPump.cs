/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

namespace EngineSimulation {

  public class FuelPump : EnginePart {
	
	  public FuelPump(PartStatus status, int engineNumber):
	                    base(status, "FuelPump", engineNumber){
			Console.WriteLine("FuelPump created...");							
		}
  } // end class
} // end namespace