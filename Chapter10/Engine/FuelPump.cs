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

	public class FuelPump {
		private int _registeredEngineNumber = 0;
    private PartStatus _partStatus;

    public PartStatus Status {
      get { return _partStatus; }
      set { _partStatus = value; }
    }

    public int RegisteredEngineNumber {
      get { return _registeredEngineNumber; }
      set { _registeredEngineNumber = value; }
    }

    public bool IsWorking {
      get {
        if (Status == PartStatus.WORKING) {
          return true;
        }
        return false;
      }
    }

    public FuelPump(PartStatus status, int engine_number) {
      RegisteredEngineNumber = engine_number;
      Status = status;
      Console.WriteLine("FuelPump Created...");
    }
  } // end class definition
} // end namespace
